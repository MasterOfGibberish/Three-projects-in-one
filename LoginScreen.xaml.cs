using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Bomba
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public static LoginScreen instance;
        public TextBox tb2;
        public LoginScreen()
        {
            InitializeComponent();
            instance = this;
            tb2 = Usernameas;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlConnection = new SqlConnection(@"Data Source =DESKTOP-FGIOSI5\SQLEXPRESS; Initial Catalog = LoginDB; Integrated Security=true");
            SqlConnection sqlBomba = new SqlConnection(@"Data Source =DESKTOP-FGIOSI5\SQLEXPRESS; Initial Catalog = Bomba; Integrated Security=true");
            int nulis = 0;
            string music = "";
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
                String query = " SELECT COUNT(1) From Login_Table WHERE UserName=@UserName AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", Usernameas.Text);
                cmd.Parameters.AddWithValue("@Password", Passwordas.Password);
                int cout = Convert.ToInt32(cmd.ExecuteScalar());
                if (cout >= 1)
                {
                    sqlConnection.Close();
                    
                    if (sqlBomba.State == System.Data.ConnectionState.Closed)
                        sqlBomba.Open();
                    SqlCommand command = new SqlCommand("UserAdd", sqlBomba);
                    SqlCommand command2 = new SqlCommand("UserAdd2", sqlBomba);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", Usernameas.Text.Trim());
                    command.Parameters.AddWithValue("@MusicCode", music);
                    command.Parameters.AddWithValue("@GameResults", nulis);

                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Parameters.AddWithValue("@UserName", Usernameas.Text.Trim());
                    command2.Parameters.AddWithValue("@MusicCode", music);
                    command2.Parameters.AddWithValue("@GameResults", nulis);
                    command.ExecuteNonQuery();
                    command2.ExecuteNonQuery();


                    Window1 window1 = new Window1();
                    window1.Show();
                    Window1.instance.User.Text = Usernameas.Text;                 
                    this.Close();
                    MessageBox.Show(Usernameas.Text, "Welcome");

                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect", "MY BOX");
                    Passwordas.Clear();
                    Usernameas.Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlBomba.Close();
            }
        }

        private void SignUP_Click(object sender, RoutedEventArgs e)
        {
            SignUpScreen signUpScreen = new SignUpScreen();
            signUpScreen.Show();    
            this.Close();
        }

        private void Slaptas_Click(object sender, RoutedEventArgs e)
        {

            Window1 window1 = new Window1();
            window1.Show();
            if (Usernameas.Text == string.Empty)
            {
                string prisijunkite = "Neprisijunges";
                Window1.instance.User.Text = prisijunkite;
            }
            this.Close();
            MessageBox.Show(Usernameas.Text, "Welcome");
        }
    }
}
