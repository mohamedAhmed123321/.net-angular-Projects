﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperationGame.Bl
{
    class LevelThree :IMathOperatorLevel
    {
        public int LevelStart { get; } = 0;

        public int LevelEnd { get; } = 20;

        public int OperatorCount { get; } = 3;

        public int RightAnswerCount { get; } = 10;

        public int WrongAnswerCount { get; } = 4;
        public int LevelNumber { get } = 3;


        public IMathOperatorLevel GetNextLevel(int rightCount, int wrongCount)
        {
            LevelStatus status = LevelStatus.InProgress;
            if (rightCount == RightAnswerCount)
            {
                Console.WriteLine("Level Pormoted");
                status = LevelStatus.Pormoted;
                return new LevelFour();
            }

            if (wrongCount == WrongAnswerCount)
            {
                Console.WriteLine("Game Over");
                status = LevelStatus.GameOver;
            }
            return new LevelThree();

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
