using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFrameworks.Classes;
using BingRouteWCFService.BingRouteService;

namespace BingRouteWCFService
{
    public class BingRouteClient : WebService
    {
        RouteServiceClient client = new RouteServiceClient();
        public BingRouteClient()
        {

        }
        RouteResponse CalculateRoute(RouteRequest request)
        {
            LastException = null;
            RouteResponse response = default(RouteResponse);
            try
            {
                try
                {
                    response = client.CalculateRoute(request);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception e)
            {
                LastException = e;
            }
            return response;
        }
        public Task<RouteResponse> CalculateRouteAsync(RouteRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                return CalculateRoute(request);
            });
        }

        MajorRoutesResponse CalculateRoutesFromMajorRoads(MajorRoutesRequest request)
        {
            LastException = null;
            MajorRoutesResponse response = default(MajorRoutesResponse);
            try
            {
                try
                {
                    response = client.CalculateRoutesFromMajorRoads(request);
                }catch(Exception ex)
                {
                    throw ex;
                }
            }catch(Exception e)
            {
                LastException = e;
            }
            return response;
        }
        public Task<MajorRoutesResponse> CalculateRoutesFromMajorRoadsAsync(MajorRoutesRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                return CalculateRoutesFromMajorRoads(request);
            });
        }
    }
}
