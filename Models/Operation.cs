using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.API.Models
{
    public class Operation
    {
        public double Operand { get; set; }
        public string OperationType { get; set; }
        public Operation Next { get; set; }
    }
}
