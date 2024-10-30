using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperationGame.Bl
{
    interface IMathOperatorLevel
    {
        public int LevelNumber { get; set; }
        public int LevelStart { get;}
        public int LevelEnd { get;}
        public int OperatorCount { get;}
        public int RightAnswerCount { get;}
        public int WrongAnswerCount { get;}

        public MathOperator GetNextNumber();
        public IMathOperatorLevel GetNextLevel(int rightCount,int wrongCount);
    }
}
