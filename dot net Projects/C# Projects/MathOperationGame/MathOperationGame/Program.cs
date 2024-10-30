using System;
using MathOperationGame.Bl;
namespace MathOperationGame
{
    public struct MathOperator
    {
        public int FirstNumber;
        public int SecondNumber;
        public int Operator;
    }

    public enum LevelStatus
    {
        InProgress=1,
        Pormoted=2,
        GameOver=3
    }
    class Program
    {
        public static IMathOperatorLevel GetLevelObject(int levelNumber)
        {
            IMathOperatorLevel oIMathOperatorLevel = new LevelOne();
            switch (levelNumber)
            {
                case 1:
                    oIMathOperatorLevel = new LevelOne();
                    break;
                case 2:
                    oIMathOperatorLevel = new LevelTow ();
                    break;
                case 3:
                    oIMathOperatorLevel = new LevelThree();
                    break;
                case 4:
                    oIMathOperatorLevel = new LevelFour();
                    break;
                case 5:
                    oIMathOperatorLevel = new LevelIfe();
                    break;
            }
            return oIMathOperatorLevel;
        }

        //public static MathOperator GetNextNumber(int levelNumber, out ClsLevel oClsLevel)
        //{
        //    Random myRandom = new Random();
        //    MathOperator currentNumbers;

        //    oClsLevel = new ClsLevel();

        //    switch (levelNumber)
        //    {
        //        case 1:
        //            oClsLevel.LevelStart = 0;
        //            oClsLevel.LevelEnd = 10;
        //            oClsLevel.OperatorCount = 1;
        //            oClsLevel.WrongAnswerCount = 3;
        //            oClsLevel.RightAnswerCount = 5;
        //            break;
        //        case 2:
        //            oClsLevel.LevelStart = 0;
        //            oClsLevel.LevelEnd = 20;
        //            oClsLevel.OperatorCount = 2;
        //            oClsLevel.WrongAnswerCount = 3;
        //            oClsLevel.RightAnswerCount = 7;
        //            break;
        //        case 3:
        //            oClsLevel.LevelStart = 0;
        //            oClsLevel.LevelEnd = 20;
        //            oClsLevel.OperatorCount = 3;
        //            oClsLevel.WrongAnswerCount = 4;
        //            oClsLevel.RightAnswerCount = 10;
        //            break;
        //        case 4:
        //            oClsLevel.LevelStart = 0;
        //            oClsLevel.LevelEnd = 30;
        //            oClsLevel.OperatorCount = 3;
        //            oClsLevel.WrongAnswerCount = 5;
        //            oClsLevel.RightAnswerCount = 12;
        //            break;
        //        case 5:
        //            oClsLevel.LevelStart = 0;
        //            oClsLevel.LevelEnd = 50;
        //            oClsLevel.OperatorCount = 3;
        //            oClsLevel.WrongAnswerCount = 5;
        //            oClsLevel.RightAnswerCount = 15;
        //            break;
        //    }
        //    return oClsLevel.GetNextNumber();
        //}

        public static bool CheckResult(MathOperator CurrentNumbers,int Result)
        {
            bool isRightAnswer = false;
            switch (CurrentNumbers.Operator)
            {
                case 1:
                    isRightAnswer = (Result == CurrentNumbers.FirstNumber + CurrentNumbers.SecondNumber);
                    break;
                case 2:
                    isRightAnswer = (Result == CurrentNumbers.FirstNumber - CurrentNumbers.SecondNumber);
                    break;
                case 3:
                    isRightAnswer = (Result == CurrentNumbers.FirstNumber * CurrentNumbers.SecondNumber);
                    break;
            }
            return isRightAnswer;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to math operator Test");

            char exit = 'a';

            int nRightAnswerCount = 0;
            int nWrongAnswerCount = 0;
            IMathOperatorLevel MyCurrentLevel = GetLevelObject(1);
            while (exit!='e')
            {
                if(MyCurrentLevel==null)
                {
                    Console.WriteLine("Congratulation game over");
                    break;
                }
                bool isRightAnswer = false;
                MathOperator CurrentNumbers = MyCurrentLevel.GetNextNumber();

                Console.WriteLine($"Your Current Level is {MyCurrentLevel.LevelNumber}");
                Console.WriteLine($" first number {CurrentNumbers.FirstNumber}  second number {CurrentNumbers.SecondNumber} operator is {CurrentNumbers.Operator}");

                Console.WriteLine("*****************************************");
                Console.WriteLine("Please enter result");
                int Result = Convert.ToInt32(Console.ReadLine());

                isRightAnswer = CheckResult(CurrentNumbers, Result);

                if (isRightAnswer)
                {
                    Console.WriteLine("Right Answer");
                    nRightAnswerCount++;
                }
                else
                {
                    Console.WriteLine("Wrong Answer");
                    nWrongAnswerCount++;
                }

                MyCurrentLevel = MyCurrentLevel.GetNextLevel(nRightAnswerCount, nWrongAnswerCount);

                Console.WriteLine("*****************************************");
                Console.WriteLine("please enter e for exsit or press any ke");
                exit = Convert.ToChar(Console.ReadLine());
            }
        }
    }
}
