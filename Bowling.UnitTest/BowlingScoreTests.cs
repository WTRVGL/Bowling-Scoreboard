using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Bowling.Domain.Models;
using Bowling.Puntentelling.Services;

namespace Bowling.UnitTest
{
    [TestClass]
    public class BowlingScoreTests
    {
        [TestMethod]
        public void TotalFrameScore_All_Zeroes()
        {
            //Arrange
            var frames = new List<Frame>
            {
                new Frame {FrameNumber = 1, FirstScore = 0, SecondScore = 0},
                new Frame {FrameNumber = 2, FirstScore = 0, SecondScore = 0},
                new Frame {FrameNumber = 3, FirstScore = 0, SecondScore = 0},
                new Frame {FrameNumber = 4, FirstScore = 0, SecondScore = 0},
                new Frame {FrameNumber = 5, FirstScore = 0, SecondScore = 0},
                new Frame {FrameNumber = 6, FirstScore = 0, SecondScore = 0},
                new Frame {FrameNumber = 7, FirstScore = 0, SecondScore = 0},
                new Frame {FrameNumber = 8, FirstScore = 0, SecondScore = 0},
                new Frame {FrameNumber = 9, FirstScore = 0, SecondScore = 0},
                new Frame {FrameNumber = 10, FirstScore = 0, SecondScore = 0, ThirdScore = 0}
            };

            //Act
            var scoreService = new ScoreService();
            var result = scoreService.UpdatedFrameScores(frames);
            var totalScore = scoreService.TotalFrameScore(result);

            //Assert
            Assert.IsTrue(totalScore == 0);
        }

        [TestMethod]
        public void TotalFrameScore_All_Strikes()
        {
            //Arrange
            var frames = new List<Frame>
            {
                new Frame {FrameNumber = 1, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 2, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 3, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 4, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 5, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 6, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 7, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 8, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 9, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 10, FirstScore = 10, SecondScore = 10, ThirdScore = 10}
            };

            //Act
            var scoreService = new ScoreService();
            var result = scoreService.UpdatedFrameScores(frames);
            var totalScore = scoreService.TotalFrameScore(result);

            //Assert
            Assert.IsTrue(totalScore == 300);
        }

        [TestMethod]
        public void TotalFrameScore_All_Spares_Last_Frame_Spare_Strike()
        {
            //Arrange
            var frames = new List<Frame>
            {
                new Frame {FrameNumber = 1, FirstScore = 0, SecondScore = 10},
                new Frame {FrameNumber = 2, FirstScore = 2, SecondScore = 8},
                new Frame {FrameNumber = 3, FirstScore = 5, SecondScore = 5},
                new Frame {FrameNumber = 4, FirstScore = 5, SecondScore = 5},
                new Frame {FrameNumber = 5, FirstScore = 1, SecondScore = 9},
                new Frame {FrameNumber = 6, FirstScore = 8, SecondScore = 2},
                new Frame {FrameNumber = 7, FirstScore = 6, SecondScore = 4},
                new Frame {FrameNumber = 8, FirstScore = 7, SecondScore = 3},
                new Frame {FrameNumber = 9, FirstScore = 1, SecondScore = 9},
                new Frame {FrameNumber = 10, FirstScore = 1, SecondScore = 9, ThirdScore = 10}
            };

            //Act
            var scoreService = new ScoreService();
            var result = scoreService.UpdatedFrameScores(frames);
            var totalScore = scoreService.TotalFrameScore(result);

            //Assert
            Assert.IsTrue(totalScore == 146);
        }

