using Calculator.API.Calculators;
using Calculator.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.API.Managers
{
    public class CalculatorManager
    {
        private readonly Dictionary<string, ICalculation> _calculators;
        public CalculatorManager(Dictionary<string, ICalculation> calculators)
        {
            _calculators = calculators;
        }

        public virtual OperationResult Calculate(Operations operations)
        {
            var operation = operations.Operation;
            var result = new OperationResult() { Result = operation.Operand };
            
            while (operation.Next != null)
            {
                if(!this._calculators.TryGetValue(operation.OperationType, out ICalculation calculator))
                {
                    throw new InvalidOperationException($"Operation '{operation.OperationType}'");
                }

                result.Result = calculator.Calculate(result.Result, operation.Next.Operand);
                operation = operation.Next;
            }

            return result; 
        }

        public OperationResult CalculateWithColor(Operations operations)
        {
            var baseResult = Calculate(operations) ;
            var newResult = new OperationResultWithColor(baseResult);
            newResult.Color = newResult.Result % 2 == 0 ? "green" : "red";
            return newResult;
        }
    }
}