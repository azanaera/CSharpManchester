using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CsharpManchester
{
    public class CalculatedMatches
    {
        private readonly string[] _matches;
        private readonly List<Team> _teams = new List<Team>();
        private readonly string _results;
        private ILoadData _data;

        public List<Team> Teams => _teams;

        public CalculatedMatches(string results)
        {
            _results = results ?? throw new ArgumentNullException(results);
            _matches = results.Split(",");
            RegisterTeams();
            CalculateScore();
        }

        public CalculatedMatches(ILoadData data,string path)
        {
            _data = data;
            _results = _data.FromTextFile(path) ?? throw new FileNotFoundException(path);
            _matches = _results.Split(",");
            RegisterTeams();
            CalculateScore();
        }
        //002 Calculate Score of each Team
        private void CalculateScore()
        {
            for (int i = 0; i < _matches.Length; i++) // 1st match
            {
                Team homeTeam = null, awayTeam = null;
                int homeScore = 0, awayScore = 0;

                for (int j = 0; j < Teams.Count; j++)
                {
                    if (_matches[i].TrimStart().Contains(Teams[j].Name,StringComparison.InvariantCulture))
                    {
                        int nameIndex = _matches[i].TrimStart().IndexOf(Teams[j].Name,StringComparison.InvariantCulture);
                        int scoreIndex = nameIndex + Teams[j].Name.Length;
                        int score = 0;

                        if (nameIndex > 0)
                        {
                            awayTeam = Teams[j];
                            bool team1HasScore = int.TryParse(_matches[i].TrimStart().Substring(scoreIndex), out score)
                                                ? true : throw new ArgumentException("A team's score cannot be null.");

                            awayScore = score;
                        }
                        else
                        {
                            homeTeam = Teams[j];
                            String partString = _matches[i].TrimStart().Substring(scoreIndex).Trim();
                            bool team2Hasscore = int.TryParse(partString.Substring(0, partString.IndexOf(' ',StringComparison.InvariantCulture)), out score) 
                                                ? true : throw new ArgumentException("A team's score cannot be null.");
                            homeScore = score;
                        }
                    }
                }

                awayTeam.GamesPlayed++;
                homeTeam.GamesPlayed++;

                homeTeam.GoalsScored += homeScore;
                awayTeam.GoalsScored += awayScore;

                homeTeam.GoalsConceded += awayScore;
                awayTeam.GoalsConceded += homeScore;

                if (homeScore > awayScore)
                {
                    homeTeam.Wins++;
                    awayTeam.Losses++;
                }
                else if (awayScore > homeScore)
                {
                    awayTeam.Wins++;
                    homeTeam.Losses++;
                }
                else
                {
                    homeTeam.Draws++;
                    awayTeam.Draws++;
                }
            }
        }
        //001 Convert to List of Teams
        private List<Team> RegisterTeams()
        {
            var matches = _results.Split(",");

            for (int i = 0; i < matches.Length; i++)
            {
                // index of first team - name + score
                var teamOneIndexEnd = matches[i].IndexOfAny("0123456789".ToCharArray());
                // index of 2nd team - name + score
                var teamTwoIndexEnd =
                    matches[i].Substring(teamOneIndexEnd + 1).IndexOfAny("0123456789".ToCharArray());
                //team name
                var team1 = matches[i].Substring(0, teamOneIndexEnd).Trim();
                var team2 = matches[i].Substring(teamOneIndexEnd + 1, teamTwoIndexEnd).Trim();
                if (!Teams.Where(t => t.Name == team1).Any())
                {
                    Teams.Add(new Team { Name = team1 });
                }
                if(!Teams.Where(t => t.Name == team2).Any())
                {
                    Teams.Add(new Team { Name = team2 });
                }
            }
            return Teams;
        }

        public Team GetResults(string selectedName)
        {
            return Teams.Where(t => t.Name == selectedName).FirstOrDefault();
        }

        public bool HasTeamsRegistered()
        {
            return Teams.Count >= 1;
        }
    } // end class
}
