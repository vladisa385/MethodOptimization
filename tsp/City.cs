
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tsp
{
    /// <summary>
    /// An individual City in our tour.
    /// </summary>
    public class City
    {
        /// <summary>
        /// Constructor that provides the city location.
        /// </summary>
        /// <param name="x">X position of the city.</param>
        /// <param name="y">Y position of the city.</param>
        public City(int x, int y)
        {
            Location = new Point(x, y);
        }

        /// <summary>
        /// Private copy of the location of this city.
        /// </summary>
        private Point location;
        /// <summary>
        /// The location of this city.
        /// </summary>
        public Point Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        /// <summary>
        /// Private copy of the distance from this city to every other city.
        /// The index in this array is the number of the city linked to.
        /// </summary>
        private List<double> distances = new List<double>();
        /// <summary>
        /// The distance from this city to every other city.
        /// </summary>
        public List<double> Distances
        {
            get
            {
                return distances;
            }
            set
            {
                distances = value;
            }
        }

        /// <summary>
        /// Private copy of the list of the cities that are closest to this one.
        /// </summary>
        private List<int> closeCities = new List<int>();
        /// <summary>
        /// A list of the cities that are closest to this one.
        /// </summary>
        public List<int> CloseCities
        {
            get
            {
                return closeCities;
            }
        }

        /// <summary>
        /// Find the cities that are closest to this one.
        /// </summary>
        /// <param name="numberOfCloseCities">When creating the initial population of tours, this is a greater chance
        /// that a nearby city will be chosen for a link. This is the number of nearby cities that will be considered close.</param>
        public void FindClosestCities( int numberOfCloseCities )
        {
            double shortestDistance;
            int shortestCity = 0;
            double[] dist = new double[Distances.Count];
            Distances.CopyTo(dist);

            if (numberOfCloseCities > Distances.Count - 1)
            {
                numberOfCloseCities = Distances.Count - 1;
            }

            closeCities.Clear();

            for (int i = 0; i < numberOfCloseCities; i++)
            {
                shortestDistance = Double.MaxValue;
                for (int cityNum = 0; cityNum < Distances.Count; cityNum++)
                {
                    if (dist[cityNum] < shortestDistance)
                    {
                        shortestDistance = dist[cityNum];
                        shortestCity = cityNum;
                    }
                }
                closeCities.Add(shortestCity);
                dist[shortestCity] = Double.MaxValue;
            }
        }
    }
}
