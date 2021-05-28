using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bowling.GUI.ViewModels
{
    public class FrameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region private fields

        private bool _IsActive;
        private int _FirstScore;
        private int _SecondScore;
        private int _BonusScore;
        private int _ThirdScore;
        private int _CumulativeScore;

        #endregion

        public int ThirdScore
        {
            get => _ThirdScore;
            set
            {
                _ThirdScore = value;
                OnPropertyChanged();
            }
        }

        public int TotalScore => FirstScore + SecondScore + ThirdScore + BonusScore;


        public int CumulativeScore
        {
            get => _CumulativeScore;
            set
            {
                _CumulativeScore = value;
                OnPropertyChanged();
            }
        }


        public int BonusScore
        {
            get => _BonusScore;
            set
            {
                _BonusScore = value;
                OnPropertyChanged();
            }
        }


        public int SecondScore
        {
            get => _SecondScore;
            set
            {
                _SecondScore = value;
                OnPropertyChanged();
            }
        }


        public int FirstScore
        {
            get => _FirstScore;
            set
            {
                _FirstScore = value;
                OnPropertyChanged();
            }
        }

        private bool _FramePlayed;

        public bool FramePlayed
        {
            get => _FramePlayed;
            set
            {
                _FramePlayed = value;
                OnPropertyChanged();
            }
        }


        public bool IsActive
        {
            get => _IsActive;
            set
            {
                _IsActive = value;
                OnPropertyChanged();
            }
        }


        public bool IsFinalFrame { get; set; }
        public int FrameNumber { get; set; }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}