using System.Windows;
using System.Windows.Controls;
using Bowling.GUI.Views;

namespace Bowling.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
        }

        /// <summary>
        /// "Hack" to instantly focus on the first TextBox when the app starts.
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            EventManager.RegisterClassHandler(typeof(TextBox),
                TextBox.GotFocusEvent,
                new RoutedEventHandler(TextBox_GotFocus));
            base.OnStartup(e);
        }


        /// <summary>
        /// Handles the GotFocus event of the TextBox control.
        /// <remarks>
        /// Whenever a TextBox is focused, select all the text.
        /// Makes it easy to enter all scores while only tabbing
        /// </remarks>
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
            {
            (sender as TextBox)?.SelectAll();
        }

        /// <summary>
        /// Method called when app is started. Causes a new MainWindow to show.
        /// </summary>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}