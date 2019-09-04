using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApi
{
    class PokeItem
    {
    public string Name { get; set; }
    public string Url { get; set; }

    public string Species { get; set; }

        public PokeItem(string name, string species)
        {
            Name = name;
            Species = species;
           
        }

    }
}
