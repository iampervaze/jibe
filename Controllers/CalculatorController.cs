using Calculator.API.Calculators;
using Calculator.API.Managers;
using Calculator.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly Func<string, CalculatorManager> _calculatorManager;
        public CalculatorController(Func<string,CalculatorManager> calculatorManager)
        {
            _calculatorManager = calculatorManager;
        }

        [HttpPost]
        public IActionResult Calculate([FromBody] Operations operations)
        {
            var calculationManager = _calculatorManager(operations.ResultType);
            if (calculationManager == null)
            {
                return BadRequest($"Calculation Manager for ResultType '{operations.ResultType}' Not Found!");
            }
            var response = calculationManager.Calculate(operations);
            return Ok(response);
        }
    }
}
