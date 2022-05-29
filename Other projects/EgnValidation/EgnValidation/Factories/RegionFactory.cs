using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgnValidation
{
    public class RegionFactory
    {
        public static bool RegionValidation(string region)
        {
            bool isValid = false;

            switch (region)
            {
                case "Благоевград":
                    isValid = true;
                    break;
                case "Бургас":
                    isValid = true;
                    break;
                case "Варна":
                    isValid = true;
                    break;
                case "Велико Търново":
                    isValid = true;
                    break;
                case "Видин ":
                    isValid = true;
                    break;
                case "Враца":
                    isValid = true;
                    break;
                case "Габрово":
                    isValid = true;
                    break;
                case "Кърджали":
                    isValid = true;
                    break;
                case "Кюстендил":
                    isValid = true;
                    break;
                case "Ловеч":
                    isValid = true;
                    break;
                case "Монтана":
                    isValid = true;
                    break;
                case "Пазарджик":
                    isValid = true;
                    break;
                case "Перник":
                    isValid = true;
                    break;
                case "Плевен":
                    isValid = true;
                    break;
                case "Пловдив":
                    isValid = true;
                    break;
                case "Разград ":
                    isValid = true;
                    break;
                case "Русе ":
                    isValid = true;
                    break;
                case "Силистра":
                    isValid = true;
                    break;
                case "Сливен":
                    isValid = true;
                    break;
                case "Смолян ":
                    isValid = true;
                    break;
                case "София - град":
                    isValid = true;
                    break;
                case "София – окръг":
                    isValid = true;
                    break;
                case "Стара Загора":
                    isValid = true;
                    break;
                case "Добрич":
                    isValid = true;
                    break;
                case "Търговище":
                    isValid = true;
                    break;
                case "Хасково":
                    isValid = true;
                    break;
                case "Шумен":
                    isValid = true;
                    break;
                case "Ямбол":
                    isValid = true;
                    break;
                case "Друг":
                    isValid = true;
                    break;
                case "Неизвестен":
                    isValid = true;
                    break;
            }
            return isValid;
        }
    }
}
