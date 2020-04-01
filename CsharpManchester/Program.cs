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
            var path = GetStringResultFromFile(args[1]);

            var calculateMatch = new CalculatedMatches(path);
            Team selectedTeam = calculateMatch.GetResults("Arsenal");
            Console.WriteLine(selectedTeam);
        }

        static string GetStringResultFromFile(string path)
        {
            if (path == null) throw new ArgumentNullException(path);
            return File.ReadAllText(path) ?? throw new FileNotFoundException(path);
        }
    }
}

    

