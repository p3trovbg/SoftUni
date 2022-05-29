using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MoovIt
{
    public class MoovIt : IMoovIt
    {
        Dictionary<string, Route> routes = new Dictionary<string, Route>();
        public int Count => routes.Count;

        public void AddRoute(Route route)
        {
            if(routes.ContainsKey(route.Id))
            {
                throw new ArgumentException();
            }
            routes.Add(route.Id, route);
        }

        public void ChooseRoute(string routeId)
        {
            if(!routes.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }
            routes[routeId].Popularity++;
        }

        public bool Contains(Route route)
        {
            bool flag = false;
            if (routes.ContainsKey(route.Id))
            {
                flag = true;
            }

            var result = routes
                .FirstOrDefault(x => x.Value.Distance == route.Distance && x.Value.Popularity == route.Popularity && x.Value.IsFavorite == route.IsFavorite);
            if(result.Value != null)
            {
                flag = true;
            }
            return flag;
        }

        public IEnumerable<Route> GetFavoriteRoutes(string destinationPoint)
        {
            return routes.Values
                .Where(x => x.IsFavorite == true && x.LocationPoints.Contains(destinationPoint))
                .OrderBy(x => x.Distance).ThenByDescending(x => x.Popularity);
        }

        public Route GetRoute(string routeId)
        {
            if(!routes.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }
            return routes[routeId];
        }

        public IEnumerable<Route> GetTop5RoutesByPopularityThenByDistanceThenByCountOfLocationPoints()
        {
            return routes.Values.OrderByDescending(x => x.Popularity).ThenBy(x => x.Distance).ThenBy(x => x.LocationPoints.Count).Take(5);
            //returns the top 5 of the Routes in terms of popularity in descending order,
            //then by Distance in ascending order and then by count of location points in ascending order. 
        }

        public void RemoveRoute(string routeId)
        {
            if (!routes.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }

            routes.Remove(routeId);
        }

        public IEnumerable<Route> SearchRoutes(string startPoint, string endPoint)
        {
            var result = new Dictionary<Route, int>();
            int counter = 0;
            foreach (var route in routes.Values)
            {
                if (route.LocationPoints.Contains(startPoint) && route.LocationPoints.Contains(endPoint))
                {
                    for (int i = 0; i < route.LocationPoints.Count; i++)
                    {
                        if (route.LocationPoints[i] == startPoint)
                        {
                            counter = i;
                        }
                        if (route.LocationPoints[i] == endPoint)
                        {
                            counter = i - counter;
                        }
                    }
                    result.Add(route, counter);
                }
            }
            result = result
                .OrderBy(x => x.Key.IsFavorite)
                .OrderBy(x => x.Value)
                .ThenByDescending(x => x.Key.Popularity).ToDictionary(x => x.Key, x => x.Value);
            return result.Keys;
        }
    }
}
