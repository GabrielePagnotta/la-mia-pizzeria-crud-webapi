using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static
{
    [Route("api/Pizza")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IActionResult GetPizzas()
        {
            using (DbPizzaContext context = new DbPizzaContext())
            {
                IQueryable<Pizza> Pizzas = context.Pizzas;
                return Ok(Pizzas.ToList());
            }
        }
    }
}
