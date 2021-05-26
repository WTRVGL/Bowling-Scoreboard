using BowlingGUI.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BowlingGUI.UserControls
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
            FirstValue.Focus();
        }

        private void Button_Handle_Focus(object sender, RoutedEventArgs e)
        {
            var x = this;
            
            var ctx = (FrameViewModel)x.DataContext;

           
        }
    }
}
