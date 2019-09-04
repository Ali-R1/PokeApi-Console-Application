using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace PokeApi
{
    class Program
    {

        string selectedPokemon;

        static void Main(string[] args)
        {


            //Starting Greeting Messages.
            Console.WriteLine("Hello and Welcome to Ryan's Pokemon API Application");//Intro message to the user.
            string selectedPokemon = firstMethod();
            Console.WriteLine("--------Press Enter to load the TCG Cards-------------");
            Console.ReadLine();
            GetPokemonCards(selectedPokemon);
            Console.ReadLine();
            Console.WriteLine("---------------End of Application-----------------");






            Console.WriteLine("Loading information from second API...");


        }


       


     

        public static string firstMethod()
        {

            //Declaring method Variables
            Boolean loop = true;

            do
            {
                try
                {
                    Console.WriteLine("Please enter a pokedex id");//Tells the user to enter a integer value.
                    int pokedexID = int.Parse(Console.ReadLine());// Reads the value from the users input.


                    if (pokedexID < 1 || pokedexID > 807)//Input validation to make sure value is within the range of all the new pokemon - meltan - melmetal
                    {
                        Console.WriteLine("Please enter a value within 1 - 807");// This a message to warn the user of the acceptable range
                        return null;
                    }

                    //DO Method should close around here -- need to apply another message to user and read key.


                    Console.WriteLine("Loading information from api...");//Message to user.
                   String selectedPokemon = GetOnePokemon(pokedexID).Result.ToString();//Runs the first GET from the first API. Var pokedex is entered from the user input.
                    loop = false;
                    return selectedPokemon;












                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: Please only enter a integer value. (Whole numbers)");//Input validation
                    return null;
                }







            } while (loop.Equals(true));//Loops while the codition is true
            return null;
        }



        //PokeAPI Functions

        public static async void Get151Pokemon()
        {
            //Defining the Base URl
            string baseUrl = "http://pokeapi.co/api/v2/pokemon/?limit=151";
            //Try catch block
            try
            {
                
                using (HttpClient client = new HttpClient())
                {
                    
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        
                        using (HttpContent content = res.Content)
                        {
                            
                            var data = await content.ReadAsStringAsync();
                           
                            if (data != null)
                            {
                                
                                // Console.WriteLine("data------------{0}", data);
                                JObject parsed = JObject.Parse(data);
                                foreach (var pair in parsed)
                                {
                                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                                }



                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
        }

        public static async Task<string> GetOnePokemon(int pokeId)
        {
            //Define your base url
            string baseURL = $"http://pokeapi.co/api/v2/pokemon/{pokeId}/";
            //Have your api call in try/catch block.
            try
            {

                using (HttpClient client = new HttpClient())
                {

                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        
                        using (HttpContent content = res.Content)
                        {
                        
                            string data = await content.ReadAsStringAsync();
                        
                            if (data != null)
                            {
                                //Parses the data to a object
                                var dataObj = JObject.Parse(data);
                                //this will create a new instance of PokeItem, and string interpolate the name property to the JSON object.
                                //Which will convert it to a string, since each property value is a instance of JToken.
                                PokeItem pokeItem = new PokeItem(name: $"{dataObj["name"]}", species: $"{dataObj["species"]["url"]}");
                                //Log your pokeItem's name to the Console.
                                Console.WriteLine("Pokemon Name: {0} is great and is of species {1}", pokeItem.Name, pokeItem.Species);


                                // Add the Species in, and include within the template string below 


                                //Logs values into console
                                Console.WriteLine("Pokemon Name: {0}", pokeItem.Name);
                                return pokeItem.Name;



                            }
                            else
                            {
                                //If data is null log it into console.
                                Console.WriteLine("Data is null!");
                                return null;
                            }
                        }
                    }
                }
                //Catch any exceptions and log it into the console.
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }


        //PokemonTCG API Functions
        public static async void GetPokemonCards(string selectedPokemon)
        {
            
            string baseUrl = "https://api.pokemontcg.io/v1/cards?name="+ selectedPokemon; 
           
            try
            {
                
                using (HttpClient client = new HttpClient())
                {

                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {

                        using (HttpContent content = res.Content)
                        {

                            var data = await content.ReadAsStringAsync();

                            if (data != null)
                            {
                                //Now log your data in the console
                                //Console.WriteLine("data------------{0}", data);
                                JObject parsed = JObject.Parse(data);
                                foreach (var pair in parsed)
                                {
                                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                                }



                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
        }

    }


    




}
