using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace PokeApi
{
    class Program
    {
        static void Main(string[] args)
        {



            /////Scrapped Code...
            // Console.WriteLine("Loading infroamtion for the API!");
            //Console.WriteLine("Pick a poke id");
            //string pokeid = Console.ReadLine();
            //GetOnePokemon(pokeid);
            //Console.ReadLine();
            //Console.WriteLine("Press Any key to list all original 151 pokemon");
            //Get151Pokemon();
            //Console.ReadLine();


            //Declaring Variables
            Boolean loop = true;


            //Starting Greeting Messages.
            Console.WriteLine("Hello and Welcome to Ryan's Pokemon API Application");//Intro message to the user.
            

            do
             {
                try
                {
                    Console.WriteLine("Please enter a pokedex id");//Tells the user to enter a integer value.
                    int pokedexID = int.Parse(Console.ReadLine());// Reads the value from the users input.


                    if (pokedexID < 1 || pokedexID > 807)//Input validation to make sure value is within the range of all the new pokemon - meltan - melmetal
                    {
                        Console.WriteLine("Please enter a value within 1 - 807");// This a message to warn the user of the acceptable range

                    }

                    PokéAPI.GetOnePokemon(pokedexID);//Gets the one pokemon from the users input. 
                    Console.ReadLine();//Stops the code from running.







                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: Please only enter a integer value. (Whole numbers)");//Input validation

                }
            






        }while( loop.Equals(true));
    }


        public static async void Get151Pokemon()
        {
            //Define your baseUrl
            string baseUrl = "http://pokeapi.co/api/v2/pokemon/?limit=151";
            //Have your using statements within a try/catch block
            try
            {
                //We will now define your HttpClient with your first using statement which will use a IDisposable.
                using (HttpClient client = new HttpClient())
                {
                    //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        //Then get the content from the response in the next using statement, then within it you will get the data, and convert it to a c# object.
                        using (HttpContent content = res.Content)
                        {
                            //Now assign your content to your data variable, by converting into a string using the await keyword.
                            var data = await content.ReadAsStringAsync();
                            //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                            if (data != null)
                            {
                                //Now log your data in the console
                                Console.WriteLine("data------------{0}", data);
                           /**     JObject parsed = JObject.Parse(data);
                                foreach (var pair in parsed)
                                {
                                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                                }**/



                            }
                            else 
                            {
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            } catch(Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
        }


        public static async void GetOnePokemon(int pokeId)
        {
            //Define your base url
            string baseURL = $"http://pokeapi.co/api/v2/pokemon/{pokeId}/";
            //Have your api call in try/catch block.
            try
            {
                //Now we will have our using directives which would have a HttpClient 
                using (HttpClient client = new HttpClient())
                {
                    //Now get your response from the client from get request to baseurl.
                    //Use the await keyword since the get request is asynchronous, and want it run before next asychronous operation.
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        //Now we will retrieve content from our response, which would be HttpContent, retrieve from the response Content property.
                        using (HttpContent content = res.Content)
                        {
                            //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
                            string data = await content.ReadAsStringAsync();
                            //If the data is not null, parse the data to a C# object, then create a new instance of PokeItem.
                            if (data != null)
                            {
                                //Parse your data into a object.
                                var dataObj = JObject.Parse(data);
                                //Then create a new instance of PokeItem, and string interpolate your name property to your JSON object.
                                //Which will convert it to a string, since each property value is a instance of JToken.
                                PokeItem pokeItem = new PokeItem(name: $"{dataObj["name"]}");
                                //Log your pokeItem's name to the Console.
                                Console.WriteLine("Pokemon Name: {0}", pokeItem.Name);
                                Console.WriteLine("Pokemon URL: {0}", pokeItem.Url);
                            }
                            else
                            {
                                //If data is null log it into console.
                                Console.WriteLine("Data is null!");
                            }
                        }
                    }
                }
                //Catch any exceptions and log it into the console.
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }




    }
}
