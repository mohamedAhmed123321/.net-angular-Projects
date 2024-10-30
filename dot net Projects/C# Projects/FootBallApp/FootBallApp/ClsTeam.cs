using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallApp
{
    public class ClsTeam
    {

        public string TeamName { get; set; }
        public int NumberOfGames { get; set; }
        public int NumberOfWins { get; set; }
        public int NumberOfDraws { get; set; }
        public int NumberOfLoses { get; set; }
        public int ReceivingGoals { get; set; }
        public int ScoredGoals { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }

    }
}
