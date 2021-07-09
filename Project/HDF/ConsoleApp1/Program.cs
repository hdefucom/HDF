using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double d = 0;

            Person2 p = new();

            var date = DateTime.Now;

            var a = $"时间：【{date:h:mm tt} on {date:M/d/yyyy}】";



            Console.WriteLine("Hello World!");
        }



        public record Person(string FirstName, string LastName);


        public record Person2
        {

            public string FirstName { get; init; }
            public string LastName { get; init; }
        }
    }
    public struct WeatherObservation
    {
        public DateTime RecordedAt { get; init; }
        public decimal TemperatureInCelsius { get; init; }
        public decimal PressureInMillibars { get; init; }

        public override string ToString() =>
            $"At {RecordedAt:h:mm tt} on {RecordedAt:M/d/yyyy}: " +
            $"Temp = {TemperatureInCelsius}, with {PressureInMillibars} pressure";
    }















}
