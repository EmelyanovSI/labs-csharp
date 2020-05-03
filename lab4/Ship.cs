using System;

namespace lab4
{
    class Ship : Vehicle
    {
        private string port;
        private int capacity;

        public void setCapacity(int capacity)
        {
            this.capacity = capacity;
        }
        public void setPort(string port)
        {
            this.port = port;
        }
        public override string ToString()
        {
            return String.Format("Ship[position: ({0},{1}), speed: {2}, year: {3}, cost: {4:f2}, port: {5}, capacity: {6}]",
                coordinateX, coordinateY, speed, year, cost, port, capacity);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), port, capacity);
        }
        public override bool Equals(object obj)
        {
            return obj is Ship ship &&
                   base.Equals(obj) &&
                   port == ship.port &&
                   capacity == ship.capacity;
        }
    }
}
