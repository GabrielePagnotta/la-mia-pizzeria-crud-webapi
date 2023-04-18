using la_mia_pizzeria_static.Controllers;
using la_mia_pizzeria_static.Models;
using MessagePack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly DbPizzaContext _context;
        public PizzaController(DbPizzaContext context)
        {
            _context = context;
        }
        public IActionResult GetPizza()
        {
            IQueryable<Pizza> pizzas = _context.Pizzas;
            return Ok(pizzas);
        }
        [HttpGet("{id}")]
        public IActionResult GetPizzasId(int id) 
        {
            var pizzaId = _context.Pizzas.FirstOrDefault(p => p.Id == id);

            if(pizzaId is null) 
            {
                return NotFound();
            }
                return Ok(pizzaId);
            
            
        }

        [HttpPost]
        public IActionResult CreatePizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }

        [HttpPut("{id}")]
        public IActionResult PutPizzas(int id, [FromBody] Pizza pizza)
        {
            var savePizza = _context.Pizzas.FirstOrDefault(p => p.Id == id);

            if (savePizza is null)
            {
                return NotFound();
            }
            savePizza.Name = pizza.Name;
            savePizza.Description = pizza.Description;
            savePizza.Price = pizza.Price;
            savePizza.Image = pizza.Image;
            savePizza.CategoryId = pizza.CategoryId;
            
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            var savePizza = _context.Pizzas.FirstOrDefault(p => p.Id == id);

            if (savePizza is null)
            {
                return NotFound();
            }
            _context.Remove(savePizza);
            _context.SaveChanges();
            return Ok();
        }
    }
}
