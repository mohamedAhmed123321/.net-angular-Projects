using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperationGame.Bl
{
    class LevelOne : IMathOperatorLevel
    {
        public int LevelStart { get; } = 0;

        public int LevelEnd { get; } = 10;

        public int OperatorCount { get; } = 1;

        public int RightAnswerCount { get; } = 5;

        public int WrongAnswerCount { get; } = 3;
        public int LevelNumber { get } = 1;

        public IMathOperatorLevel GetNextLevel(int rightCount, int wrongCount)
        {
            LevelStatus status = LevelStatus.InProgress;
            if (rightCount == RightAnswerCount)
            {
                Console.WriteLine("Level Pormoted");
                status = LevelStatus.Pormoted;
                return new LevelTow();
            }

            if (wrongCount == WrongAnswerCount)
            {
                Console.WriteLine("Game Over");
                status = LevelStatus.GameOver;
            }
            return new LevelOne();

        }

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
