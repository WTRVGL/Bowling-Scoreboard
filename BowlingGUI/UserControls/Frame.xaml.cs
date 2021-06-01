using System.Windows;
using System.Windows.Controls;
using Bowling.GUI.ViewModels;

namespace Bowling.GUI.UserControls
{
    /// <summary>
    /// Interaction logic for Frame.xaml
    /// </summary>
    public partial class Frame : UserControl
    {
        
        public Frame()
        {
            InitializeComponent();
            var x = this;
            this.Loaded += Frame_Loaded;


        }
              

        private void Frame_Loaded(object sender, RoutedEventArgs e)
        {
            FirstScore.Focus();
        }
    }
}
