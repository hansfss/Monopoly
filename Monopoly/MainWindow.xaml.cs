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

namespace Monopoly_Nasdaq_Alpha_v0._01
{
    //
    //
    //        //////////////////                ////////////////         ///                    ////////////////        //////////////////          ///         //
    //       //////////////////                ////////////////         ///                    ///           //       //////////////////           ///         //
    //      ///                               ///           //         ///                    ///           //      ///                           ///         //
    //     ///                               ///           //         ///                    ///           //     ///                            ///         //
    //      ///                             ///           //         ///                    ////////////////      ///                           ///         //
    //      //////////////////             ////////////////         ///                    ///           //      //////////////////            //////////////
    //      ///////////////////           ///                      ///                    ///           //      ///////////////////           ///         //
    //                      ////         ///                      ///                    ///           //                      ////          ///         // 
    //                       ////       ///                      ///                    ///           //                       ////         ///         //
    //                      ////       ///                      ///                    ///           //                      ////          ///         //
    //      ////////////////////      ///                      ///            //      ///           //      ////////////////////          ///         //
    //      ///////////////////      ///                      /////////////////      ///           //       ///////////////////          ///         //

    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dT = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            //Splash, comienza con el programa.
            dT.Tick += new EventHandler(dt_Tick);
            dT.Interval = new TimeSpan(0, 0, 2);
            dT.Start();
        }

        private void dt_Tick(object sender, EventArgs e) 
        {
            //carga la pantalla de inicio y comienza con el menu.
            PressStart PS = new PressStart();
            PS.Show();
            dT.Stop();
            this.Close();
        }
    }
}
