using System.Collections.Generic;

namespace Bowling.GUI.ViewModels
{
    /// <summary>
    ///     Mock Viewmodel to fill ItemControl at Design time
    /// </summary>
    public class MockViewModel
    {
        public List<FrameViewModel> DesignTimeMockList =>
            new List<FrameViewModel>
            {
                new FrameViewModel {FrameNumber = 1, FirstScore = 2, SecondScore = 4, FramePlayed = true},
                new FrameViewModel {FrameNumber = 2, FirstScore = 2, SecondScore = 4, FramePlayed = true},
                new FrameViewModel {FrameNumber = 3, FirstScore = 2, SecondScore = 4, FramePlayed = true},
                new FrameViewModel {FrameNumber = 4, FirstScore = 2, SecondScore = 4, IsActive = true},
                new FrameViewModel {FrameNumber = 5, FirstScore = 2, SecondScore = 4},
                new FrameViewModel {FrameNumber = 6, FirstScore = 2, SecondScore = 4},
                new FrameViewModel {FrameNumber = 7, FirstScore = 2, SecondScore = 4},
                new FrameViewModel {FrameNumber = 8, FirstScore = 2, SecondScore = 4},
                new FrameViewModel {FrameNumber = 9, FirstScore = 2, SecondScore = 4},
                new FrameViewModel {FrameNumber = 10, FirstScore = 2, SecondScore = 4, IsFinalFrame = true}
            };
    }
}