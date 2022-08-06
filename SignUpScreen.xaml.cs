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
    /// Interaction logic for SignUpScreen.xaml
    /// </summary>
    public partial class SignUpScreen : Window
    {
        string connectionString = @"Data Source =DESKTOP-FGIOSI5\SQLEXPRESS; Initial Catalog = UserRegistrationDB; Integrated Security=true";

        string ConnectionString = @"Data Source =DESKTOP-FGIOSI5\SQLEXPRESS; Initial Catalog = LoginDB; Integrated Security=true";
        SqlCommand cmd2;
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();

        public SignUpScreen()
        {
            InitializeComponent();
        }

        private void Prisiregistravimui_Click(object sender, RoutedEventArgs e)
        {
            if (usernamui.Text == "" || passwordui.Password == "")
            {
                MessageBox.Show("Please fill the neccessary fields", "MY BOX");
            }

            else if (passwordui.Password != confiRninimui.Password)
            {
                MessageBox.Show("Passwords do not match", "MY BOX");
                passwordui.Clear();
                confiRninimui.Clear();
            }

            else
            {
                using (SqlConnection RegistrationCon = new SqlConnection(connectionString))
                {
                    RegistrationCon.Open();
                    cmd2 = new SqlCommand("SELECT * FROM dbo.TblUser WHERE UserName='" + usernamui.Text + "'", RegistrationCon);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    da2.Fill(ds2);
                    int k = ds2.Tables[0].Rows.Count;
                    if (k > 0)
                    {
                        MessageBox.Show("Username " + usernamui.Text + "Already excist, please choose another", "MY BOX");
                        usernamui.Clear();
                        ds2.Clear();
                    }

                    else
                    {
                                                  
                        SqlCommand command = new SqlCommand("UserAdd", RegistrationCon);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FirstName", Vardui.Text.Trim());
                        command.Parameters.AddWithValue("@LastName", Pavardei.Text.Trim());
                        command.Parameters.AddWithValue("@Contact ", Numeriui.Text.Trim());
                        command.Parameters.AddWithValue("@Adress", gmailui.Text.Trim());
                        command.Parameters.AddWithValue("@UserName", usernamui.Text.Trim());
                        command.Parameters.AddWithValue("@Password ", passwordui.Password.Trim());

                        command.ExecuteNonQuery();


                        try
                        {
                            using (SqlConnection LoginCon = new SqlConnection(ConnectionString))
                            {
                                LoginCon.Open();
                                SqlCommand Command = new SqlCommand("Login_Table_ADD", LoginCon);
                                Command.CommandType = CommandType.StoredProcedure;
                                Command.Parameters.AddWithValue("@UserName", usernamui.Text.Trim());
                                Command.Parameters.AddWithValue("@Password ", passwordui.Password.Trim());
                                Command.ExecuteNonQuery();
                                Clear();

                            }
                            MessageBox.Show("Registration is succesful", "MY BOX");

                            LoginScreen loginscreen = new LoginScreen();
                            loginscreen.Show();
                            loginscreen.Focus();
                            this.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "KLAIDA");
                        }

                    }

                }
            }
        }
        void Clear()
        {
            Vardui.Text = Pavardei.Text = Numeriui.Text = gmailui.Text = usernamui.Text = passwordui.Password =
                confiRninimui.Password = "";
        }
    }

}
