using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SamplesForDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            var sw = new Stopwatch();

            List<Figure> figuresList = new List<Figure>();
            for (int i = 1; i <= 100000; i++)
            {
                figuresList.Add(new Figure { Name = $"Figure{i}", SideCount = rand.Next(1, 5), SideLength = rand.Next(1, 3) });

            }

            sw.Start();

            //Поиск в списке
            var f = FindFigureFromList(figuresList, "Figure348");
            Console.WriteLine($"{f.Name} sideCount {f.SideCount}  SideLength {f.SideLength}");
            sw.Stop();
            Console.WriteLine($"Операция заняла {sw.Elapsed} ms");

            

            Dictionary<Figure, string> figuresDic = new Dictionary<Figure, string>();


            for (int i = 1; i <= 100000; i++)
            {
                figuresDic.Add(new Figure() { Name = $"Figure{i}", SideCount = rand.Next(1, 5), SideLength = rand.Next(1, 3) }, $"Figure{i}_Description");
               
            }


            sw.Start();
            //Поиск в словаре
            var fd = FindFigureFromDict(figuresDic, "Fugure349");
            Console.WriteLine(fd.Keys);
            
            sw.Stop();
            Console.WriteLine($"Операция заняла {sw.Elapsed} ms");

        }



        public static Dictionary<Figure, string> FindFigureFromDict(Dictionary<Figure, string> dic, string name)
        {
            Dictionary<Figure, string> result = new Dictionary<Figure, string>();
            var find =
               from f in dic
               where f.Key.Name == name
               select f;
            foreach (var item in find)
            {
                result.Add(new Figure
                {
                    Name = item.Key.Name,
                    SideCount = item.Key.SideCount,
                    SideLength = item.Key.SideLength
                }, item.Value);
                Console.WriteLine($"{item.Key.Name} sideCount {item.Key.SideCount}  SideLength {item.Key.SideLength}");
            }
            return result;
        }




        public static Figure FindFigureFromList(List<Figure> list, string name)
        {
            return
                (from f in list
                 where f.Name == name
                 select f).FirstOrDefault();
        }
    }
}
