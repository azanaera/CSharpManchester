using CsharpManchester;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace CsharpManchester
{
    public class Program
    {
        static void Main(string[] args)
        {
            var path = GetStringResultFromFile(args[0]);

            var calculateMatch = new CalculatedMatches(path);
            Team selectedTeam = calculateMatch.GetResults("Manchester United");
            Console.WriteLine(selectedTeam);
        }

        static string GetStringResultFromFile(string path)
        {
            if (path == null) throw new ArgumentNullException("The file directory cannot be empty.",path);
            return File.Exists(path) ? File.ReadAllText(path) : throw new FileNotFoundException("The file doesnt exist.",path);
        }
    }
}

    

