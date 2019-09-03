using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApi
{
    class PokeItem
    {
    public string Name { get; set; }
    public string Url { get; set; }

        public PokeItem(string name)
        {
            Name = name;
           
        }

    }
}
