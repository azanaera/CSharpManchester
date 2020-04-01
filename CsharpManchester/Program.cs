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
            string results = "Manchester United 1 Chelsea 0,Arsenal 1 Manchester United 1,Manchester United 3 Fulham 1,Liverpool 2 Manchester United 1,Swansea 2 Manchester United 4";


            var path = File.ReadAllText(args[0]);

            var calculateMatch = new CalculatedMatches(path);
            Team selectedTeam = calculateMatch.GetResults("Manchester United");
            Console.WriteLine(selectedTeam);
        }
    }
}

    

