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
    /// Interaction logic for Virus.xaml
    /// </summary>
    public partial class Virus : Window
    {
        public Virus()
        {
            InitializeComponent();
        }

        private void PirmasStulpelisframe_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            //PirmasStulpelisframe.Source = new Uri(@"https://www.google.com", UriKind.Absolute);

        }
        
        private void IRaudona(object sender, RoutedEventArgs e)
        {          
            PirmasStulpelisframe.Source = new Uri(@"http://127.0.0.1:5500/VirusasRickRoll.html", UriKind.Absolute);
            MessageBoxResult messageBoxResult = MessageBox.Show("You Are an Idiot?", "My Box", MessageBoxButton.YesNo);
            switch (messageBoxResult)
            {
                case MessageBoxResult.No:
                    PirmasStulpelisframe.Source = new Uri(@"http://127.0.0.1:5500/VirusasRickRoll.html", UriKind.Absolute);
                    break;
                case MessageBoxResult.Yes:
                    PirmasStulpelisframe.Source = new Uri(@"http://127.0.0.1:5500/VirusasRickRoll.html", UriKind.Absolute);
                    break;
            }

            for (int i = 0; i < 2; i++)
            {
                if (i < 5)
                {
                    //PirmasStulpelisframe.Source = new Uri(@"http://127.0.0.1:5500/VirusasRickRoll.html", UriKind.Absolute);
                    BegalinisPaleidimas begalinisPaleidimas = new BegalinisPaleidimas();
                    begalinisPaleidimas.Show();
                    begalinisPaleidimas.Focus();
                    
                }
            }
        }
       

    }
}
