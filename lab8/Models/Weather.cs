using System;

namespace lab8.Models
{
    class Weather
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public DateTime Date { get; set; }
        public int Temperature { get; set; }
        public bool Rainfall { get; set; }
    }
}
