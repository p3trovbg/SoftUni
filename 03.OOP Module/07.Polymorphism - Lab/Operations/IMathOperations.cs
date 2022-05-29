using System;
using System.Collections.Generic;
using System.Text;

namespace Operations
{
    public interface IMathOperations
    {
        int Add(int a, int b);
        double Add(double a, double b, double c);
        decimal Add(decimal a, decimal b, decimal c);  
    }
}
