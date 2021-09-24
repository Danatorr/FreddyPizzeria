using ContosoPizza.Services;
using FreddyPizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreddyPizzeria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }

        //Get (all)
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        //Get (by Id)
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null) return NotFound($"A pizza with the id: {id} could not be found!");

            return pizza;
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }

        [HttpPut]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id) return BadRequest();

            var existingPizza = PizzaService.Get(id);

            if (existingPizza is null) return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null) return NotFound($"The pizza with id {id} could not be found!");

            PizzaService.Delete(id);

            return NoContent();
        }
    }
}
