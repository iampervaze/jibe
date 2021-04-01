using Calculator.API.Calculators;
using Calculator.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.API.Managers
{
    public class CalculatorManagerWithColor: CalculatorManager
    {
        public CalculatorManagerWithColor(Dictionary<string, ICalculation> calculators) : base(calculators)
        {
        }

        public override OperationResult Calculate(Operations operations)
        {
            var baseResult = base.Calculate(operations);
            var newResult = new OperationResultWithColor(baseResult);
            newResult.Color = newResult.Result % 2 == 0 ? "green" : "red";
            return newResult;
        }
    }
}