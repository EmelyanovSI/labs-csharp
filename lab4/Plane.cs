using System;

namespace lab4
{
    class Plane : Vehicle
    {
        private int capacity;
        public void setCapacity(int capacity)
        {
            this.capacity = capacity;
        }
        public override string ToString()
        {
            return String.Format("Plane[position: ({0},{1}), speed: {2}, year: {3}, cost: {4:f2}, capacity: {5}]",
                coordinateX, coordinateY, speed, year, cost, capacity);
        }
        public override bool Equals(object obj)
        {
            return obj is Plane plane &&
                   base.Equals(obj) &&
                   capacity == plane.capacity;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), capacity);
        }
    }
}
