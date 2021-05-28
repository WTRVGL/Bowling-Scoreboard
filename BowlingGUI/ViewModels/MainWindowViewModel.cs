using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Bowling.Domain.Models;
using Bowling.Puntentelling.Services;
using Prism.Commands;

namespace Bowling.GUI.ViewModels
{
    /// <summary>
    /// ViewModel of the MainWindow. 
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<FrameViewModel> _Frames;

        public ObservableCollection<FrameViewModel> Frames
        {
            get => _Frames;
            set
            {
                _Frames = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Constructor 
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
                new FrameViewModel {FrameNumber = 10, IsFinalFrame = true},
            };
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand AddFrame => new DelegateCommand<object>(AddFrameFunction, AddFrameEvaluation);

        private void AddFrameFunction(object context)
        {
            var currentFrameViewModel = (FrameViewModel) context;
            var currentIndex = currentFrameViewModel.FrameNumber - 1;

            //New instance of ScoreService
            var scoreService = new ScoreService();

            //ObservableCollection<FrameViewModels> to List<Frame>
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


            if (currentIndex == 9)
            {
                return;
            }

            Frames[currentIndex + 1].IsActive = true;
        }


        private static bool AddFrameEvaluation(object context)
        {
            //This is called to evaluate whether AddFrameFunction() can be called.
            var frame = (FrameViewModel) context;

            if (frame == null)
            {
                return true;
            }

            if (frame.FirstScore + frame.SecondScore <= 10) return true;
            //Extra check last frame, since FirstScore + SecondScore + ThirdScore can be 30.
            if (frame.IsFinalFrame != true) return false;
            return frame.FirstScore <= 10 || frame.SecondScore <= 10 || frame.ThirdScore <= 10;
        }
    }
}