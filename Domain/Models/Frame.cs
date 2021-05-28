namespace Bowling.Domain.Models
{
    public class Frame
    {
        public int TotalScore => FirstScore + SecondScore + ThirdScore + BonusScore;

        public bool IsSpare => FirstScore + SecondScore == 10 && FirstScore != 10;

        public int ThirdScore { get; set; }

        public int BonusScore { get; set; }

        public bool IsFinalFrame { get; set; }

        public bool IsStrike => FirstScore == 10;

        public int FrameNumber { get; set; }

        public int FirstScore { get; set; }

        public int SecondScore { get; set; }
    }
}