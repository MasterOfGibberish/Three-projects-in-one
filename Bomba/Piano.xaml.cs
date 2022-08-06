using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using System.Windows.Shapes;

namespace Bomba
{
    /// <summary>
    /// Interaction logic for Piano.xaml
    /// </summary>
   
    public partial class Piano : Window
    {
        static List<string> IrasytaMuzika = new List<string>();

        string duomenys= "0";

        public static Piano instance;
        public TextBlock vardas;
        SqlConnection sqlBomba = new SqlConnection (@"Data Source =DESKTOP-FGIOSI5\SQLEXPRESS; Initial Catalog = Bomba; Integrated Security=true");
        public Piano()
        {
            InitializeComponent();
           
            instance = this;
            vardas = Vardas;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\Bomba\Bomba\Resources\gama\Do.wav");
            play.Load();
            play.Play();
            if (veikia.IsChecked == true)
            {
                duomenys += "1";
            }
    
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\Bomba\Bomba\Resources\gama\Re.wav");
            play.Load();
            play.Play();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\Bomba\Bomba\Resources\gama\Mi.wav");
            play.Load();
            play.Play();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\Bomba\Bomba\Resources\gama\Fa.wav");
            play.Load();
            play.Play();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\Bomba\Bomba\Resources\gama\Sol.wav");
            play.Load();
            play.Play();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\Bomba\Bomba\Resources\gama\La.wav");
            play.Load();
            play.Play();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\Bomba\Bomba\Resources\gama\Si.wav");
            play.Load();
            play.Play();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\Bomba\Bomba\Resources\gama\Do2.wav");
            play.Load();
            play.Play();
        }

        private void pirmas_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\Bomba\Bomba\Resources\MuzikosSharpai\Do#.wav");
            play.Load();
            play.Play();
        }

        private void Antras_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\Bomba\Bomba\Resources\MuzikosSharpai\Re#.wav");
            play.Load();
            play.Play();
        }

        private void Trecias_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\Bomba\Bomba\Resources\MuzikosSharpai\Fa#.wav");
            play.Load();
            play.Play();

        }

        private void Keturi_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\Bomba\Bomba\Resources\MuzikosSharpai\Sol#.wav");
            play.Load();
            play.Play();
        }

        private void Penki_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\Bomba\Bomba\Resources\MuzikosSharpai\La.#wav.wav");
            play.Load();
            play.Play();
        }

        private void migtukas3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void back3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            if (!veikia.IsChecked == true)
            {
                Stop.IsEnabled = false;
                MessageBox.Show("Patvirtink, kad sutinki su salygomis", "Please!");
            }
            else
            {
                IrasytaMuzika.Add(duomenys);
                string path = @"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\MusicList.txt";
                if (sqlBomba.State == System.Data.ConnectionState.Closed)
                    sqlBomba.Open();
                SqlCommand command2 = new SqlCommand("Update tblUser set MusicCode=@Muzika", sqlBomba);
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (var s in IrasytaMuzika)
                    {
                        sw.Write($" {s}");
                        command2.Parameters.AddWithValue("@Muzika", s);
                    }
                    sw.Close();
                }
                command2.ExecuteNonQuery();

                SqlCommand command = new SqlCommand("INSERT INTO tblBomba(UserName,  MusicCode, GameResults) " +
                    "SELECT UserName, MusicCode, GameResults FROM tblUser", sqlBomba);
                command.ExecuteNonQuery();

                sqlBomba.Close();
            }

            foreach (var s in IrasytaMuzika)
            {
            
                MessageBox.Show($" {s}");
                MessageBox.Show("Muzika Irasyta", "My Box");
            }
        }

        public void play_Click(object sender, RoutedEventArgs e)
        {
            if (Vardas.Text == "Neprisijunges")
            {
                MessageBox.Show("Prisijungsi, tada ir galesi irasyti");
            }
            else
            {   
                if (veikia.IsChecked == false)
                {
                    Stop.IsEnabled = false;
                    MessageBox.Show("Patvirtink, kad sutinki su salygomis", "Please!");
                }
               
                else
                {
                    Stop.IsEnabled = true;
                    MessageBox.Show("ka tik pervedete 100 euru", "Please!");
                }
            }
            
        }

        public void veikia_Checked(object sender, RoutedEventArgs e)
        {
            FillCombo();
        }

        void FillCombo()
        {
            string query = "SELECT MusicCode FROM tblBomba WHERE UserName='" + Vardas.Text+"'" + "AND MusicCode !='"+Vardas.Text+"' AND MusicCode !=''";
            SqlCommand cmd = new SqlCommand(query, sqlBomba);
            SqlDataReader sqlDataReader;
            
            try
            {
                sqlBomba.Open();

                sqlDataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("MusicCode", typeof(string));
                dataTable.Load(sqlDataReader);
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    //    s = sqlDataReader.GetString("UserName", typeof(string));
                    //    s = sqlDataReader.GetString(1);

                    string sMusic = sqlDataReader.GetString(1);
                    Pasirinkimai.Items.Add(sMusic);
                }
                sqlDataReader.Close();
                //MessageBox.Show(s, "Jums reiktu paziureti Filmus:");

                //Pasirinkimai.ItemsSource= "@MusicCode";
                //Pasirinkimai.DataContext = dataTable; 
                sqlBomba.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Pasirinkimai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(Pasirinkimai.SelectedIndex == 0)
            {
                if (Pasirinkimai.Text == "1")
                { 
                    SoundPlayer play = new SoundPlayer(@"C:\Users\Namai\OneDrive\Desktop\wpf\WpfApp3\Bomba\Bomba\Resources\gama\Do.wav");
                    play.Load();
                    play.Play();
                    MessageBox.Show("lol");
                }                                
            }
        }
    }
}
