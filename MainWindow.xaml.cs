using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace Bomba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void HorrorFilmBUTTON_Click(object sender, RoutedEventArgs e)
        {
            if (Passwordas.Password == "4761")
            {

                LoginScreen loginScreen = new LoginScreen();
                loginScreen.Show();
                this.Close();

            }
            else 
            {
                MessageBox.Show("PASSWORD IS INCORRECT!", "WARNING");
                Passwordas.Clear();
            }
        }

        private void Animacija_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
            this.Close();
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
            if (increment == 3)
            {
             Trys.Content=Animacija.Content;
                Trys1.Content=Animacija.Content;
                Trys2.Content = Animacija.Content;
               
                Trys4.Content = Animacija.Content;
                Trys5.Content = Animacija.Content;
            }

            if (increment == 2) 
            {
                Du.Content = Animacija.Content;
                Du1.Content = Animacija.Content;
                Du2.Content = Animacija.Content;
                Du3.Content = Animacija.Content;
                Du4.Content = Animacija.Content;
                Du5.Content = Animacija.Content;
            }

            if (increment == 1)
            {
               
                Vienas.Content = Animacija.Content;
                Vienas1.Content = Animacija.Content;
                Vienas2.Content = Animacija.Content;
                Vienas3.Content = Animacija.Content;
                Vienas4.Content = Animacija.Content;
                Vienas5.Content = Animacija.Content;
                Vienas6.Content = Animacija.Content;

            }
            if (increment == 1 && Passwordas.Password != "4761")
            {
                for (int j = 0; j < 4; j++)
                    {
                        SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\YouAreAnIdiot.wav");
                        play.Load();
                        play.Play();
                    }
                MessageBox.Show("YOUR COMPUTER ENCRYPTED!", "CONGRATULATIONS");
                this.Close();

            }
        }
    }
}