        [TestMethod]
        public void TotalFrameScore_Alternating_Spare_Strike_Last_Frame_All_Strikes()
        {
            //Arrange
            var frames = new List<Frame>
            {
                new Frame {FrameNumber = 1, FirstScore = 2, SecondScore = 8},
                new Frame {FrameNumber = 2, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 3, FirstScore = 1, SecondScore = 9},
                new Frame {FrameNumber = 4, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 5, FirstScore = 7, SecondScore = 3},
                new Frame {FrameNumber = 6, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 7, FirstScore = 4, SecondScore = 6},
                new Frame {FrameNumber = 8, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 9, FirstScore = 0, SecondScore = 10},
                new Frame {FrameNumber = 10, FirstScore = 10, SecondScore = 10, ThirdScore = 10}
            };

            //Act
            var scoreService = new ScoreService();
            var result = scoreService.UpdatedFrameScores(frames);
            var totalScore = scoreService.TotalFrameScore(result);

            //Assert
            Assert.IsTrue(totalScore == 210);
        }

        [TestMethod]
        public void TotalFrameScore_All_Strikes_Last_Frame_All_Zero()
        {
            //Arrange
            var frames = new List<Frame>
            {
                new Frame {FrameNumber = 1, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 2, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 3, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 4, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 5, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 6, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 7, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 8, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 9, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 10, FirstScore = 0, SecondScore = 0, ThirdScore = 0}
            };

            //Act
            var scoreService = new ScoreService();
            var result = scoreService.UpdatedFrameScores(frames);
            var totalScore = scoreService.TotalFrameScore(result);

            //Assert
            Assert.IsTrue(totalScore == 240);
        }

        [TestMethod]
        public void TotalFrameScore_All_Strikes_Last_Frame_Zero_Spare_Zero()
        {
            //Arrange
            var frames = new List<Frame>
            {
                new Frame {FrameNumber = 1, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 2, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 3, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 4, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 5, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 6, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 7, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 8, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 9, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 10, FirstScore = 0, SecondScore = 10, ThirdScore = 0}
            };

            //Act
            var scoreService = new ScoreService();
            var result = scoreService.UpdatedFrameScores(frames);
            var totalScore = scoreService.TotalFrameScore(result);

            //Assert
            Assert.IsTrue(totalScore == 260);
        }

        [TestMethod]
        public void TotalFrameScore_All_Strikes_Last_Frame_Strike_Zero_Spare()
        {
            //Arrange
            var frames = new List<Frame>
            {
                new Frame {FrameNumber = 1, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 2, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 3, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 4, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 5, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 6, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 7, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 8, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 9, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 10, FirstScore = 10, SecondScore = 0, ThirdScore = 10}
            };

            //Act
            var scoreService = new ScoreService();
            var result = scoreService.UpdatedFrameScores(frames);
            var totalScore = scoreService.TotalFrameScore(result);

            //Assert
            Assert.IsTrue(totalScore == 280);
        }

        [TestMethod]
        public void TotalFrameScore_All_Strikes_Last_Frame_Strike_Zero_Gutter()
        {
            //Arrange
            var frames = new List<Frame>
            {
                new Frame {FrameNumber = 1, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 2, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 3, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 4, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 5, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 6, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 7, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 8, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 9, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 10, FirstScore = 10, SecondScore = 0, ThirdScore = 5}
            };

            //Act
            var scoreService = new ScoreService();
            var result = scoreService.UpdatedFrameScores(frames);
            var totalScore = scoreService.TotalFrameScore(result);

            //Assert
            Assert.IsTrue(totalScore == 275);
        }

        [TestMethod]
        public void TotalFrameScore_Triple_Strike_Spare_Triple_Strike_Spare_Strike_Final_Frame_Triple_Strike()
        {
            //Arrange
            var frames = new List<Frame>
            {
                new Frame {FrameNumber = 1, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 2, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 3, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 4, FirstScore = 2, SecondScore = 8},
                new Frame {FrameNumber = 5, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 6, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 7, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 8, FirstScore = 0, SecondScore = 10},
                new Frame {FrameNumber = 9, FirstScore = 10, SecondScore = 0},
                new Frame {FrameNumber = 10, FirstScore = 10, SecondScore = 10, ThirdScore = 10}
            };

            //Act
            var scoreService = new ScoreService();
            var result = scoreService.UpdatedFrameScores(frames);
            var totalScore = scoreService.TotalFrameScore(result);

            //Assert
            Assert.IsTrue(totalScore == 242);
        }
    }
}