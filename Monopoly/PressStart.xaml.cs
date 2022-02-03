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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Monopoly_Nasdaq_Alpha_v0._01
{
    /// <summary>
    /// Lógica de interacción para PressStart.xaml
    /// </summary>
    public partial class PressStart : Window
    {
        SoundPlayer spm = new SoundPlayer();
        public PressStart()
        {
            InitializeComponent();
            TitleWithwrinkle();
        }

        private void Window_Loaded(Object sender, RoutedEventArgs e)
        {
            DoubleAnimation db = new DoubleAnimation();
                db.From = 0;
                db.To = 1;
                db.Duration = TimeSpan.FromSeconds(1);
                lblPressStart.BeginAnimation(OpacityProperty, db);

        }
        private void music()
        {
            spm.SoundLocation = @"../../Sound/TitleScreen.wav";
            spm.PlayLooping();
        }
        private void Stopmusic()
        {
            spm.Stop();
        }

        private void lblPressStart_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            music();
            presstart();
        }
        public void presstart()
        {
            ///CUANDO COMIENZA:
            // cambia el contenido de texto al principal (se crean)
            lblPressStart.Content = "";
            lblNewGame.Content = "New Game";
            lblExit.Content = "Exit";
            lblConfiguration.Content = "Instructions";
            ///////////////////////////////////////////////////////////////////
            /////////////////animacion////////////////////////////////////////
            /////////////////////////////////////////////////////////////////
            DoubleAnimation db = new DoubleAnimation();
            db.From = 0;
            db.To = 1;
            db.Duration = TimeSpan.FromSeconds(1);
            lblConfiguration.BeginAnimation(OpacityProperty, db);
            lblExit.BeginAnimation(OpacityProperty, db);
            lblNewGame.BeginAnimation(OpacityProperty, db);
            lblPressStart.Margin = new Thickness(448, 482, -136, -116);
        }

        private void lblExit_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            
            
            spm.SoundLocation = @"../../Sound/ClickSound.wav";
            spm.Play();
            this.Close();
        }

        private void lblConfiguration_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //desaparece texto y crea animaciones para las configuraciones
            config.Margin = new Thickness(0, 229, 0, 0);
            config.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            DoubleAnimation db = new DoubleAnimation();
            db.From = 0;
            db.To = 600;
            db.Duration = TimeSpan.FromSeconds(1);
            db.EasingFunction = new QuarticEase();
            config.BeginAnimation(WidthProperty, db);
            //mueve los textos fuera de la pantalla
            lblVersion.Margin = new Thickness(448, 482, -136, -116);
            lblNewGame.Margin = new Thickness(448, 482, -136, -116);
            lblExit.Margin = new Thickness(448, 482, -136, -116);
            lblConfiguration.Margin = new Thickness(448, 482, -136, -116);
            lblconfig_back.Margin = new Thickness(623, 264, 0, 0);
            lblconfig_next.Margin = new Thickness(623, 364, 0, 0);
            //todas las opciones tienen que:
            // 1) crear label sin content pero con el nombre correspondiente
            // 2) moverla con lbl.margin = new Thickness(posicion)
            // 3) ... (ver en boton back)
            config.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            DoubleAnimation TextA = new DoubleAnimation();
            TextA.From = 0;
            TextA.To = 100;
            TextA.Duration = TimeSpan.FromSeconds(4);
            TextA.EasingFunction = new ExponentialEase();
            lblconfig_back.BeginAnimation(WidthProperty, TextA);
            /////////////////////////////////////////////////////////////
            lblconfig_next.BeginAnimation(WidthProperty, TextA);
            //ideas de configuracion: (todos estos cambios son para el XAML de playgame)
            // resolucion (un int que cambie el widht y el height )
            // pantalla completa (cambiar de WindowStyle="ThreeDBorderWindow" a "None" o vice versa)
            imgInstructivo2.Margin = new Thickness(450, 255, 269, 117);
            imgInstructivo1.Margin = new Thickness(439, 358, 269, 18);
            imgInstructivo3.Margin = new Thickness(134, 245, 575, 122);
            imgInstructivo4.Margin = new Thickness(134, 348, 575, 15);
            lblInstructivo2.Margin = new Thickness(225, 365, 0, 0);
            lblInstructivo1.Margin = new Thickness(225, 245, 0, 0);
            lblInstructivo3.Margin = new Thickness(536, 266, 0, 0);
            lblInstructivo4.Margin = new Thickness(536, 360, 0, 0);


        }

        private void lblNewGame_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //cierra esta vertana y abre la del juego nuevo
            NewGame1 newmenu = new NewGame1();
            newmenu.Show();
            this.Close();
        }

        private void lblconfig_back_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // 3) mover fuera del screen las opciones 
            // volver las opciones del menu principal a su posicion inicial
            config.Margin = new Thickness(1029, 395, -323, 0);
            TitleWithwrinkle();
            lblNewGame.Margin = new Thickness(193, 291, 0, 0);
            lblExit.Margin = new Thickness(193, 380, 0, 0);
            lblConfiguration.Margin = new Thickness(193, 333, 0, 0);
            lblconfig_back.Margin = new Thickness(1029, 395, -323, 0);
            lblconfig_previous.Margin = new Thickness(60300, 364, 0, 0);
            imgInstructivo2.Margin = new Thickness(45000, 25500, 269, 117);
            imgInstructivo1.Margin = new Thickness(43900, 35800, 269, 18);
            imgInstructivo3.Margin = new Thickness(13400, 24500, 575, 122);
            imgInstructivo4.Margin = new Thickness(13400, 34800, 575, 15);
            imgInstructivo5.Margin = new Thickness(50500, 41400, 400, 20 );
            lblInstructivo2.Margin = new Thickness(22500, 36500, 0, 0);
            lblInstructivo1.Margin = new Thickness(22500, 24005, 0, 0);
            lblInstructivo3.Margin = new Thickness(53600, 26600, 0, 0);
            lblInstructivo4.Margin = new Thickness(53600, 36000, 0, 0);
            lblconfig_next.Margin = new Thickness(62300, 364, 0, 0);
            lblInstructivo5.Margin = new Thickness(30500, 30400, 0, 0);
        }

        private void lblconfig_next_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //siguiente pagina de instrucciones
            //solo cambia el orden de las cosas, pagina dos, no agregar una tercera porque va a necesitar un int q lata
            lblconfig_previous.Margin = new Thickness(603, 364, 0, 0);
            lblconfig_next.Margin = new Thickness(45000, 25500, 269, 117);
            imgInstructivo2.Margin = new Thickness(45000, 25500, 269, 117);
            imgInstructivo1.Margin = new Thickness(43900, 35800, 269, 18);
            imgInstructivo3.Margin = new Thickness(13400, 24500, 575, 122);
            imgInstructivo4.Margin = new Thickness(13400, 34800, 575, 15);
            imgInstructivo5.Margin = new Thickness(140, 260, 570, 28);
            lblInstructivo2.Margin = new Thickness(22500, 36500, 0, 0);
            lblInstructivo1.Margin = new Thickness(22500, 24005, 0, 0);
            lblInstructivo3.Margin = new Thickness(53600, 26600, 0, 0);
            lblInstructivo4.Margin = new Thickness(53600, 36000, 0, 0);
            lblInstructivo5.Margin = new Thickness(250, 260, 0, 0);
        }

        private void lblconfig_previous_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //vuelve a la pagina inicial de instrucciones
            //no más mueve las cosas
            lblconfig_previous.Margin = new Thickness(60300, 364, 0, 0);
            imgInstructivo2.Margin = new Thickness(450, 255, 269, 117);
            imgInstructivo1.Margin = new Thickness(439, 358, 269, 18);
            imgInstructivo3.Margin = new Thickness(134, 245, 575, 122);
            imgInstructivo4.Margin = new Thickness(134, 348, 575, 15);
            lblInstructivo2.Margin = new Thickness(225, 365, 0, 0);
            lblInstructivo1.Margin = new Thickness(225, 245, 0, 0);
            lblInstructivo3.Margin = new Thickness(536, 266, 0, 0);
            lblInstructivo4.Margin = new Thickness(536, 360, 0, 0);
            imgInstructivo5.Margin = new Thickness(50500, 41400, 400, 20);
            lblconfig_next.Margin = new Thickness(623, 364, 0, 0);
            lblInstructivo5.Margin = new Thickness(30500, 30400, 0, 0);
        }

        private void TitleWithwrinkle()
        {
            //solo alarguen la lista por si hay ideas de textos
            //ni si quiera sé porqué hice esto
            lblVersion.Margin = new Thickness(355, 218, 0, 0);
            Random title = new Random();
            int whattitle = title.Next(1, 23);
            if (whattitle == 1)
            {
                lblVersion.Content = "Ahora con menos codigo";
            }
            else if (whattitle == 2)
            {
                lblVersion.Content = "Esto no es una referencia a Minecraft!";
            }
            else if (whattitle == 3)
            {
                lblVersion.Content = "Por favor no nos ponga un 1";
            }
            else if (whattitle == 4)
            {
                lblVersion.Content = "¿Como?, ¿que se cae?";
            }
            else if (whattitle == 5)
            {
                lblVersion.Content = "Del internet que no está hecho en PHP";
            }
            else if (whattitle == 6)
            {
                lblVersion.Content = "Ni pensamos en Java la verdad";
            }
            else if (whattitle == 7)
            {
                lblVersion.Content = "Bolsa de Comercio";
            }
            else if (whattitle == 8)
            {
                lblVersion.Content = "Nasdaq-100!";
            }
            else if (whattitle == 9)
            {
                lblVersion.Content = "Sugar Free";
            }
            else if (whattitle == 10)
            {
                lblVersion.Content = "por qué el codigo está en Spanglish?, Hans?";
            }
            else if (whattitle == 11)
            {
                lblVersion.Content = "intentamos evitar todos los llantos en comentarios de codigo";
            }
            else if (whattitle == 12)
            {
                lblVersion.Content = "TF2 nació de Quake";
            }
            else if (whattitle == 13)
            {
                lblVersion.Content = "Sin base de datos (Thank god)";
            }
            else if (whattitle == 14)
            {
                lblVersion.Content = "Nasdaq-100!";
            }
            else if (whattitle == 15)
            {
                lblVersion.Content = "Nasdaq-100!";
            }
            else if (whattitle == 16)
            {
                lblVersion.Content = "Nasdaq-100!";
            }
            else if (whattitle == 17)
            {
                lblVersion.Content = "¡Bolsa de Comercio!";
            }
            else if (whattitle == 18)
            {
                lblVersion.Content = "¡Bolsa de Comercio!";
            }
            else if (whattitle == 19)
            {
                lblVersion.Content = "¡Bolsa de Comercio!";
            }
            else if (whattitle == 20)
            {
                lblVersion.Content = "Con más OOP que nunca";
            }
            else if (whattitle == 21)
            {
                lblVersion.Content = "Stonks!";
            }
            else if (whattitle == 22)
            {
                lblVersion.Content = "Ah caray!";
            }
        }

        private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Creditos creditos = new Creditos();
            creditos.Show();
            this.Close();
        }
        public void changelogo()
        {
            ImageEasterEgg.Margin = new Thickness(57, 73, 57, 226);
        }
    }
}
    
