using System.Collections.Generic;
using Bowling.Domain.Models;

namespace Bowling.Puntentelling.Services
{
    public class ScoreService
    {
        /// <summary>
        /// Calculates BonusScore for each frame depending on the next 2 frames
        /// </summary>
        /// <param name="frames"></param>
        /// <returns></returns>
        public List<Frame> UpdatedFrameScores(List<Frame> frames)
        {
            // Loops trough the entire list
            for (var i = 0; i < frames.Count - 1; i++)
            {
                // Calculate last 3 frames
                if (i == 8)
                {
                    if (frames[i].IsStrike)
                    {
                        frames[i].BonusScore = frames[i + 1].FirstScore + frames[i + 1].SecondScore;

                        if (frames[i + 1].FirstScore == 10 && frames[i + 1].SecondScore == 10)
                            frames[i].BonusScore = 20;

                        if (frames[i - 1].IsStrike) frames[i - 1].BonusScore = 10 + frames[i + 1].FirstScore;
                    }

                    if (frames[i].IsSpare) frames[i].BonusScore = frames[i + 1].FirstScore;

                    return frames;
                }

                /*Regular Logic for Spare, Strike, Double Strike and Triple Strike*/
                if (frames[i].IsSpare) frames[i].BonusScore = frames[i + 1].FirstScore;

                if (frames[i].IsStrike) frames[i].BonusScore = frames[i + 1].FirstScore + frames[i + 1].SecondScore;

                if (frames[i].IsStrike && frames[i + 1].IsStrike)
                {
                    if (frames[i + 2].IsFinalFrame) frames[i].BonusScore = 10 + frames[i + 2].FirstScore;

                    frames[i].BonusScore = 10 + frames[i + 2].FirstScore;
                }

                if (frames[i].IsStrike && frames[i + 1].IsStrike && frames[i + 2].IsStrike) frames[i].BonusScore = 20;

                if (frames[i].IsStrike && frames[i + 1].IsStrike && frames[i + 2].IsSpare)
                    frames[i].BonusScore = 10 + frames[i + 2].FirstScore;
            }

            return frames;
        }

        public int TotalFrameScore(List<Frame> frames)
        {
            var totalScore = 0;
            frames.ForEach(fr => { totalScore += fr.TotalScore; });

            return totalScore;
        }
    }
}