using Bowling.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Puntentelling.Services
{
    public class ScoreService
    {
        public List<Frame> UpdatedFrameScores(List<Frame> frames)
        {
    
            // Loops trough the entire list
            for (int i = 0; i < frames.Count - 1; i++)
            {
                // Calculate last 3 frames
                if (i == 8)
                {   
                    if (frames[i].IsStrike == true )
                    {
                        frames[i].BonusScore = frames[i + 1].FirstScore + frames[i + 1].SecondScore;

                        if (frames[i+ 1].FirstScore == 10 && frames[ i + 1 ].SecondScore == 10)
                        {
                            frames[i].BonusScore = 20;
                        }
                        

                        if (frames[i -1].IsStrike == true)
                        {
                            frames[i - 1].BonusScore = 10 + frames[i + 1].FirstScore;
                        }
                    }

                    if (frames[i].IsSpare == true)
                    {
                        frames[i].BonusScore = frames[i + 1].FirstScore;
                    }

                    return frames;
                } 

                /*Regular Logic for Spare, Strike, Double Strike and Triple Strike*/
                if (frames[i].IsSpare == true)
                {
                    frames[i].BonusScore = frames[i+1].FirstScore;
                }

                if (frames[i].IsStrike == true)
                {
                    frames[i].BonusScore = frames[i + 1].FirstScore + frames[i + 1].SecondScore;
                }

                if (frames[i].IsStrike == true && frames[i + 1].IsStrike == true)
                {
                    if (frames[i + 2].IsFinalFrame == true)
                    {
                        frames[i].BonusScore = 10 + frames[i + 2].FirstScore;
                    }

                    frames[i].BonusScore = 10 + frames[i + 2].FirstScore;
                }

                if (frames[i].IsStrike == true && frames[i + 1].IsStrike == true && frames[i + 2].IsStrike == true)
                {
                    frames[i].BonusScore = 20;
                }

                if (frames[i].IsStrike == true && frames[i + 1].IsStrike == true && frames[i + 2].IsSpare == true)
                {
                    frames[i].BonusScore = 10 + frames[i + 2].FirstScore;
                }
            }

            return frames;
        }
        public int TotalFrameScore(List<Frame> frames)
        {
            int totalScore = 0;
            frames.ForEach(fr =>
            {
                totalScore += fr.TotalScore;
            });

            return totalScore;
        }
        
    }
}
