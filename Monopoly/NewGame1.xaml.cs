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
using System.Windows.Shapes;

namespace Monopoly_Nasdaq_Alpha_v0._01
{
    /// <summary>
    /// Lógica de interacción para NewGame1.xaml
    /// </summary>
    public partial class NewGame1 : Window
    {
        // crea el int de numero de jugadores, par aluego ser seteado y entregado al juego.
        int PlayerNumbers = 0;
        SoundPlayer spm = new SoundPlayer();
        // es 0 para que no vaya a crearse un bug con el boton back (poco probable)
        public NewGame1()
        {
            InitializeComponent();
            imgPlayer1.Visibility = Visibility.Hidden;
            imgPlayer2.Visibility = Visibility.Hidden;
            imgPlayer3.Visibility = Visibility.Hidden;
            imgPlayer4.Visibility = Visibility.Hidden;
        }
        private void Stopmusic()
        {
            spm.Stop();
        }

        private void btnJugador2_Click(object sender, RoutedEventArgs e)
        {

            btnJugador2.Content = "READY!";
            btnJugador2.IsEnabled = false;
            PlayerNumbers++;
            lblPLayerNumber.Content = PlayerNumbers.ToString();
            if (PlayerNumbers == 1)
            {
                imgPlayer1.Margin = new Thickness(551, 134, 150, 226);
                imgPlayer1.Visibility = Visibility.Visible;
            }
            else if (PlayerNumbers == 2)
            {
                imgPlayer2.Margin = new Thickness(551, 134, 150, 226);
                imgPlayer2.Visibility = Visibility.Visible;
            }
            else if (PlayerNumbers == 3)
            {
                imgPlayer3.Margin = new Thickness(551, 134, 150, 226);
                imgPlayer3.Visibility = Visibility.Visible;
            }
            else if (PlayerNumbers == 4)
            {
                imgPlayer4.Margin = new Thickness(551, 134, 150, 226);
                imgPlayer4.Visibility = Visibility.Visible;
            }
            //cada vez que se pincha un jugador (al estilo SSB) se agrega un jugador más y desabilita el botón.            
        }

        private void btnJugador1_Click(object sender, RoutedEventArgs e)
        {

            btnJugador1.Content = "READY!";
            btnJugador1.IsEnabled = false;
            PlayerNumbers++;
            lblPLayerNumber.Content = PlayerNumbers.ToString();
            if (PlayerNumbers == 1)
            {
                imgPlayer1.Margin = new Thickness(40, 137, 661, 218);
                imgPlayer1.Visibility = Visibility.Visible;
            }
            else if (PlayerNumbers == 2)
            {
                imgPlayer2.Margin = new Thickness(40, 137, 661, 218);
                imgPlayer2.Visibility = Visibility.Visible;
            }
            else if (PlayerNumbers == 3)
            {
                imgPlayer3.Margin = new Thickness(40, 137, 661, 218);
                imgPlayer3.Visibility = Visibility.Visible;
            }
            else if (PlayerNumbers == 4)
            {
                imgPlayer4.Margin = new Thickness(40, 137, 661, 218);
                imgPlayer4.Visibility = Visibility.Visible;
            }
        }

        private void btnJugador3_Click(object sender, RoutedEventArgs e)
        {

            btnJugador3.Content = "READY!";
            btnJugador3.IsEnabled = false;
            PlayerNumbers++;
            lblPLayerNumber.Content = PlayerNumbers.ToString();
            if (PlayerNumbers == 1)
            {
                imgPlayer1.Margin = new Thickness(34, 287, 667, 73);
                imgPlayer1.Visibility = Visibility.Visible;
            }
            else if (PlayerNumbers == 2)
            {
                imgPlayer2.Margin = new Thickness(34, 287, 667, 73);
                imgPlayer2.Visibility = Visibility.Visible;
            }
            else if (PlayerNumbers == 3)
            {
                imgPlayer3.Margin = new Thickness(34, 287, 667, 73);
                imgPlayer3.Visibility = Visibility.Visible;
            }
            else if (PlayerNumbers == 4)
            {
                imgPlayer4.Margin = new Thickness(34, 287, 667, 73);
                imgPlayer4.Visibility = Visibility.Visible;
            }
        }

        private void btnJugador4_Click(object sender, RoutedEventArgs e)
        {

            btnJugador4.Content = "READY!";
            btnJugador4.IsEnabled = false;
            PlayerNumbers++;
            lblPLayerNumber.Content = PlayerNumbers.ToString();
            if (PlayerNumbers == 1)
            {
                imgPlayer1.Margin = new Thickness(545, 292, 156, 68);
                imgPlayer1.Visibility = Visibility.Visible;
            }
            else if (PlayerNumbers == 2)
            {
                imgPlayer2.Margin = new Thickness(545, 292, 156, 68);
                imgPlayer2.Visibility = Visibility.Visible;
            }
            else if (PlayerNumbers == 3)
            {
                imgPlayer3.Margin = new Thickness(545, 292, 156, 68);
                imgPlayer3.Visibility = Visibility.Visible;
            }
            else if (PlayerNumbers == 4)
            {
                imgPlayer4.Margin = new Thickness(545, 292, 156, 68);
                imgPlayer4.Visibility = Visibility.Visible;
            }
        }

        private void lblBack_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //Vuelve a la ventana y cierra la actual
            PressStart back = new PressStart();
            back.presstart();
            back.Show();
            //al cerrarla, no deberia crear bugs con la cantidad de player, de todas maneras al inicio se setea a 0
            this.Close();
        }



        private void lblStart_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //IF para que No puedas jugar Solo!
            if (PlayerNumbers == 0)
            {
                MessageBox.Show("are you serious?");
            }
            //if para que haya más de un player
            else if (PlayerNumbers== 1) 
            {
                MessageBox.Show("You cant play alone!");
            }
            else 
            //else donde todo esta OK
            {
                //crea un nuevo Juego-.
                //le entrega el numero de jugadores.
                Stopmusic();
            PlayGame pg = new PlayGame(PlayerNumbers);
            pg.Show();
            //cierra esta ventana
            this.Close();
            }
        }
    }
}
