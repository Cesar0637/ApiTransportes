using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TransportesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet]
        [Route("suma")]
        public IActionResult Suma(double a, double b)
        {
            double resultado = a + b;
            return Ok(new { resultado });
        }
        [HttpGet]
        [Route("resta")]
        public IActionResult Resta(double a, double b)
        {
            double resultado = a - b;
            return Ok(new { resultado });
        }

        public class operadores
        {
            public double a { get; set; }
            public double b { get; set; }
        }
        [HttpPost]
        [Route("Multiplicacion")]
        public IActionResult Multiplicacion(operadores operador)
        {
            double resultado= operador.a*operador.b;
            return Ok(new { resultado });
        }       
        [HttpPost]
        [Route("Divicion")]
        public IActionResult Divicion (operadores operador)
        {
            double resultado= operador.a/operador.b;
            return Ok(new { resultado });
        }
    }
}
