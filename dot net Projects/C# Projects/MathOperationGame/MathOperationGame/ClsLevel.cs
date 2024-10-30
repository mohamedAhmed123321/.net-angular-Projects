using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperationGame
{
    class ClsLevel
    {
        public int LevelStart { get; set; }
        public int LevelEnd { get; set; }
        public int OperatorCount { get; set; }
        public int RightAnswerCount { get; set; }
        public int WrongAnswerCount { get; set; }

        public MathOperator GetNextNumber()
        {
            Random myRandom = new Random();
            MathOperator currentNumbers;

            currentNumbers.FirstNumber = myRandom.Next(LevelStart, LevelEnd);
            currentNumbers.SecondNumber = myRandom.Next(LevelStart, LevelEnd);
            currentNumbers.Operator = currentNumbers.Operator = myRandom.Next(1, OperatorCount);
            return currentNumbers;
        }
    }
}
