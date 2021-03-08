using System;
using System.Collections.Generic;
using System.Linq;
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
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private DateTime startTime;
        public MainWindow()
        {
            InitializeComponent();

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);


        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Timer.Text = (DateTime.Now - startTime).ToString(@"hh\:mm\:ss");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            startTime = DateTime.Now;
            dispatcherTimer.Start();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SavedBox.Items.Add($"{Timer.Text} {Description.Text}");
            Description.Text = "";
            Timer.Text = "00:00:00";
        }

        private void SavedBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                SavedBox.Items.Remove(SavedBox.SelectedItem);
            }
            
        }
    }
}
