using RESTfulGoogleMapsDirectionsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestServicesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectionsClient client = new DirectionsClient();
            DirectionsRequest request = new DirectionsRequest()
            {
                apiKey = "AIzaSyAeEDEH29MkmyGC3eJFRpZhg3Si8qUUM-c",
                origin = "Okeechobee,FL",
                destination = "West Palm Beach,FL"
            };
            var response = client.GetDirections(request,false);
            if(client.LastException?.Message != null)
            {
                Console.WriteLine(client.LastException.Message);
            }
            else
            {
                if(response != null)
                {
                    Console.WriteLine($"Status: {response["status"]}");
                    DisplayRoutes(response);
                }
            }
            Console.ReadLine();
        }

        private static void DisplayRoutes(dynamic response)
        {
            foreach (var route in response["routes"])
            {
                Console.WriteLine($"\r\nRoute Summary: {route["summary"]}");
                DisplayRouteLegs(route);
            }
        }

        private static void DisplayRouteLegs(dynamic route)
        {
            foreach (var leg in route["legs"])
            {
                Console.WriteLine($"Route Distance: {leg["duration"]["text"]} ; Duration: {leg["distance"]["text"]}");
                DisplayLegSteps(leg);
            }
        }

        private static void DisplayLegSteps(dynamic leg)
        {
            foreach (var step in leg["steps"])
            {
                Console.WriteLine($"\r\n\t{step["html_instructions"]}");
                Console.WriteLine($"\t{step["travel_mode"]} {step["duration"]["text"]} ; Duration: {step["distance"]["text"]}");
            }
        }
    }
}
