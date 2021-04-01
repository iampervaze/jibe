using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.API.Models
{
   public class OperationResult
    {
        public double Result { get; set; }
    }

    public class OperationResultWithColor : OperationResult
    {
        public OperationResultWithColor(OperationResult result)
        {
            Result = result.Result;
        }
        public string Color { get; set; }
    }
}
