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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Monopoly_Nasdaq_Alpha_v0._01
{
    /// <summary>
    /// Lógica de interacción para Creditos.xaml
    /// </summary>
    public partial class Creditos : Window
    {
        public Creditos()
        {
            InitializeComponent();
            DoubleAnimation db = new DoubleAnimation();
            db.From = 0;
            db.To = 1;
            db.Duration = TimeSpan.FromSeconds(1);
            lblT4P.BeginAnimation(OpacityProperty, db);
            lblthanks.BeginAnimation(OpacityProperty, db);

        }

        private void lblback_Click(object sender, RoutedEventArgs e)
        {
            PressStart ps = new PressStart();
            ps.changelogo();
            ps.Show();
            ps.presstart();
            this.Close();
        }
    }
}
