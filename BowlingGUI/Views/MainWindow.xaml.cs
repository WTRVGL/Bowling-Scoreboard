using BowlingGUI.ViewModels;
using Puntentelling;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace BowlingGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
  
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

    }
}
