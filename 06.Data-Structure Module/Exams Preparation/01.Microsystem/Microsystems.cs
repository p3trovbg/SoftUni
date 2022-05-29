namespace _01.Microsystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Microsystems : IMicrosystem
    {
        private Dictionary<int, Computer> computersById = new Dictionary<int, Computer>();
        public void CreateComputer(Computer computer)
        {
            if(computersById.ContainsKey(computer.Number))
            {
                throw new ArgumentException();
            }

            computersById.Add(computer.Number, computer);
        }

        public bool Contains(int number) => computersById.ContainsKey(number);


        public int Count() => computersById.Count;

        public Computer GetComputer(int number)
        {
            if (!computersById.ContainsKey(number))
            {
                throw new ArgumentException();
            }

            return computersById[number];
        }

        public void Remove(int number)
        {
            if (!computersById.ContainsKey(number))
            {
                throw new ArgumentException();
            }

            computersById.Remove(number);
        }

        public void RemoveWithBrand(Brand brand)
        {
            var newList = computersById.Where(x => x.Value.Brand != brand).ToDictionary(x => x.Key, x => x.Value);
            if(newList.Count == computersById.Count)
            {
                throw new ArgumentException();
            }

            computersById = newList;
        }

        public void UpgradeRam(int ram, int number)
        {
            if(!computersById.ContainsKey(number))
            {
                throw new ArgumentException();
            }

            var selectComputer = computersById.First(x => x.Key == number);
            var computerRam = selectComputer.Value.RAM;
            selectComputer.Value.RAM = computerRam < ram ? ram : computerRam;
        }

        public IEnumerable<Computer> GetAllFromBrand(Brand brand)
        {
            return computersById.Values.Where(x => x.Brand == brand).OrderByDescending(x => x.Price);
        }

        public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
        {
            return computersById.Values.Where(x => x.ScreenSize == screenSize).OrderByDescending(x => x.Number);
        }

        public IEnumerable<Computer> GetAllWithColor(string color)
        {
            return computersById.Values.Where(x => x.Color.Equals(color)).OrderByDescending(x => x.Price);
        }

        public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
        {
            return computersById.Values.Where(x => x.Price >= minPrice && x.Price <= maxPrice).OrderByDescending(x => x.Price);
        }
    }
}
