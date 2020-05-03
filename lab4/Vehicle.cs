using System;

namespace lab4
{
    abstract class Vehicle
    {
        public int coordinateX { get; set; }
        public int coordinateY { get; set; }
        public double cost { get; set; }
        public int speed { get; set; }
        public int year { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Vehicle vehicle &&
                   coordinateX == vehicle.coordinateX &&
                   coordinateY == vehicle.coordinateY &&
                   cost == vehicle.cost &&
                   speed == vehicle.speed &&
                   year == vehicle.year;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(coordinateX, coordinateY, cost, speed, year);
        }
    }
}
