using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bowling.Domain
{
    public class Frame 
    {
        private int _FrameNumber;
        private int _FirstScore;
        private int _SecondScore;
        public string Voornaam => "Wouter";
        public string Achternaam => "Vangeel";
        public string FullName => $"{Voornaam} {Achternaam}";
        private int _BonusScore;
        private int _ThirdScore;
        public int TotalScore { get => FirstScore + SecondScore + ThirdScore + BonusScore; }

        public bool IsSpare
        {
            get 
            {
                if (FirstScore + SecondScore == 10 && FirstScore != 10)
                {
                    return true;
                }
                return false;
            }
        }

        public int MyProperty { get; set; }

        public int ThirdScore
        {
            get { return _ThirdScore; }
            set { _ThirdScore = value; }
        }



        public int BonusScore
        {
            get { return _BonusScore; }
            set { _BonusScore = value; }
        }

        public bool IsFinalFrame { get; set; }

        public bool IsStrike
        {
            get
            {
                if (FirstScore == 10)
                {
                    return true;
                }

                return false;
            }
        }

        public int FrameNumber
        {
            get { return _FrameNumber; }
            set { _FrameNumber = value; }
        }


        public int FirstScore
        {
            get { return _FirstScore; }
            set { _FirstScore = value; }
        }


        public int SecondScore
        {
            get { return _SecondScore; }
            set { _SecondScore = value;}
        }
    }
}