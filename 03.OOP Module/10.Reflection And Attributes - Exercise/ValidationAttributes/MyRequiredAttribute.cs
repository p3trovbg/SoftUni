﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool isValid(object obj)
        => obj != null;
    }
}
