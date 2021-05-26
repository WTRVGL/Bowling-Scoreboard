using Prism.Commands;
using Puntentelling;
using Bowling.Domain;
using Puntentelling.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;

namespace BowlingGUI.ViewModels
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
            get { return _Frames; }
            set { _Frames = value; OnPropertyChanged(); }
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

        public ICommand AddFrame
        {
            get { return new DelegateCommand<object>(AddFrameFunction, AddFrameEvaluation); }
        }

        private void AddFrameFunction(object context )
        {
            var frvm = (FrameViewModel)context;
            int currentIndex = frvm.FrameNumber - 1;

            //New instance of ScoreService
            ScoreService scoreService = new ScoreService();

            //ObservableCollection<FrameViewModels> to List<Frame>
            var frameList = new List<Frame>();
            Frames.ToList().ForEach(vm =>
            {
                var fr = new Frame { FirstScore = vm.FirstScore, SecondScore = vm.SecondScore };
                frameList.Add(fr);
            });

            //All scores updated.
            var updatedList = scoreService.UpdatedFrameScores(frameList);
            
            // Add updated BonusScore and CumulativeScore to the ObservableCollection Frames.
            for (int i = 1; i < updatedList.Count; i++)
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
            
        
        private bool AddFrameEvaluation(object context)
        {
            //This is called to evaluate wether AddFrameFunction() can be called.
            var frame = (FrameViewModel)context;

            if (frame == null)
            {
                return true;
            }

            if (frame.FirstScore + frame.SecondScore > 10)
            {
                //Extra check last frame, since FirstScore + SecondScore + ThirdScore can be 30.
                if (frame.IsFinalFrame == true)
                {
                    if (frame.FirstScore > 10 && frame.SecondScore > 10 && frame.ThirdScore > 10)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }

            return true;
        }
    }
}