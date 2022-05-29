using System;
using System.Collections.Generic;

namespace EgnValidation
{
    public interface IEgnValidator
    {
        bool Validate(string egn);
        List<string> Generate(DateTime birthDate, string city, bool isMale);
    }
}