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


            var q = File.ReadAllText(@"..\..\..\TestData.txt");

            var calculateMatch = new CalculatedMatches(q);
            Team selectedTeam = calculateMatch.GetResults("Manchester United");
            Console.WriteLine(selectedTeam);
        }
    }
}

    

