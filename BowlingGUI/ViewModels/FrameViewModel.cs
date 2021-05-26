using Prism.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BowlingGUI.ViewModels
{
    public class FrameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region private fields
        private bool _IsActive;
        private int _FirstScore;
        private int _SecondScore;
        private int _BonusScore;
        private bool _IsSpare;
        private bool _IsStrike;
        private int _ThirdScore;
        private int _CumulativeScore;

        #endregion

        public int ThirdScore
        {
            get { return _ThirdScore; }
            set { _ThirdScore = value; OnPropertyChanged(); }
        }

        public int TotalScore { get => FirstScore + SecondScore + ThirdScore + BonusScore; }


        public int CumulativeScore
        {
            get { return _CumulativeScore; }
            set { _CumulativeScore = value; OnPropertyChanged(); }
        }


        public bool IsStrike
        {
            get { return _IsStrike; }
            set { _IsStrike = value; }
        }

        public bool IsSpare
        {
            get { return _IsSpare; }
            set { _IsSpare = value; }
        }


        public int BonusScore
        {
            get { return _BonusScore; }
            set { _BonusScore = value; OnPropertyChanged(); }
        }


        public int SecondScore
        {
            get { return _SecondScore; }
            set { _SecondScore = value; OnPropertyChanged(); }
        }



        public int FirstScore
        {
            get { return _FirstScore; }
            set { _FirstScore = value; OnPropertyChanged(); }
        }

        private bool _FramePlayed;

        public bool FramePlayed 
        {
            get { return _FramePlayed; }
            set { _FramePlayed = value; OnPropertyChanged(); }
        }


        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; OnPropertyChanged(); }
        }


        public bool IsFinalFrame { get; set; }
        public int FrameNumber { get; set; }
        

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}