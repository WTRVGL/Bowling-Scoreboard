namespace Bowling.Domain.Models
{
    /// <summary>
    /// Simple Frame class.
    /// <remarks>
    /// Currently used as a "low level" entity for use with the "Puntentelling" library.
    /// Also can serve purpose for scaffolding entities in Entity Framework.
    /// </remarks>
    /// </summary>
    public class Frame
    {
        public int FrameNumber { get; set; }
        public int FirstScore { get; set; }
        public int SecondScore { get; set; }
        public int ThirdScore { get; set; }
        public int BonusScore { get; set; }
        public int TotalScore => FirstScore + SecondScore + ThirdScore + BonusScore;
        public bool IsSpare => FirstScore + SecondScore == 10 && FirstScore != 10;
        public bool IsStrike => FirstScore == 10;
    }
}