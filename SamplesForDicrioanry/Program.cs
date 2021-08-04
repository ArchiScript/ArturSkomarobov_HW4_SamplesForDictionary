using System;
using System.Collections.Generic;

namespace SamplesForDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Figure> figures = new Dictionary<string, Figure>()
            {
                {"Circle", new Figure() {SideCount =1 , SideLength = 1} },
                {"Square", new Figure( ){SideCount =1 , SideLength = 4} }
             };
            figures.Add("Triangle", new Figure() { SideCount = 3, SideLength = 1 });
            figures.ContainsKey("Triangle");

            var fig = figures["Triangle"];
            figures["Triangle"] = new Figure() { SideCount = 5, SideLength = 1 };
            figures.Remove("Triangle");
            foreach (var item in figures)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            foreach (var item in figures.Keys)
            {
                Console.WriteLine($"{item}");
            }

        }
    }
}
