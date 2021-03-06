using System.Collections.Generic;
using Bowling.Domain.Models;

namespace Bowling.Puntentelling.Services
{

    /// <summary>
    /// Class that contains methods to calculate scores for a list of Frames.
    /// </summary>
    public class ScoreService
    {
        /// <summary>
        /// Returns a List of Frame with the updated scores.
        /// <remarks>
        /// For every Frame in the list, bonus points will the calculated depending on strikes, spares,...
        /// </remarks>
        /// </summary>
        /// <param name="frames">The frames.</param>
        /// <returns></returns>
        public List<Frame> UpdatedFrameScores(List<Frame> frames)
        {
            // Loops trough the entire list
            for (var i = 0; i < frames.Count - 1; i++)
            {
                // Calculate last 3 frames
                if (i == 8)
                {
                    //If current frame (frame 9) is a strike
                    if (frames[i].IsStrike)
                    {
                        //Current bonus score = sum of first score and second score of the next frame.
                        frames[i].BonusScore = frames[i + 1].FirstScore + frames[i + 1].SecondScore;

                        //If last frame had 2 strikes, add 20 bonus scores to current frame.
                        if (frames[i + 1].FirstScore == 10 && frames[i + 1].SecondScore == 10)
                            frames[i].BonusScore = 20;

                        //If previous frame was a strike give it bonus score of 10 + first score of last frame.
                        if (frames[i - 1].IsStrike) frames[i - 1].BonusScore = 10 + frames[i + 1].FirstScore;
                    }

                    //If frame 8 is a spare give it bonus points of first score of last frame.
                    if (frames[i].IsSpare) frames[i].BonusScore = frames[i + 1].FirstScore;

                    return frames;
                }

                /*Regular Logic for Spare, Strike, Double Strike and Triple Strike*/
                if (frames[i].IsSpare) frames[i].BonusScore = frames[i + 1].FirstScore;

                if (frames[i].IsStrike) frames[i].BonusScore = frames[i + 1].FirstScore + frames[i + 1].SecondScore;

                if (frames[i].IsStrike && frames[i + 1].IsStrike)
                {
                    if (frames[i + 2].FrameNumber == 10) frames[i].BonusScore = 10 + frames[i + 2].FirstScore;

                    frames[i].BonusScore = 10 + frames[i + 2].FirstScore;
                }

                if (frames[i].IsStrike && frames[i + 1].IsStrike && frames[i + 2].IsStrike) frames[i].BonusScore = 20;

                if (frames[i].IsStrike && frames[i + 1].IsStrike && frames[i + 2].IsSpare)
                    frames[i].BonusScore = 10 + frames[i + 2].FirstScore;
            }

            return frames;
        }

        /// <summary>
        /// Returns the Total score of all the Frames.
        /// </summary>
        /// <param name="frames">The frames.</param>
        public int TotalFrameScore(List<Frame> frames)
        {
            var totalScore = 0;
            

            frames.ForEach(fr => { totalScore += fr.TotalScore; });

            return totalScore;
        }
    }
}