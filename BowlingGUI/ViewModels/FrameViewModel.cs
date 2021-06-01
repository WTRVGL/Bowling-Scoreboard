using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bowling.GUI.ViewModels
{
    /// <summary>
    /// ViewModel for a Frame UserControl.
    /// </summary>
    /// <remarks>
    /// Contains all properties that bind to Frame.
    /// These properties don't necessarily represent a "frame" in it's "pure" form, but allow to represent the data to the view.
    /// Implements INotifyPropertyChanged for updating the UI of bound properties.
    /// Implements IDataErrorInfo for validation of bound properties.
    /// </remarks>
    public class FrameViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Private fields.
        /// </summary>

        #region private fields

        private bool _IsActive;
        private int _FirstScore;
        private int _SecondScore;
        private int _BonusScore;
        private int _ThirdScore;
        private int _CumulativeScore;
        private bool _ExtraRoll;
        private bool _FramePlayed;

        #endregion


        /// <summary>
        /// Gets or sets the frame number.
        /// </summary>
        /// <value>
        /// The frame number.
        /// </value>
        public int FrameNumber { get; set; }

        /// <summary>
        /// FirstScore of the frame.
        /// </summary>
        /// <remarks>
        /// OnPropertyChanged() is called to notify that the property has changed.
        /// </remarks>
        /// <value>
        /// The first score of the frame.
        /// </value>
        public int FirstScore
        {
            get => _FirstScore;
            set
            {
                _FirstScore = value;
                OnPropertyChanged();
                OnPropertyChanged("SecondScore");
                OnPropertyChanged("ExtraRoll");
            }
        }

        /// <summary>
        /// Gets or sets the second score.
        /// </summary>
        /// <value>
        /// The second score of the frame.
        /// </value>
        public int SecondScore
        {
            get => _SecondScore;
            set
            {
                _SecondScore = value;
                OnPropertyChanged();
                OnPropertyChanged("FirstScore");
                OnPropertyChanged("ExtraRoll");
            }
        }

        /// <summary>
        /// Gets or sets the bonus score. The bonus score serves to hold additional points in case of spare or strikes.
        /// </summary>
        /// <remarks>
        /// In case of multiple strikes in a row, the bonus score will also contain the extra score.
        /// For example: if 3 strikes in a row are scored, 20 bonus points will be set.
        /// </remarks>
        /// <value>
        /// The bonus score.
        /// </value>
        public int BonusScore
        {
            get => _BonusScore;
            set
            {
                _BonusScore = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// "Third score" only applicable on the last (10th) frame.
        /// <remarks>
        /// When a spare or strike is achieved at frame 10, the player will get an additional throw.
        /// The points scored with the bonus throw is stored in this property.
        /// </remarks>
        /// </summary>
        /// <value>
        /// The third score.
        /// </value>
        public int ThirdScore
        {
            get => _ThirdScore;
            set
            {
                _ThirdScore = value;
                OnPropertyChanged();
            }
        }

        /// <summary>.
        /// Readonly getter which returns the total frame score
        /// </summary>
        /// <value>
        /// The total score of the frame is the sum of all the thrown scores plus additional bonus points.
        /// </value>
        public int TotalScore => FirstScore + SecondScore + ThirdScore + BonusScore;

        /// <summary>
        /// Gets or sets a value indicating whether an [extra roll] is possible for the last frame.
        /// <remarks>
        /// This boolean is used to toggle the visibility of the third column in the Frame UserControl.
        /// If the current frame number is 10 and a strike or spare is scored, an extra roll will be awarded.
        /// </remarks>
        /// </summary>
        /// <value>
        ///   <c>true</c> if [extra roll]; otherwise, <c>false</c>.
        /// </value>
        public bool ExtraRoll
        {
            get => FirstScore + SecondScore >= 10;
            set
            {
                _ExtraRoll = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is the final frame.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is the final frame; otherwise, <c>false</c>.
        /// </value>
        public bool IsFinalFrame { get; set; }


        /// <summary>
        /// The cumulative score is used to display the total score up to the point of this frame.
        /// <remarks>
        /// The cumulative score doesn't represent the total score of the current frame but rather
        /// is the sum of all previous total frames.
        /// </remarks>
        /// </summary>
        /// <value>
        /// The cumulative score.
        /// </value>
        public int CumulativeScore
        {
            get => _CumulativeScore;
            set
            {
                _CumulativeScore = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether the current frame has already been played.
        /// </summary>
        /// <remarks>
        /// The UI will enable and disable certain controls depending on of a frame has been played or not.
        /// This boolean serves this purpose.
        /// </remarks>
        /// <value>
        ///   <c>true</c> if [frame played]; otherwise, <c>false</c>.
        /// </value>
        public bool FramePlayed
        {
            get => _FramePlayed;
            set
            {
                _FramePlayed = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this frame is active.
        /// </summary>
        /// <remarks>
        /// Boolean to update the UI and enable certain controls depending whether this frame is the active one.
        /// </remarks>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get => _IsActive;
            set
            {
                _IsActive = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <remarks>
        /// Whenever the value of a property has changed, this method is called.
        /// It invokes the PropertyChangedEventArgs event and notifies that value of this property has changed.
        /// It allow the MVVM pattern to work since the UI can now update depending on whether a property has changed.
        /// </remarks>
        /// 
        /// <param name="name">The of the changed property.</param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// <remarks>
        /// Required implementation of IDataErrorInfo 
        /// </remarks>
        /// </summary>
        public string Error { get; }


        /// <summary>
        /// Required implementation of IDataErrorInfo to allow validation.
        /// </summary>
        /// <remarks>
        /// This property specifies which validation rules are present in each frame.
        /// For every input TextBox, max allowed values are defined and an error string is returned
        /// which can be used in XAML data binding to display the error.
        /// </remarks>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(FirstScore))
                {
                    if (IsFinalFrame)
                    {
                        if (FirstScore > 10) return "Score is meer dan 10. Kan niet!";

                        if (SecondScore > 10) return "Score is meer dan 10. Kan niet!";

                        if (ThirdScore > 10) return "Score is meer dan 10. Kan niet!";

                        if (FirstScore + SecondScore > 10 && FirstScore + SecondScore <= 20) return null;

                        if (FirstScore + SecondScore > 20) return "Meer dan 10 punten per worp is onmogelijk!";
                    }

                    if (FirstScore + SecondScore > 10) return "Totaal is meer dan 10. Kan niet!";
                }

                if (columnName == nameof(SecondScore))
                {
                    if (IsFinalFrame)
                    {
                        if (FirstScore > 10) return "Score is meer dan 10. Kan niet!";

                        if (SecondScore > 10) return "Score is meer dan 10. Kan niet!";

                        if (ThirdScore > 10) return "Score is meer dan 10. Kan niet!";

                        if (FirstScore + SecondScore > 10 && FirstScore + SecondScore <= 20) return null;

                        if (FirstScore + SecondScore > 20) return "Meer dan 10 punten per worp is onmogelijk!";
                    }

                    if (FirstScore + SecondScore > 10) return "Totaal is meer dan 10. Kan niet!";
                }


                if (columnName == nameof(ThirdScore))
                {
                    if (IsFinalFrame)
                    {
                        if (FirstScore > 10) return "Score is meer dan 10. Kan niet!";

                        if (SecondScore > 10) return "Score is meer dan 10. Kan niet!";

                        if (ThirdScore > 10) return "Score is meer dan 10. Kan niet!";

                        if (FirstScore + SecondScore > 10 && FirstScore + SecondScore <= 20) return null;

                        if (FirstScore + SecondScore > 20) return "Meer dan 10 punten per worp is onmogelijk!";
                    }

                    if (FirstScore + SecondScore > 10) return "Totaal is meer dan 10. Kan niet!";
                }

                return null;
            }
        }
    }
}