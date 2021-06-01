using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Bowling.Domain.Models;
using Bowling.Puntentelling.Services;
using Prism.Commands;

namespace Bowling.GUI.ViewModels
{
    /// <summary>
    /// ViewModel of the MainWindow.
    /// <remarks>
    /// Contains the ObservableCollection of FrameViewModel which will template for a Frame UserControl
    /// </remarks>
    /// </summary>
    public class MainWindowViewModel
    {
        /// <summary>
        /// Collection of FrameViewModels which is being bound to the ItemControl ItemSource.
        /// </summary>
        /// <remarks>
        /// This property will be used to template into a UserControl
        /// </remarks>
        /// <value>
        /// ObservableCollection of FrameViewModel
        /// </value>
        public ObservableCollection<FrameViewModel> Frames { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// <remarks>
        /// Will fill Frames with 10 FrameViewModels and thus generating the 10 Frame UserControls in MainWindow.
        /// First frame will be set to active and last frame will have it's IsFinalFrame bool flag set to true.
        /// </remarks>
        /// </summary>
        public MainWindowViewModel()
        {
            Frames = new ObservableCollection<FrameViewModel>()
            {
                new FrameViewModel {FrameNumber = 1, IsActive = true},
                new FrameViewModel {FrameNumber = 2},
                new FrameViewModel {FrameNumber = 3},
                new FrameViewModel {FrameNumber = 4},
                new FrameViewModel {FrameNumber = 5},
                new FrameViewModel {FrameNumber = 6},
                new FrameViewModel {FrameNumber = 7},
                new FrameViewModel {FrameNumber = 8},
                new FrameViewModel {FrameNumber = 9},
                new FrameViewModel {FrameNumber = 10, IsFinalFrame = true}
            };
        }

        /// <summary>
        /// AddFrame ICommand.
        /// <remarks>
        /// The command bound to the Button.
        /// </remarks>
        /// </summary>
        public ICommand AddFrame => new DelegateCommand<object>(AddFrameFunction, AddFrameEvaluation);


        /// <summary>
        /// Function called by the AddFrame ICommand
        /// <remarks>
        /// This command will update the new calculated frame scores and set the flag of the next frame IsActive to true.
        /// </remarks>
        /// </summary>
        /// <param name="context">The context.</param>
        private void AddFrameFunction(object context)
        {
            var currentFrameViewModel = (FrameViewModel) context;
            var currentIndex = currentFrameViewModel.FrameNumber - 1;

            // New instance of ScoreService which is used to calculate the new scores of the Frames collection.
            var scoreService = new ScoreService();

            //ObservableCollection<FrameViewModels> to List<Frame>. Required for ScoreService.
            var frameList = new List<Frame>();
            Frames.ToList().ForEach(vm =>
            {
                var fr = new Frame {FirstScore = vm.FirstScore, SecondScore = vm.SecondScore};
                frameList.Add(fr);
            });

            //All scores updated.
            var updatedList = scoreService.UpdatedFrameScores(frameList);

            // Add updated BonusScore and CumulativeScore to the ObservableCollection Frames.
            for (var i = 1; i < updatedList.Count; i++)
            {
                Frames[i - 1].BonusScore = updatedList[i - 1].BonusScore;
                Frames[0].CumulativeScore = Frames[0].TotalScore;
                Frames[i].BonusScore = updatedList[i].BonusScore;
                Frames[i].CumulativeScore = Frames[i].TotalScore + Frames[i - 1].CumulativeScore;
            }

            //Sets current frame to FramePlayed = true and next frame to IsActive = true
            Frames[currentIndex].FramePlayed = true;

            // Returns if last frame. 
            // Prevents IndexOutBound when trying to set the next frame to active.
            if (currentIndex == 9) return;

            Frames[currentIndex + 1].IsActive = true;
        }

        /// <summary>
        /// This method is always called to evaluate whether AddFrame is able to execute.
        /// </summary>
        /// <remarks>
        /// This method could contain validation, but I rather use the ValidationRule and IDataErrorInfo to get more advanced validation.
        /// </remarks>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private static bool AddFrameEvaluation(object context)
        {
            return true;
        }
    }
}