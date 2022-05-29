using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (var info in properties)
            {
                var attributes = info.GetCustomAttributes()
                    .Where(x => x.GetType().IsSubclassOf(typeof(MyValidationAttribute)));
                foreach (MyValidationAttribute attribute in attributes)
                {
                    bool isValid = attribute.isValid(info.GetValue(obj));
                    if (isValid == false)
                    {
                        return isValid;
                    }
                }
            }
            return true;
        }
    }
}
