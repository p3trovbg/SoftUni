namespace RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Arena : IArena
    {
        private Dictionary<int, BattleCard> cards;
        public Arena()
        {
            cards = new Dictionary<int, BattleCard>();
        }

        public int Count => cards.Count;

        public void Add(BattleCard card)
        {
            if(!Contains(card))
            {
                cards.Add(card.Id, card);
            }
        }

        public void ChangeCardType(int id, CardType type)
        {
            if (!cards.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            cards[id].Type = type;
        }

        public bool Contains(BattleCard card)
        {
            return cards.ContainsKey(card.Id);
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if(n > Count)
            {
                throw new InvalidOperationException();
            }
            return cards.OrderBy(x => x.Value.Swag).ThenBy(x => x.Value.Id).Take(n).Select(x => x.Value);
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            return cards.Where(x => x.Value.Swag >= lo && x.Value.Swag <= hi).OrderBy(x => x.Value.Swag).Select(x => x.Value);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            var selectCards = cards
                .Where(x => x.Value.Type == type)
                .OrderByDescending(x => x.Value.Damage)
                .ThenBy(x => x.Value.Id)
                .Select(x => x.Value);

            if (!selectCards.Any())
            {
                throw new InvalidOperationException();
            }
            return selectCards;
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            var getCards = cards
                .Where(x => x.Value.Type == type && x.Value.Damage <= damage)
                .OrderByDescending(x => x.Value.Damage)
                .ThenBy(x => x.Value.Id)
                .Select(x => x.Value);
                

            if(!getCards.Any())
            {
                throw new InvalidOperationException();
            }

            return getCards;
        }

        public BattleCard GetById(int id)
        {
            var card = cards.FirstOrDefault(x => x.Value.Id == id);
            if(card.Value == null)
            {
                throw new InvalidOperationException();
            }
            return card.Value;
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            var selectedCards = GetAllInSwagRange(lo, hi).Where(x => x.Name == name);
            if(!selectedCards.Any())
            {
                throw new InvalidOperationException();
            }

            return selectedCards.OrderByDescending(x => x.Swag).ThenBy(x => x.Id);

        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
           var selectedCards = cards.Select(x => x.Value).Where(x => x.Name == name);
            if (!selectedCards.Any())
            {
                throw new InvalidOperationException();
            }

            return selectedCards.OrderByDescending(x => x.Swag).ThenBy(x => x.Id);
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            var selectedCards = GetByCardTypeAndMaximumDamage(type, hi).Where(x => x.Damage >= lo);

            if (!selectedCards.Any())
            {
                throw new InvalidOperationException();
            }

            return selectedCards;
        }

        public void RemoveById(int id)
        {
            if(!cards.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }
            cards.Remove(id);
        }

        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var card in cards)
            {
                yield return card.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}