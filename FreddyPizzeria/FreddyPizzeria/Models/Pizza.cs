using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreddyPizzeria.Models
{
    public class Pizza
    {
        //Defining the attributes to the pizza

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGlutenFree { get; set; }
        //Thought about adding flavor and size, but it would be useless, because it would be already in the name of the pizza xD
    }
}
