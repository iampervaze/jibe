using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.API.Calculators
{
    public class Division : ICalculation
    {
        public string OperationType => "/";
        public double Calculate(double a, double b) => a / b;
    }
}
