using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EgnValidation
{
    public class EgnValidator : IEgnValidator
    {
        public List<string> Generate(DateTime birthDate, string city, bool isMale)
        {
            BirthdateValidation(birthDate);
            CityValidation(city);

            string gender = isMale ? Gender.Male.ToString() : Gender.Female.ToString();
            int year = birthDate.Year;
            int month = birthDate.Month;
            int day = birthDate.Day;
            if (year < 1900)
            {
                month += 20;
            }
            else if (year >= 2000)
            {
                month += 40;
            }

            List<string> allRegionDigits = RegionDigitsFactory.RangeDigitForCurrentRegion(city, gender);
            StringBuilder egn = new StringBuilder();
            var allValidEgn = new List<string>();
            
            for (int i = 0; i < allRegionDigits.Count; i++)
            {
                egn.Append(birthDate.ToString("yy"));
                egn.Append($"{month:d2}");
                egn.Append(birthDate.ToString("dd"));

                int regionDigit = int.Parse(allRegionDigits[i]);
                egn.Append(regionDigit);
                if (gender == Gender.Male.ToString() && regionDigit % 2 == 0)
                {
                    egn.Append(ControlDigitFactory.GetControlDigit(egn.ToString()));
                }
                else
                {
                    egn.Append(ControlDigitFactory.GetControlDigit(egn.ToString()));
                }

                if (Validate(egn.ToString()))
                {
                    allValidEgn.Add(egn.ToString());
                    egn.Clear();
                    continue;
                }
            }

            return allValidEgn;
        }

        public bool Validate(string egn)
        {
            bool isValid = true;
            if (egn == null)
            {
                isValid = false;
            }
            if (egn.Length != 10)
            {
                isValid = false;
            }
            if (!long.TryParse(egn, out _))
            {
                isValid = false;
            }

            long digitEgn = long.Parse(egn);
            int month = ((int)digitEgn / 1_000_000) % 100;
            int day = ((int)digitEgn / 10_000) % 100;

            if (month <= 0 || month > 52)
            {
                isValid = false;
            }
            if (day <= 0 || day > 31)
            {
                isValid = false;
            }

            if (int.Parse(ControlDigitFactory.GetControlDigit((digitEgn / 10).ToString())) != (digitEgn % 10))
            {
                isValid = false;
            }
            return isValid;
        }
        private static void CityValidation(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException("Variable city can't be null or empty");
            }

            if (!RegionFactory.RegionValidation(city))
            {
                throw new ArgumentException($"{city} is unrecognizable city");
            }
        }

        private static void BirthdateValidation(DateTime birthDate)
        {
            if (birthDate == DateTime.MinValue)
            {
                throw new ArgumentNullException("Variable birthDate can't be null");
            }
            if (birthDate.Year < 1800 || birthDate.Year > 2099)
            {
                throw new ArgumentOutOfRangeException("The year should be in range[1800-2099]");
            }
            if (birthDate.Month < 1 || birthDate.Month > 12)
            {
                throw new ArgumentOutOfRangeException("The month should be in range[1-12]");
            }
            if (birthDate.Month < 1 || birthDate.Month > 31)
            {
                throw new ArgumentOutOfRangeException("The day should be in range[1-31]");
            }
        }    
    }
}
