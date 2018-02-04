using BingRouteWCFService;
using BingRouteWCFService.BingRouteService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingRouteTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
            Console.ReadLine();
        }
        static async Task MainAsync()
        {
            BingRouteClient client = new BingRouteClient();
            RouteRequest request = new RouteRequest()
            {
                Credentials = new Credentials()
                {
                    Token = "RequestTokenFromSite"
                },
                Waypoints = new Waypoint[]
                {
                    new Waypoint()
                    {
                        Description = "Okeechobee, FL"
                    },

                    new Waypoint()
                    {
                        Description = "West Palm Beach, FL"
                    }
                }
            };
            var result = await client.CalculateRouteAsync(request);
            if(client.LastException?.Message != null)
            {
                Console.WriteLine(client.LastException.Message);
            }else if(result != null)
            {
                Console.WriteLine($"Distance: {result.Result?.Summary?.Distance} ; Time in Seconds {result.Result?.Summary?.TimeInSeconds}"); 
                foreach(var leg in result?.Result?.Legs)
                {
                    if(leg != null)
                    {
                        Console.WriteLine(leg.Summary);
                        foreach(var itenary in leg.Itinerary)
                        {
                            Console.WriteLine(itenary.Text);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Error requesting route service");
            }
        }
    }
}
