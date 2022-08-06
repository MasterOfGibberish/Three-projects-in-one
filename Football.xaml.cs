using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

namespace Bomba
{
    /// <summary>
    /// Interaction logic for Football.xaml
    /// </summary>
    public partial class Football : Window       
    {
        static List<string> ZaidimoRezultatai = new List<string>();
        SqlConnection sqlBomba = new SqlConnection(@"Data Source =DESKTOP-FGIOSI5\SQLEXPRESS; Initial Catalog = Bomba; Integrated Security=true");

        public static Football instance2;
        public TextBlock User;
        public Football()
        {
            InitializeComponent();
            myCanvas.Focus();
            timer.Tick += MainTimerEvent;
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Start();

            instance2 = this;
            User = NameText;

        }
        DispatcherTimer timer = new DispatcherTimer();

        int speed = 10;
        int dropSpeed = 10;
        bool goLeft, goRight;
        bool isjungejas=true;
      
        public void MainTimerEvent(object sender, EventArgs e)
        {
            Canvas.SetTop(player, Canvas.GetTop(player) + dropSpeed);

            if (goLeft == true && Canvas.GetLeft(player) > 0)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - speed);
            }
            if (goRight == true && Canvas.GetLeft(player) + (player.Width + 5) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + speed);
            }

            
            if (Canvas.GetTop(player) + (player.Height * 2) > Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(player, -80);
            }

            Canvas.SetLeft(box, Canvas.GetLeft(box) - speed);
            Canvas.SetRight(box, Canvas.GetRight(box) - speed);

            if (Canvas.GetLeft(box) < 6 || Canvas.GetLeft(box) + (box.Width * 2) > Application.Current.MainWindow.Width)
            {
                speed = -speed;
            }

            foreach (var x in myCanvas.Children.OfType<Rectangle>())
            {
                if ((string)x.Tag == "platform")
                {
                    x.Stroke = Brushes.Black;

                    Rect playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);
                    Rect platformHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (playerHitBox.IntersectsWith(platformHitBox))
                    {
                        dropSpeed = 0;
                        Canvas.SetTop(player, Canvas.GetTop(x) - player.Height);
                        txtInfo.Content = "Landed on - " + x.Name;
                    }
                  
                    else
                    {
                        dropSpeed = 10;
                    }

                }
                if ((string)x.Tag=="platform1")
                {
                    Rect playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);
                    Rect platform1HitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (playerHitBox.IntersectsWith(platform1HitBox))
                    {

                        while (isjungejas == true)
                        {
                            Isjungejas();
                            isjungejas = false;
                            MessageBox.Show("Venk Purple, Idiote!");
                        }
                    }         
                }
                if ((string)x.Tag == "Vartai")
                {
                    Rect playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);
                    Rect platformHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (playerHitBox.IntersectsWith(platformHitBox))
                    {
                        
                        while (isjungejas == true)
                        {
                            Isjungejas();
                            isjungejas = false;
                            MessageBox.Show("Ivartis");
                        }
                    }
                }
                if ((string)x.Tag == "box")
                {
                    Rect playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);
                    Rect platformHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (playerHitBox.IntersectsWith(platformHitBox))
                    {
                        
                        while (isjungejas == true)
                        {
                            Isjungejas();
                            isjungejas = false;
                            MessageBox.Show("pagavo");
                        }
                    }
                }
            }

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = true;
            }
            if (e.Key == Key.Right)
            {
                goRight = true;
            }
          
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = false;
            }
            if (e.Key == Key.Right)
            {
                goRight = false;
            }
         
        }
        private int increment = 0;
        private void dispatcherTimerTicker(object sender, EventArgs e)
        {

            increment++;
            scoreText.Text = increment.ToString();
        }
            private void scoreText_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += dispatcherTimerTicker;
            dispatcherTimer.Start();
        }

        public void Isjungejas()
        {
            this.Close();
            Game game = new Game();
            game.Focus();

            if (sqlBomba.State == System.Data.ConnectionState.Closed)
            {               
                sqlBomba.Open();
            }
            int music = 0;
            SqlCommand command = new SqlCommand("UserAdd3", sqlBomba);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", NameText.Text.Trim());
                command.Parameters.AddWithValue("@MusicCode", music);
                command.Parameters.AddWithValue("@GameResults", scoreText.Text.Trim());
                command.ExecuteNonQuery(); 
                
                string path = @"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\ZaidimoRezultai.txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (var s in ZaidimoRezultatai)
                    {
                        sw.Write($" {s}");
                        command.Parameters.AddWithValue("@GameResults", s);
                    }
                    sw.Close();
                }
                sqlBomba.Close();     
        }
    }
}



