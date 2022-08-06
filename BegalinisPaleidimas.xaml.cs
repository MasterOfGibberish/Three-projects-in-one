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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Media;

namespace Bomba
{
    /// <summary>
    /// Interaction logic for BegalinisPaleidimas.xaml
    /// </summary>
    public partial class BegalinisPaleidimas : Window
    {
        public BegalinisPaleidimas()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += dispatcherTimerTicker;
            dispatcherTimer.Start();
        }
        private int increment = 11;
        private void dispatcherTimerTicker(object sender, EventArgs e)
        {

            increment--;
           
            Animacija.Content = increment.ToString();
            if (increment == 8)
            {
               
                BegalinisPaleidimas begalinisPaleidimas = new BegalinisPaleidimas();
                begalinisPaleidimas.Show();
                begalinisPaleidimas.Focus();
                this.Activate();
                SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\YouAreAnIdiot.wav");
                play.Load();
                play.Play();
            }
           
            if (increment == 1)
            {
                
                BegalinisPaleidimas begalinisPaleidimas = new BegalinisPaleidimas();
                begalinisPaleidimas.Show();
                begalinisPaleidimas.Focus();
                this.Activate();
            }
        }
          
        private void migtukas3_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\YouAreAnIdiot.wav");
            play.Load();
            play.Play();
            BegalinisPaleidimas begalinisPaleidimas = new BegalinisPaleidimas();
            begalinisPaleidimas.Show();
            begalinisPaleidimas.Focus();
            this.Activate();
        }

        private void Animacija_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\YouAreAnIdiot.wav");
            play.Load();
            play.Play();
            this.Close();
        }
    }
}
