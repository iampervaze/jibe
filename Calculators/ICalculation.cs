using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.API.Calculators
{
    public interface ICalculation
    {
        string OperationType { get; }
        double Calculate(double a, double b);
    }
}
