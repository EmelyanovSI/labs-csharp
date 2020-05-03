using System;

namespace lab4
{
    class Car : Vehicle
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return String.Format("Car[position: ({0},{1}), speed: {2}, year: {3}, cost: {4:f2}]",
                coordinateX, coordinateY, speed, year, cost);
        }
    }
}
