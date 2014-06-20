using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carubbi.TSP
{
    public class City
    {
        public City()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        // The city's x coordinate.
        private int xcoord;

        // The city's y coordinate.
        private int ycoord;

        // x -- the city's x coordinate
        // y -- the city's y coordinate
        public City(int x, int y)
        {
            xcoord = x;
            ycoord = y;
        }

        public int getx()
        {
            return xcoord;
        }

        public int gety()
        {
            return ycoord;
        }

        // Returns the distance from the city to another city.
        public int proximity(City cother)
        {
            return proximity(cother.getx(), cother.gety());
        }

        // x -- the x coordinate
        // y -- the y coordinate
        // return The distance.
        public int proximity(int x, int y)
        {
            int xdiff = xcoord - x;
            int ydiff = ycoord - y;
            return (int)Math.Sqrt(xdiff * xdiff + ydiff * ydiff);
        }
    }
}
