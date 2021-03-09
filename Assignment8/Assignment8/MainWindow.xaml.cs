using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Assignment8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer = new ();
        private DateTime _StartTime = DateTime.Now;
        private string _Description;
        private bool _IsStopped = true;
        private int lap = 1;
        public MainWindow()
        {
            InitializeComponent();

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Timer.Text = (DateTime.Now - _StartTime).ToString(@"hh\:mm\:ss");
        }

        private void StartStop_Click(object sender, RoutedEventArgs e)
        {
            if (StartStop.Content.ToString() == "Start")
            {
                _StartTime = DateTime.Now;
                dispatcherTimer.Start();
                _IsStopped = false;
                Record.Visibility = Visibility.Hidden;
                Description.Visibility = Visibility.Hidden;
                // Changes button to show stop
                StartStop.Content = "Stop";
                // Changes background color to red
                StartStop.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E14518"));
            }
            else
            {
                dispatcherTimer.Stop();
                _IsStopped = true;
                // Changes button to show start
                StartStop.Content = "Start";
                // Changes background color back to green
                StartStop.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6FA147"));
                Record.Visibility = Visibility.Visible;
                Description.Visibility = Visibility.Visible;
                Description.Text = "Lap " + lap + "  " + _StartTime.ToString("h:mm:ss tt");
            }
        }

        private void Record_Click(object sender, RoutedEventArgs e)
        {
            if (_IsStopped && Timer.Text != "00:00:00")
            {
                SavedBox.Items.Add($"{Timer.Text}\t\t{_Description}");
                lap++;
                Description.Text = "";
                Timer.Text = "00:00:00";
                Record.Visibility = Visibility.Hidden;
                Description.Visibility = Visibility.Hidden;
            }
        }

        private void SavedBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                SavedBox.Items.Remove(SavedBox.SelectedItem);
            }

        }
        private void Description_TextChanged(object sender, TextChangedEventArgs e) => _Description = Description.Text;

    }
}
