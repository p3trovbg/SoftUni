using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Discord
{
    public class Discord : IDiscord
    {
        private Dictionary<string, Message> messages = new Dictionary<string, Message>();
        private Dictionary<string, List<Message>> channels = new Dictionary<string, List<Message>>();
        public int Count => messages.Count;

        public bool Contains(Message message) => messages.ContainsKey(message.Id);

        public void DeleteMessage(string messageId)
        {
            if(!messages.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }
            messages.Remove(messageId);
        }

        public IEnumerable<Message> GetAllMessagesOrderedByCountOfReactionsThenByTimestampThenByLengthOfContent()
            => messages.Values.OrderByDescending(x => x.Reactions.Count).ThenBy(x => x.Timestamp).ThenBy(x => x.Content.Length);     

        public IEnumerable<Message> GetChannelMessages(string channel)
        {
            var selected =  messages.Values.Where(x => x.Channel == channel);
            if(!selected.Any())
            {
                throw new ArgumentException();
            }
            return selected;
        }

        public Message GetMessage(string messageId)
        {
            if(!messages.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }
            return messages[messageId];
        }

        public IEnumerable<Message> GetMessageInTimeRange(int lowerBound, int upperBound)
        {
            //The results should be ordered by count of total messages contained in each message’s channel, in descending order. 

            return messages.Values.Where(x => x.Timestamp >= lowerBound && x.Timestamp <= upperBound).OrderByDescending(x => x.Channel);
        }

        public IEnumerable<Message> GetMessagesByReactions(List<string> reactions)
        {
            List<Message> selected = new List<Message>();
            foreach (var item in messages.Values)
            {
                foreach (var reaction in item.Reactions)
                {
                    if(reactions.Contains(reaction))
                    {
                        selected.Add(item);
                    }
                }
            }

            return selected.OrderByDescending(x => x.Reactions.Count).ThenBy(x => x.Timestamp);
        }

        public IEnumerable<Message> GetTop3MostReactedMessages()
        {
            //returns the top 3 messages in terms of count of reactions in descending order. If there aren’t any messages – return an empty collection.
            return messages.Values.OrderByDescending(x => x.Reactions).Take(3);
        }

        public void ReactToMessage(string messageId, string reaction)
        {
            if (!messages.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }
            messages[messageId].Reactions.Add(reaction);
        }

        public void SendMessage(Message message)
        {
            messages.Add(message.Id, message);
            if(!channels.ContainsKey(message.Channel))
            {
                channels.Add(message.Channel, new List<Message>());
            }
            channels[message.Channel].Add(message);

        }
    }
}
