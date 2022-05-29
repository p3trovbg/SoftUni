using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgnValidation
{
    public class RegionDigitsFactory
    {
        public static List<string> RangeDigitForCurrentRegion(string region, string gender)
        {
            int[] range = new int[2];
            switch (region)
            {
                case "Благоевград":
                    range[0] = 0;
                    range[1] = 43;
                    break;
                case "Бургас":
                    range[0] = 44;
                    range[1] = 93;
                    break;
                case "Варна":
                    range[0] = 94;
                    range[1] = 139;
                    break;
                case "Велико Търново":
                    range[0] = 140;
                    range[1] = 169;
                    break;
                case "Видин ":
                    range[0] = 170;
                    range[1] = 183;
                    break;
                case "Враца":
                    range[0] = 184;
                    range[1] = 217;
                    break;
                case "Габрово":
                    range[0] = 218;
                    range[1] = 233;
                    break;
                case "Кърджали":
                    range[0] = 234;
                    range[1] = 281;
                    break;
                case "Кюстендил":
                    range[0] = 282;
                    range[1] = 301;
                    break;
                case "Ловеч":
                    range[0] = 302;
                    range[1] = 319;
                    break;
                case "Монтана":
                    range[0] = 320;
                    range[1] = 341;
                    break;
                case "Пазарджик":
                    range[0] = 342;
                    range[1] = 377;
                    break;
                case "Перник":
                    range[0] = 378;
                    range[1] = 395;
                    break;
                case "Плевен":
                    range[0] = 396;
                    range[1] = 435;
                    break;
                case "Пловдив":
                    range[0] = 436;
                    range[1] = 501;
                    break;
                case "Разград ":
                    range[0] = 502;
                    range[1] = 527;
                    break;
                case "Русе ":
                    range[0] = 528;
                    range[1] = 555;
                    break;
                case "Силистра":
                    range[0] = 556;
                    range[1] = 575;
                    break;
                case "Сливен":
                    range[0] = 576;
                    range[1] = 601;
                    break;
                case "Смолян ":
                    range[0] = 602;
                    range[1] = 623;
                    break;
                case "София - град":
                    range[0] = 624;
                    range[1] = 721;
                    break;
                case "София – окръг":
                    range[0] = 722;
                    range[1] = 751;
                    break;
                case "Стара Загора":
                    range[0] = 752;
                    range[1] = 789;
                    break;
                case "Добрич":
                    range[0] = 790;
                    range[1] = 821;
                    break;
                case "Търговище":
                    range[0] = 822;
                    range[1] = 843;
                    break;
                case "Хасково":
                    range[0] = 844;
                    range[1] = 871;
                    break;
                case "Шумен":
                    range[0] = 872;
                    range[1] = 903;
                    break;
                case "Ямбол":
                    range[0] = 904;
                    range[1] = 925;
                    break;
                case "Друг":
                case "Неизвестен":
                    range[0] = 926;
                    range[1] = 999;
                    break;              
            }

            List<string> allValidDigits = new List<string>();
            for (int i = range[0]; i < range[1]; i++)
            {
                string digits = $"{i:D3}".ToString();
                if (gender == Gender.Male.ToString() && i % 2 == 0)
                {
                    allValidDigits.Add(digits);
                }
                else if (gender == Gender.Female.ToString() && i % 2 != 0)
                {
                    allValidDigits.Add(digits);
                }
            }

            return allValidDigits;
        }
    }
}
