using System;
using System.Collections.Generic;
using System.Linq;

namespace FootBallApp
{
    #region Team Information
    // team information
    public struct Team
    {
        public string TeamName;
        public int NumberOfWins;
        public int NumberOfDraws;
        public int NumberOfLoses;
        public int Points;
    }
    #endregion

    class Program
    {
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        static void PrintMessage(string message)
        {
            Console.WriteLine("*************************");
            Console.WriteLine(message);
            Console.WriteLine("*************************");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        static void PrintMessage(string message, int messageType)
        {
            if (messageType == 1)
            {
                Console.WriteLine("*************************");
                Console.WriteLine(message);
                Console.WriteLine("*************************");
            }
            else
            {
                Console.WriteLine("//////////////////////////");
                Console.WriteLine(message);
                Console.WriteLine("//////////////////////////");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        static bool CheckNumber(string data, out int num)
        {
            bool bIsValidNumber = int.TryParse(data, out num);
            if (!bIsValidNumber)
            {
                PrintMessage("please enter a valid number");
                num = 0;
                return false;
            }
            return true;
        }
        static int IsValid()
        {
            int Number;
            bool IsValid;
            while (true)
            {
                IsValid = CheckNumber(Console.ReadLine(), out Number);
                if (IsValid)
                    break;
            }


            return Number;
        }
        #endregion
        static void Main(string[] args)
        {
            // welcome user
            PrintMessage("Welcome to football application");

            List<ClsTeam> lstTeams = new List<ClsTeam>();
            char loopIndex = 'a';
            ClsTeam myTeam = new ClsTeam();
            // loop over number of teams
            while (loopIndex != 'e')
            {
                // intilize values
                myTeam = new ClsTeam();


                // read team information
                PrintMessage("please enter team name");
                myTeam.TeamName = Console.ReadLine();

                PrintMessage("please enter number of Games");
                myTeam.NumberOfGames = IsValid();

                PrintMessage("please enter number of wins");
                myTeam.NumberOfWins = IsValid();



                PrintMessage("please enter number of draws");
                myTeam.NumberOfDraws = IsValid();



                PrintMessage("please enter number of loses");
                myTeam.NumberOfLoses = IsValid();

                PrintMessage("please enter number of Scored Goals");
                myTeam.ScoredGoals = IsValid();

                PrintMessage("please enter number of Receiving Goals ");
                myTeam.ReceivingGoals = IsValid();
                // calculate points
                myTeam.Points = (myTeam.NumberOfWins * 3) + (myTeam.NumberOfDraws * 1);
                myTeam.GoalDifference = myTeam.ScoredGoals - myTeam.ReceivingGoals;
                // store team data in list
                lstTeams.Add(myTeam);
                PrintMessage("for exisit press e else press any key");
                loopIndex = Convert.ToChar(Console.ReadLine());
            }
            int CountLoop = lstTeams.Count();
            for (int i = 1; i <= CountLoop; i++)
            {
                int maxPoints = lstTeams.Max(x => x.Points);
                int MaxGoalDifference = lstTeams.Max(x => x.GoalDifference);
                var RankingTeams = lstTeams.Where(a => a.Points == maxPoints);
                if (RankingTeams.Count() > 1)
                    RankingTeams = RankingTeams.Where(a => a.GoalDifference == MaxGoalDifference);
              var MySortedTeam=  RankingTeams.FirstOrDefault();
                Console.WriteLine(i + ")  " + MySortedTeam.TeamName + " played " + MySortedTeam.NumberOfGames + " wins " + MySortedTeam.NumberOfWins + " draws " + MySortedTeam.NumberOfDraws+" loses "+ MySortedTeam.NumberOfLoses+" scored goals " + MySortedTeam.ScoredGoals+" receving goals "+ MySortedTeam.ReceivingGoals+" Goal Difference "+ MySortedTeam.GoalDifference+" Points "+ MySortedTeam.Points);
                lstTeams.Remove(MySortedTeam);
            }

            Console.ReadKey();
        }
    }
}
