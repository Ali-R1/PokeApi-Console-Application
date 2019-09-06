using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApi
{
    class PokeItem
    {

    public string Name { get; set; }
    public string Sprite { get; set; }
    public string pokemonType { get; set; }
    public string pokedexID { get; set; }

        public PokeItem(string name, string sprite, string type, string pokedexid )
        {
            Name = name;
            Sprite = sprite;
            pokemonType = type;
            pokedexID = pokedexid;
           
        }

        public class Type
        {
            public string name { get; set; }
            public string url { get; set; }
        }


    }
}
