using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace PokeApi
{
    class PokemonTCG_API
    {

        public static  async void GetPokemonCards()
        {
            //Define your baseUrl
            string baseUrl = "https://api.pokemontcg.io/v1/cards?name=beedrill"; // Need to add the data from the first api
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
