using System;

namespace AlbertslundForsyning.Entities
{
    public class DataReading
    {
        public int DataReadingId {get; set;}
        public DateTime Date {get; set;}
        public double HeatUsage {get; set;}
        public double WaterUsage {get; set;}
        public double TemperatureIn {get; set;}
        public double TemperatureOut {get; set;}
        public User User {get; set;}

        public override string ToString(){  
        return Date + " : " + HeatUsage + " : " + WaterUsage + " : " + TemperatureIn + " : " + TemperatureOut;
    }

    } 
}