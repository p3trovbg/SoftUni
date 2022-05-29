using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string CollectGettersAndSetters(string nameOfClass)
        {
            Type typeClass = Type.GetType(nameOfClass);
            var allMethods = typeClass
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                .Where(x => x.Name.StartsWith("get") || x.Name.StartsWith("set"));
            var sb = new StringBuilder();
            foreach (var methods in allMethods)
            {
                if (methods.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{methods.Name} will return {methods.ReturnType}");
                }
                else
                {
                    sb.AppendLine($"{methods.Name} will set field of {methods.ReturnParameter}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public string StealFieldInfo(string nameOfClass, params string[] array)
        {
            Type typeClass = Type.GetType(nameOfClass);
            var sb = new StringBuilder();
            FieldInfo[] fieldInfo =
                typeClass
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            sb.AppendLine($"Class under investigation: {nameOfClass}");
            foreach (var field in fieldInfo.Where(x => array.Contains(x.Name)))
            {
                sb.AppendLine
                    (
                    $"{field.Name} = {field.GetValue(Activator.CreateInstance(typeClass, new object[] { }))}"
                    );
            }
            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            var typeClass = Type.GetType(className);
            var fields = typeClass.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            var getters = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var setters = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            var sb = new StringBuilder();
            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var getter in getters.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{getter.Name} have to be public!");
            }

            foreach (var setter in setters.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{setter.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {

            var typeClass = Type.GetType(className);
            var privateMethods = typeClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Instance);
            var sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {typeClass.Name}");
            sb.AppendLine($"Base Class: {typeClass.BaseType.Name}");
            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
