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
using System.Diagnostics;
using System.Media;

namespace Monopoly_Nasdaq_Alpha_v0._01
{
    /// <summary>
    /// Lógica de interacción para PlayGame.xaml
    /// </summary>
    public partial class PlayGame : Window
    {
        SoundPlayer spm = new SoundPlayer();
        int rc { get; set; }
        //setea turno en 0 cuando inicia 
        int Turnoactual = 0;
        //crea el turno, es un queue
        Queue<int> Turn = new Queue<int>();
        //le entra el numero de jugadores
        int playernumber;
        //crea la lista de casillas y la de personajes
        List<holdings> Spaces = new List<holdings>();
        List<characters> players = new List<characters>();
        //crea el dado
        Dice dice = new Dice();
        //characters
        characters player1 = new characters(1);
        characters player2 = new characters(2);
        characters player3 = new characters(3);
        characters player4 = new characters(4);
        //tarjetas
        Chance chance = new Chance();
        Nasdaq nasdaq = new Nasdaq();
        //lista de fichas
        List<Image> fichas = new List<Image>();
        //lista de imagenes de fichas
        List<Image> figures = new List<Image>();

        public PlayGame(int PlayerNumbers)
        {
            PlayGameMusic();
            InitializeComponent();
            //metodo donde se crean todas las casillas
            StartOps();
            //metodo donde añade los jugadores a la lista
            //grid para intercambiar propiedades
            //var fichas = new List<Image>();
            if (PlayerNumbers == 3)
            {//en caso de que solo existan 3 jugadores
                player4.SetID(0);//elimina ID jugador 4
                player1.SetMoney(1500);
                player1.setJail(false);
                player1.SetPosition(0);
                player2.SetMoney(1500);
                player2.setJail(false);
                player2.SetPosition(0);
                player3.SetMoney(1500);
                player3.setJail(false);
                player3.SetPosition(0);
                players.Add(player1);
                players.Add(player2);
                players.Add(player3);
                //setea la posicion, e dinero y que no estén en carcel
                imgplayer1.Margin = new Thickness(549, 395, 217, 25);
                imgplayer2.Margin = new Thickness(549, 395, 217, 25);
                imgplayer3.Margin = new Thickness(549, 395, 217, 25);
                //fichas se agregan a lista para fichas
                fichas.Add(imgplayer1);
                fichas.Add(imgplayer2);
                fichas.Add(imgplayer3);
                //fichas se agregan a otra lista para mostrar turnos
                figures.Add(Facep1);
                figures.Add(Facep2);
                figures.Add(Facep3);
                //mueve las respectivas fotos para a posicion 0 
                Turn.Enqueue(1);
                Turn.Enqueue(2);
                Turn.Enqueue(3);
                //agrega 3 turnos.
                lblDataPlayer1.Content = "$" + player1.GetMoney().ToString();
                lblDataPlayer2.Content = "$" + player2.GetMoney().ToString();
                lblDataPlayer3.Content = "$" + player3.GetMoney().ToString();
                playernumber = 3;
            }
            else if (PlayerNumbers == 2)
            {//lo mismo que el primero
                player4.SetID(0);
                player3.SetID(0);
                player1.SetMoney(1500);
                player1.setJail(false);
                player1.SetPosition(0);
                player2.SetMoney(1500);
                player2.setJail(false);
                player2.SetPosition(0);
                players.Add(player1);
                players.Add(player2);
                imgplayer1.Margin = new Thickness(549, 395, 217, 25);
                imgplayer2.Margin = new Thickness(549, 395, 217, 25);
                fichas.Add(imgplayer1);
                fichas.Add(imgplayer2);
                figures.Add(Facep1);
                figures.Add(Facep2);
                Turn.Enqueue(1);
                Turn.Enqueue(2);
                lblDataPlayer1.Content = "$" + player1.GetMoney().ToString();
                lblDataPlayer2.Content = "$" + player2.GetMoney().ToString();
                playernumber = 2;
            }
            else
            {//en caso que hayan 4 jugadores
                player1.SetMoney(1500);
                player1.setJail(false);
                player1.SetPosition(0);
                player2.SetMoney(1500);
                player2.setJail(false);
                player2.SetPosition(0);
                player3.SetMoney(1500);
                player3.setJail(false);
                player3.SetPosition(0);
                player4.SetMoney(1500);
                player4.setJail(false);
                player4.SetPosition(0);
                players.Add(player1);
                players.Add(player2);
                players.Add(player3);
                players.Add(player4);
                imgplayer1.Margin = new Thickness(549, 395, 217, 25);
                imgplayer2.Margin = new Thickness(549, 395, 217, 25);
                imgplayer3.Margin = new Thickness(549, 395, 217, 25);
                imgplayer4.Margin = new Thickness(549, 395, 217, 25);
                fichas.Add(imgplayer1);
                fichas.Add(imgplayer2);
                fichas.Add(imgplayer3);
                fichas.Add(imgplayer4);
                figures.Add(Facep1);
                figures.Add(Facep2);
                figures.Add(Facep3);
                figures.Add(Facep4);
                Turn.Enqueue(1);
                Turn.Enqueue(2);
                Turn.Enqueue(3);
                Turn.Enqueue(4);
                lblDataPlayer1.Content = "$" + player1.GetMoney().ToString();
                lblDataPlayer2.Content = "$" + player2.GetMoney().ToString();
                lblDataPlayer3.Content = "$" + player3.GetMoney().ToString();
                lblDataPlayer4.Content = "$" + player4.GetMoney().ToString();
                playernumber = 4;
            }
        }

        private void btnBack_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro?", "¡Vas a salir!",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                NewGame1 ng = new NewGame1();
                ng.Show();
                this.Close();
                musicback();
            }

        }

        private void StartOps()
        {
            //CREA TODAS LAS CASILLAS CON SU RESPECTIVA INFORMACION
            holdings s0 = new holdings(Color.None, 549, 395, 217, 25, 0, 999999999, "Start", 999999999);
            holdings s1 = new holdings(Color.Purple, true, false, 503, 402, 263, 18, 1, 60, "BCI", 1);
            holdings s2 = new holdings(Color.None, 466, 402, 300, 18, 2, 0, "Nasdaq Card", 1);
            holdings s3 = new holdings(Color.Purple, true, true, 429, 402, 337, 18, 3, 60, "Santander", 1);
            holdings s4 = new holdings(Color.None, 392, 402, 374, 18, 4, 0, "Fast Travel!", 1);
            holdings s5 = new holdings(Color.None, 357, 402, 409, 18, 5, 0, "Nasdaq Card", 1);
            holdings s6 = new holdings(Color.Skyblue, true, false, 322, 402, 444, 18, 6, 100, "Nike", 1);
            holdings s7 = new holdings(Color.None, 285, 402, 481, 18, 7, 0, "Chance Card", 1);
            holdings s8 = new holdings(Color.Skyblue, true, false, 248, 402, 518, 18, 8, 100, "LV", 1);
            holdings s9 = new holdings(Color.Skyblue, true, false, 211, 405, 555, 15, 9, 120, "Adidas", 1);
            holdings s10 = new holdings(Color.None, 169, 392, 597, 28, 10, 0, "Jail", 1);
            holdings s11 = new holdings(Color.Magenta, true, false, 159, 356, 607, 64, 11, 140, "Facebook", 2);
            holdings s12 = new holdings(Color.None, 159, 324, 607, 96, 12, 0, "Etoro", 1);
            holdings s13 = new holdings(Color.Magenta, true, false, 159, 292, 607, 128, 13, 140, "Paypal", 2);
            holdings s14 = new holdings(Color.Magenta, true, false, 159, 260, 607, 160, 14, 160, "Google", 2);
            holdings s15 = new holdings(Color.None, 159, 229, 607, 191, 15, 0, "Nasdaq Card", 1);
            holdings s16 = new holdings(Color.Orange, true, false, 159, 198, 607, 222, 16, 180, "Pepsi", 2);
            holdings s17 = new holdings(Color.None, 159, 166, 607, 254, 17, 0, "Nasdaq Card", 1);
            holdings s18 = new holdings(Color.Orange, true, false, 159, 134, 607, 286, 18, 180, "Coca-Cola", 2);
            holdings s19 = new holdings(Color.Orange, true, false, 159, 102, 607, 318, 19, 200, "Starbucks", 2);
            holdings s20 = new holdings(Color.None, 161, 59, 605, 361, 20, 0, "The Chair", 1);
            holdings s21 = new holdings(Color.Red, true, false, 211, 54, 555, 366, 21, 220, "Volkwagen", 3);
            holdings s22 = new holdings(Color.None, 248, 54, 518, 366, 22, 0, "Chance Card", 1);
            holdings s23 = new holdings(Color.Red, true, false, 284, 54, 482, 366, 23, 220, "Ferrari", 3);
            holdings s24 = new holdings(Color.Red, true, false, 321, 54, 445, 366, 24, 240, "Porsche", 3);
            holdings s25 = new holdings(Color.None, 357, 54, 409, 366, 25, 0, "Chance Card", 1);
            holdings s26 = new holdings(Color.Yellow, true, false, 392, 54, 374, 366, 26, 260, "Carl Jr", 3);
            holdings s27 = new holdings(Color.Yellow, true, false, 429, 54, 337, 366, 27, 260, "Burger King", 3);
            holdings s28 = new holdings(Color.None, 466, 54, 300, 366, 28, 0, "Fast Travel", 1);
            holdings s29 = new holdings(Color.Yellow, true, false, 503, 54, 263, 366, 29, 280, "McDonald's", 3);
            holdings s30 = new holdings(Color.None, 551, 58, 215, 362, 30, 0, "Jail", 1);
            holdings s31 = new holdings(Color.Green, true, false, 558, 102, 208, 318, 31, 300, "Mastercard", 4);
            holdings s32 = new holdings(Color.Green, true, false, 558, 134, 208, 286, 32, 300, "Visa", 4);
            holdings s33 = new holdings(Color.None, 558, 166, 208, 254, 33, 0, "Etoro", 1);
            holdings s34 = new holdings(Color.Green, true, false, 558, 198, 208, 222, 34, 320, "American Express", 4);
            holdings s35 = new holdings(Color.None, 558, 229, 208, 191, 35, 0, "Fast Travel", 1);
            holdings s36 = new holdings(Color.None, 558, 260, 208, 160, 36, 0, "Chance Card", 1);
            holdings s37 = new holdings(Color.Blue, true, false, 558, 292, 208, 128, 37, 350, "H&M", 4);
            holdings s38 = new holdings(Color.None, 558, 324, 208, 96, 38, 0, "Tax", 1);
            holdings s39 = new holdings(Color.Blue, true, false, 558, 356, 208, 64, 39, 400, "Tommy Hilfiger", 4);
            Spaces.Add(s0);
            Spaces.Add(s1);
            Spaces.Add(s2);
            Spaces.Add(s3);
            Spaces.Add(s4);
            Spaces.Add(s5);
            Spaces.Add(s6);
            Spaces.Add(s7);
            Spaces.Add(s8);
            Spaces.Add(s9);
            Spaces.Add(s10);
            Spaces.Add(s11);
            Spaces.Add(s12);
            Spaces.Add(s13);
            Spaces.Add(s14);
            Spaces.Add(s15);
            Spaces.Add(s16);
            Spaces.Add(s17);
            Spaces.Add(s18);
            Spaces.Add(s19);
            Spaces.Add(s20);
            Spaces.Add(s21);
            Spaces.Add(s22);
            Spaces.Add(s23);
            Spaces.Add(s24);
            Spaces.Add(s25);
            Spaces.Add(s26);
            Spaces.Add(s27);
            Spaces.Add(s28);
            Spaces.Add(s29);
            Spaces.Add(s30);
            Spaces.Add(s31);
            Spaces.Add(s32);
            Spaces.Add(s33);
            Spaces.Add(s34);
            Spaces.Add(s35);
            Spaces.Add(s36);
            Spaces.Add(s37);
            Spaces.Add(s38);
            Spaces.Add(s39);
        }

        public void actualizarDinero()// metodo para actualizar dinero y empresas en cajas de texto y combo boxes de cada jugador
        {
            lblDataPlayer1.Content = "$" + player1.GetMoney().ToString();
            lblDataPlayer2.Content = "$" + player2.GetMoney().ToString();
            lblDataPlayer3.Content = "$" + player3.GetMoney().ToString();
            lblDataPlayer4.Content = "$" + player4.GetMoney().ToString();
        }

        public void actualizarEmpresas()//metodo para actualizar las listas de empresas despues de un trade
        {
            cboPropiedades1.Items.Clear();
            cboPropiedades2.Items.Clear();
            cboPropiedades3.Items.Clear();
            cboPropiedades4.Items.Clear();

            List<holdings> empresas1 = new List<holdings>();
            List<holdings> empresas2 = new List<holdings>();
            List<holdings> empresas3 = new List<holdings>();
            List<holdings> empresas4 = new List<holdings>();

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].GetID() == 1)
                {
                    empresas1 = players[i].getHoldings();
                    for (int j = 0; j < empresas1.Count; j++)
                    {
                        cboPropiedades1.Items.Add(empresas1[j].getName() + ", " + empresas1[j].getColor());
                    }
                }
                if (players[i].GetID() == 2)
                {
                    empresas2 = players[i].getHoldings();
                    for (int j = 0; j < empresas2.Count; j++)
                    {
                        cboPropiedades2.Items.Add(empresas2[j].getName() + ", " + empresas2[j].getColor());
                    }
                }
                if (players[i].GetID() == 3)
                {
                    empresas3 = players[i].getHoldings();
                    for (int j = 0; j < empresas3.Count; j++)
                    {
                        cboPropiedades3.Items.Add(empresas3[j].getName() + ", " + empresas3[j].getColor());
                    }
                }
                if (players[i].GetID() == 4)
                {
                    empresas4 = players[i].getHoldings();
                    for (int j = 0; j < empresas4.Count; j++)
                    {
                        cboPropiedades4.Items.Add(empresas4[j].getName() + ", " + empresas4[j].getColor());
                    }
                }
            }
        }

        public void mostrarTurno()
        {
            txtTurno.Text = Turnoactual.ToString();
        }

        public bool jugadorSinDinero()//si el metodo devuelve true, el juego tiene que determinar el ganador
        {
            bool sinDinero = false;

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].bancarrota() == true)
                {
                    sinDinero = true;
                }
            }
            return sinDinero;
        }

        public void determinarGanador()
        {
            double efectivo = 0;
            double valorActivos = 0;
            double riquezas = 0;// en riquezas se suma efectivo y valorActivos solo si la suma de esos dos es mayor que el valor de riquezas

            characters ganador = new characters();//nuevo character donde se asigna el jugador con mayor dinero

            for (int i = 0; i < players.Count; i++)
            {
                efectivo = 0;
                valorActivos = 0;
                efectivo = players[i].GetMoney();
                for (int j = 0; j < players[i].getHoldings().Count; j++)
                {
                    valorActivos += players[i].getHoldings()[j].getPrice();//se suma los valores de los activos
                }

                if (efectivo + valorActivos > riquezas)//si es verdad, ganador se asigna a players[i]
                {
                    riquezas = 0;
                    riquezas = efectivo + valorActivos;
                    ganador = players[i];
                }
            }
            MessageBox.Show("El ganador es player " + ganador.GetID().ToString());
        }//revisar

        public void terminarJuego()
        {
            MainWindow M = new MainWindow();
            M.ShowDialog();
            this.Close();
        } //revisar

        public void iniciarTurnos()
        {
            //cada vez que inicia
            Turn.Dequeue();
            //se quita un turno
            Turnoactual++;
            //y el turno actual sube (esto solo sirve para en caso de que se planee saber quien mueve, es decir, indica quien se está moviendo)
            //cuando turno actual es mayor al numero de jugadores se repite, cosa de que si son 4 jugadores, solamente pueden haber 4 turnos
            if (Turnoactual > playernumber)
            {
                Turnoactual = 1;
            }

            int jugadorActual = Turnoactual;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].GetID() == jugadorActual)
                {
                    if (players[i].getJail() == false)
                    {
                        int valor = dice.throwDice();
                        players[i].SetPosition(players[i].GetPosition() + valor);
                        if (players[i].GetPosition() >= 40)
                        {//si el jugador 1 esta en la posicion superior a 40, significa que ya dio una vuelta
                            players[i].SetPosition(players[i].GetPosition() - 40); //se le quita 40 posiciones para que si está en la 43, quede en la 3. 
                            players[i].SetMoney(players[i].GetMoney() + 200); // se le da el dinero por su vuelta
                        }
                        /////////////////////////////////////////////////
                        //////////// M O V I M I E N T O ///////////////
                        ///////////////////////////////////////////////
                        for (int j = 0; j <= players[i].GetPosition(); j++)
                        {/////mientras j sea menor que o igual a su posicion actual, se le agrega uno a j/////
                            if (j >= 40)
                            {
                                j = 0;
                                players[i].SetPosition(0);
                                players[i].SetMoney(players[i].GetMoney() + 200);

                                for (int k = 0; k < fichas.Count; k++)
                                {//fichas es la lista donde se almacenan las fichas de cada jugador
                                    if (i == k)//si i = k, se mueve la ficha que corresponde al jugadorActual
                                    {
                                        txtMapData.Text = "Random event player" + players[i].GetID() + ": ¡Dirígete a 'GO' y ganas dinero!";
                                        fichas[k].Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y),
                                                           Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));
                                    }
                                }
                            }
                            if (Spaces[j].position.Equals(players[i].GetPosition()))
                            {/////si el espacio es equivalente a la posicion actual, moverlo a la posicion de ese espacio/////
                                for (int k = 0; k < fichas.Count; k++)
                                {
                                    if (i == k)
                                    {
                                        fichas[k].Margin = new Thickness(Convert.ToDouble(Spaces[j].axis.x), Convert.ToDouble(Spaces[j].axis.y),
                                                           Convert.ToDouble(Spaces[j].axis.z), Convert.ToDouble(Spaces[j].axis.s));
                                    }
                                }
                            }
                            if (Spaces[30].position.Equals(players[i].GetPosition()))
                            {/////si cae a la carcel, se mueve a la carcel/////
                                players[i].jailed();
                                players[i].SetPosition(10);
                                for (int k = 0; k < fichas.Count; k++)
                                {
                                    if (i == k)
                                    {
                                        fichas[k].Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y),
                                                           Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                                    }
                                }
                            }
                        }//imprime los dos dados en los espacios de los dados.
                        txtDice1.Text = dice.getDice1().ToString();
                        txtDice2.Text = dice.getDice2().ToString();
                    }
                    else
                    {//metodo para salir de la carcel
                        escapeJail();
                    }

                    if (Spaces[38].position.Equals(players[i].GetPosition()))
                    {
                        pagarImpuestos(); ////////////IMPUESTOS////////////
                    }
                    else if (Spaces[4].position.Equals(players[i].GetPosition()) || Spaces[28].position.Equals(players[i].GetPosition()) || Spaces[35].position.Equals(players[i].GetPosition()))
                    {
                        tomarVuelo(); ////////////AVIONES////////////
                    }
                    if (Spaces[7].position.Equals(players[i].GetPosition()) || Spaces[22].position.Equals(players[i].GetPosition()) || Spaces[25].position.Equals(players[i].GetPosition()) || Spaces[36].position.Equals(players[i].GetPosition()))
                    {
                        cartaChance(); ////////////CARTA CHANCE////////////
                    }
                    if (Spaces[2].position.Equals(players[i].GetPosition()) || Spaces[5].position.Equals(players[i].GetPosition()) || Spaces[15].position.Equals(players[i].GetPosition()) || Spaces[17].position.Equals(players[i].GetPosition()))
                    {
                        cartaNasdaq(); ////////////CARTA NASDAQ////////////
                    }

                    for (int j = 0; j < figures.Count; j++)
                    {//lista de imagenes de fichas, para recordar que ficha corresponde a que jugador
                        if (i == j)
                        {
                            figures[j].Margin = new Thickness(723, 236, 37, 173.6);
                        }
                        else
                        {//estas fichas se ponen fuera del tablero
                            figures[j].Margin = new Thickness(1018, 263, -258, 146.6);
                        }
                    }
                }
            }
            actualizarDinero();
        }

        public void escapeJail()//metodo que determina si el jugador puede salir de la carcel
        {
            List<int> tarjetas = new List<int>();
            int jugadorActual = Turnoactual;
            for (int i = 0; i < players.Count; i++)
            {                                                                      //lista de cartas para escapar de la carcel
                if (players[i].GetID() == jugadorActual)                                 //|
                {                                                                        //|
                    int valor = dice.throwDice();                                        //V
                    if (dice.isDouble() || players[i].getTurnsJail() == 3 || players[i].getTarjetas().Count != 0)
                    {//condiciones para escapar de la carcel
                        tarjetas = players[i].getTarjetas();//lista de tarjetas para escapar
                        tarjetas.Remove(0);//se elimina una carta de la lista
                        players[i].SetTurnsJail(0);
                        players[i].free();
                        players[i].SetPosition(players[i].GetPosition() + valor);

                        for (int j = 0; j < players[i].GetPosition(); j++)
                        {//loop para encontrar posicion del jugador en el tablero
                            if (Spaces[j].position.Equals(players[i].GetPosition()))
                            {
                                for (int k = 0; k < fichas.Count; k++)
                                {//loop para encontrar ficha que corresponda a players[i]
                                    if (i == k)
                                    {
                                        fichas[k].Margin = new Thickness(Convert.ToDouble(Spaces[j].axis.x), Convert.ToDouble(Spaces[j].axis.y),
                                                          Convert.ToDouble(Spaces[j].axis.z), Convert.ToDouble(Spaces[j].axis.s));
                                    }
                                }
                            }
                        }
                    }
                    if (dice.isDouble() == false)
                    {
                        players[i].SetTurnsJail(players[i].getTurnsJail() + 1);
                    }
                }
            }
        }

        public void pagarJugadores()
        {
            int jugadorActual = Turnoactual;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].GetID() == jugadorActual)
                {
                    int position = players[i].GetPosition();

                    if (Spaces[position].getOwner() == 0 || Spaces[position].getOwner() == jugadorActual)
                    {//este if es para ver si la empresa no tiene dueño o si el dueño es el juagdorActual
                        players[i].GetID();// este linea no hace nada
                    }
                    else if (Spaces[position].getOwner() != jugadorActual)
                    {
                        for (int j = 0; j < players.Count; j++)
                        {
                            if (players[j].GetID() == Spaces[position].getOwner() && Spaces[position].getPrestamo() == false)
                            {
                                double monto = Spaces[position].getPrice() / 10;
                                int id = players[j].GetID();
                                Spaces[position].LevelUp();
                                txtMapData.Text = "tienes que pagar $" + monto + " al player " + id;
                                //MessageBox.Show("tienes que pagar $" + monto + " al player " + id);
                                players[i].pagar(monto, players[j]);
                                break;
                            }
                        }
                    }
                }
            }
            actualizarDinero();
        }

        public void pagarImpuestos()//metodo para pagar impuestos si el jugador cae en la casilla de impuestos
        {
            int jugadorActual = Turnoactual;
            for (int i = 0; i < players.Count; i++)
            {//encontramos el jugadorActual
                if (players[i].GetID() == jugadorActual)
                {
                    if (players[i].GetMoney() >= 300)
                    {//si tiene suficiente dinero, le quitamos el monto del impuesto
                        double dinero = players[i].GetMoney() - 300;
                        txtMapData.Text = "Tienes que pagar impuestos, tienes " + players[i].GetMoney() + "$ pero quedas con " + dinero;
                        players[i].SetMoney(players[i].GetMoney() - 300);
                    }
                    else
                    {// si no tiene suficiente dinero, se va a la carcel
                        txtMapData.Text = "No tienes para pagar impuestos! \n pasas la noche en la cárcel!";
                        players[i].SetPosition(10);
                    }
                }
                break;
            }
            actualizarDinero();
        }

        public void tomarVuelo()//metodo donde se asigna una posicion nueva al azar, al jugadorActual
        {
            Random DiceExtra = new Random();
            int extradice = DiceExtra.Next(0, 40);//se elige una casilla al azar y el jugador tiene que mover ahi

            int jugadorActual = Turnoactual;
            for (int i = 0; i < players.Count; i++)
            {//encontramos el jugadorActual
                if (players[i].GetID() == jugadorActual)
                {
                    txtMapData.Text = "Whoa, player" + players[i].GetID() + " tomó un avión con destino a la casilla " + extradice;
                    players[i].SetPosition(extradice);

                    for (int j = 0; j < fichas.Count; j++)
                    {
                        if (i == j)
                        {
                            fichas[j].Margin = new Thickness(Convert.ToDouble(Spaces[extradice].axis.x), Convert.ToDouble(Spaces[extradice].axis.y),
                                               Convert.ToDouble(Spaces[extradice].axis.z), Convert.ToDouble(Spaces[extradice].axis.s));
                        }
                    }
                }
            }
            actualizarDinero();
        }

        public void cartaChance()//metodo para interactuar con cartas chance
        {
            Random r = new Random();
            int rc = r.Next(0, 14);
            // lee la descripcion de la carta
            chance.drawChanceCards(rc);

            int jugadorActual = Turnoactual;
            for (int i = 0; i < players.Count; i++)
            {//encontramos el jugadorActual
                if (players[i].GetID() == jugadorActual)
                {
                    players[i].SetMoney(players[i].GetMoney() + chance.UpdateDinero(rc));
                    //////////////////////////////////////////////////////////////////////
                    if (chance.moverFicha(rc) != 80)  ////////////////CARTA QUE MUEVE JUGADOR A OTRO CASILLA////////////////
                    {                                //////////////////////////////////////////////////////////////////////
                        if (chance.moverFicha(rc) == 0)
                        {
                            players[i].SetPosition(chance.moverFicha(rc));
                            players[i].SetMoney(players[i].GetMoney() + 200); // se le da el dinero por su vuelta
                            for (int j = 0; j < fichas.Count; j++)
                            {//se encuentra la ficha que corresponde al jugadorActual
                                if (i == j)
                                {
                                    fichas[j].Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y),
                                                       Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));
                                }
                            }
                        }
                        else
                        {
                            players[i].SetPosition(chance.moverFicha(rc));
                            for (int j = 0; j < fichas.Count; j++)
                            {
                                if (i == j)
                                {
                                    fichas[j].Margin = new Thickness(Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.x), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.y),
                                    Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.z), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.s));
                                }
                            }
                        }
                    }                              ////////////////////////////////////////////////////////////////
                    if (chance.gotojail(rc) != 80) ////////////////CARTA QUE LLEVA JUGADOR A CARCEL////////////////
                    {                              ////////////////////////////////////////////////////////////////
                        players[i].jailed();
                        players[i].SetPosition(chance.gotojail(rc));
                        for (int j = 0; j < fichas.Count; j++)
                        {
                            if (i == j)
                            {
                                fichas[j].Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y),
                                                    Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                            }
                        }
                    }
                    ///////////////////////////////////////////////////////////////
                    if (chance.devolverTarjetaF(rc) == true) ////////////////CARTA PARA ESCAPAR DE LA CARCEL////////////////
                    {                                       ///////////////////////////////////////////////////////////////
                        players[i].setTarjetas(1);
                    }
                }
            }

            if (chance.cadaJugadorPaga(rc) != 0) //Tarjeta cada jugador paga
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].GetID() == jugadorActual)
                    {//cantidad que el jugadorActual va a recibir depende de cuantos jugadores hay
                        if (playernumber == 2)
                        {
                            players[i].SetMoney(players[i].GetMoney() + 10);
                        }
                        else if (playernumber == 3)
                        {
                            players[i].SetMoney(players[i].GetMoney() + 20);
                        }
                        else
                        {
                            players[i].SetMoney(players[i].GetMoney() + 30);
                        }
                    }
                    else
                    {// si no son los jugadoresActuales, pierden dinero
                        players[i].SetMoney(players[i].GetMoney() - 10);
                    }
                }
            }
            actualizarDinero();
        }

        public void cartaNasdaq()//metodo para interactuar con cartas nasdaq
        {
            Random r = new Random();
            int rc = r.Next(0, 13);
            //lee la descripcion de la carta
            nasdaq.drawNasdaqCard(rc);

            int jugadorActual = Turnoactual;
            for (int i = 0; i < players.Count; i++)
            {//encontramos el jugadorActual
                if (players[i].GetID() == jugadorActual)
                {
                    players[i].SetMoney(players[i].GetMoney() + nasdaq.UpdateDinero(rc));
                    //////////////////////////////////////////////////////////////
                    if (nasdaq.moverFicha(rc) != 80) ////////////CARTA QUE MUEVE JUGADOR A OTRO CASILLA////////////
                    {                               //////////////////////////////////////////////////////////////
                        if (nasdaq.moverFicha(rc) == 0)
                        {
                            players[i].SetPosition(nasdaq.moverFicha(rc));
                            players[i].SetMoney(players[i].GetMoney() + 200); // se le da el dinero por su vuelta

                            if (Turnoactual == 1)
                            {
                                imgplayer1.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y),
                                                    Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));
                            }
                            if (Turnoactual == 2)
                            {
                                imgplayer2.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y),
                                                    Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));
                            }
                            if (Turnoactual == 3)
                            {
                                imgplayer3.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y),
                                                    Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));
                            }
                            if (Turnoactual == 4)
                            {
                                imgplayer4.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y),
                                                    Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));
                            }
                        }
                        else
                        {
                            players[i].SetPosition(nasdaq.moverFicha(rc));

                            if (Turnoactual == 1)
                            {
                                imgplayer1.Margin = new Thickness(Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.x), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.y),
                                Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.z), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.s));
                            }
                            if (Turnoactual == 2)
                            {
                                imgplayer2.Margin = new Thickness(Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.x), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.y),
                                Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.z), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.s));
                            }
                            if (Turnoactual == 3)
                            {
                                imgplayer3.Margin = new Thickness(Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.x), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.y),
                                Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.z), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.s));
                            }
                            if (Turnoactual == 4)
                            {
                                imgplayer4.Margin = new Thickness(Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.x), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.y),
                                Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.z), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.s));
                            }
                        }
                    }
                    ////////////////////////////////////////////////////////
                    if (nasdaq.gotojail(rc) != 80) ////////////CARTA QUE LLEVA JUGADOR A CARCEL////////////
                    {                             ////////////////////////////////////////////////////////
                        players[i].jailed();
                        players[i].SetPosition(nasdaq.gotojail(rc));

                        if (Turnoactual == 1)
                        {
                            imgplayer1.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y),
                                                Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                        }
                        if (Turnoactual == 2)
                        {
                            imgplayer2.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y),
                                                Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                        }
                        if (Turnoactual == 3)
                        {
                            imgplayer3.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y),
                                                Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                        }
                        if (Turnoactual == 4)
                        {
                            imgplayer4.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y),
                                                Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                        }
                    }
                    ///////////////////////////////////////
                    if (nasdaq.moverFicha(rc) == 12) //////////// ????????????? ////////////
                    {                               ///////////////////////////////////////
                        if (players[i].GetPosition() <= 17 || players[i].GetPosition() >= 5)
                        {
                            players[i].SetPosition(nasdaq.moverFicha(rc));
                        }
                    }                                 ///////////////////////////////////////
                    if (nasdaq.moverFicha(rc) == 33) //////////// ????????????? ////////////
                    {                               ///////////////////////////////////////
                        if (players[i].GetPosition() == 3)
                        {
                            players[i].SetPosition(nasdaq.moverFicha(rc));
                        }
                    }
                }
            }

            if (nasdaq.pagarACadaJugador(rc) != 0) // el jugador le paga $50 a cada uno de los jugadores
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].GetID() == jugadorActual)
                    {
                        if (playernumber == 2)
                        {
                            players[i].SetMoney(players[i].GetMoney() + nasdaq.pagarACadaJugador(rc));
                        }
                        if (playernumber == 3)
                        {
                            players[i].SetMoney(players[i].GetMoney() + (nasdaq.pagarACadaJugador(rc) * 2));
                        }
                        else
                        {
                            players[i].SetMoney(players[i].GetMoney() + (nasdaq.pagarACadaJugador(rc) * 3));
                        }
                    }
                    else
                    {
                        players[i].SetMoney(players[i].GetMoney() + 50);
                    }
                }
            }
            actualizarDinero();
        }

        private void btnNextTurn_Click(object sender, RoutedEventArgs e)
        {
            Turn.Enqueue(Turnoactual);
            //le pone el turno actual al queque, es decir, ahora le toca al ultimo
            txtMapData.Text = "";
            iniciarTurnos();
            pagarJugadores();
            mostrarTurno();
            if (jugadorSinDinero() == true)
            {
                determinarGanador();
                terminarJuego();
            }
            //el juego tiene que seguir
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            iniciarTurnos();
            //Iniciarturno();
            btnStart.IsEnabled = false;
            btnStart.Content = "Finish!";
            btnNextTurn.Content = "Next Turn!";
            btnNextTurn.IsEnabled = true;
        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            int jugadorActual = Turnoactual;
            for (int i = 0; i < players.Count; i++)
            {
                if (jugadorActual == players[i].GetID())//se encuentra el jugadorActual dentro del if
                {
                    int posicion = players[i].GetPosition();
                    if (MessageBox.Show("Deseas comprar " + Spaces[posicion].name + " por $" + Spaces[posicion].price + "?", "Comprar Propiedad",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)//juego pregunta al jugador si desea comprar la empresa
                    {//si el jugador dice que si, se ejecuta el codigo dentro de este if
                        players[i].buy(Spaces[posicion].price, Spaces[posicion]);
                        Spaces[posicion].canBuy = false;//atributo se cambia a false, lo cual indica que este empresa no puede ser comprado
                        Spaces[posicion].setOwner(players[i].GetID());
                        MessageBox.Show("Compraste " + Spaces[posicion].name + ". Felicitaciones!");
                    }
                    else if (players[i].GetMoney() < Spaces[posicion].getPrice())
                    {
                        MessageBox.Show("No tienes suficiente dinero para comprar la empresa");
                    }
                    else if (Spaces[posicion].canBuy == false)
                    {
                        MessageBox.Show("Este empresa ya tiene un dueño");
                    }
                    else
                    {
                        MessageBox.Show("No puedes comprar este espacio");
                    }
                }
            }
            actualizarDinero();
            actualizarEmpresas();
        }

        private void btnTrade_Click_1(object sender, RoutedEventArgs e)//gridTrade se hace visible, see llena un cbo con empresas que el jugador tiene para hacer un trade
        {
            btnTrade.Visibility = Visibility.Hidden;
            cboJugadores.Items.Clear();
            cboPropiedadO.Items.Clear();
            GridTrade.Margin = new Thickness(613, 38, 0, 0);//el grid para hacer un trade se hace visible cuando se apreta el boton
            lblAR.Visibility = Visibility.Hidden;
            rbSi.Visibility = Visibility.Hidden;
            rbNo.Visibility = Visibility.Hidden;

            txtOferta.Text = "0";

            List<holdings> _empresas = new List<holdings>();

            int jugadorActual = Turnoactual;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].GetID() != Turnoactual)
                {
                    cboJugadores.Items.Add(players[i].GetID());//se llena un combobox con los jugadores
                }
                if (Turnoactual == 0)
                {
                    //GridTrade.Visibility = Visibility.Hidden;
                    btnTrade.Visibility = Visibility.Visible;
                }

                if (players[i].GetID() == jugadorActual)
                {
                    _empresas = players[i].getHoldings();//se almacenan las empresas del jugador que inicio el trade en la lista _empresas
                    foreach (holdings h in _empresas)
                    {
                        cboPropiedadO.Items.Add(h.getName() + ", " + h.getColor().ToString());// se llena el cbo con items de _empresas
                    }
                }
            }
        }

        private void cboJugadores_SelectionChanged(object sender, SelectionChangedEventArgs e)//se llena el otro cbo con propiedades que el jugador quiere recibir en el trade
        {
            cboPropiedadQ.Items.Clear();
            List<holdings> _Empresas = new List<holdings>();//instance this at the top?
            if (cboJugadores.SelectedItem == null)
            {

            }
            else
            {
                int jugadorTrade = int.Parse(cboJugadores.SelectedItem.ToString());//el playerid elegido en cboJugadores se asigna a un int
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].GetID() == jugadorTrade)//comparamos el int con el id de los jugadores para almacenar la lista correcta en cboPropiedadesQ
                    {
                        _Empresas = players[i].getHoldings();
                        foreach (holdings h in _Empresas)
                        {
                            cboPropiedadQ.Items.Add(h.getName() + ", " + h.getColor().ToString());//se llena este combobox con las empresas del jugador
                        }
                    }
                }
            }
        }

        private void rbOferta_Checked(object sender, RoutedEventArgs e)//se hacen visibles los radiobuttons para aceptar o rechazar la oferta
        {
            if (cboJugadores.SelectedIndex == -1)// en caso de que un jugador hace una oferta sin elegir un jugador
            {
                MessageBox.Show("Tienes que elegir un jugador antes de hacer una oferta");
                rbOferta.IsChecked = false;
            }
            else if (int.Parse(txtOferta.Text) < 0)
            {
                GridTrade.Margin = new Thickness(831, 11, -213, 0);
                btnTrade.Visibility = Visibility.Visible;
                rbNo.IsChecked = false;
                rbSi.IsChecked = false;
                rbOferta.IsChecked = false;
                txtOferta.Text = "";
                txtMapData.Text = "Quizás el deberia hacer la oferta";
            }
            else
            {
                lblAR.Visibility = Visibility.Visible;
                rbSi.Visibility = Visibility.Visible;
                rbNo.Visibility = Visibility.Visible;

                int jugadorTrade = int.Parse(cboJugadores.SelectedItem.ToString());
                lblAR.Content = "Quieres aceptar la oferta player" + jugadorTrade.ToString() + "?";
                lblAR.FontSize = 10;
            }
        }

        private void rbSi_Checked(object sender, RoutedEventArgs e)
        {
            if (players[Turnoactual - 1].GetMoney() < double.Parse(txtOferta.Text))
            {
                GridTrade.Margin = new Thickness(831, 11, -213, 0);
                btnTrade.Visibility = Visibility.Visible;
                rbNo.IsChecked = false;
                rbSi.IsChecked = false;
                rbOferta.IsChecked = false;
                txtOferta.Text = "";
                txtMapData.Text = "¡No hay suficiente dinero!";
            }
            else
            {
                int jugadorActual = Turnoactual;
                int jugadorTrade = int.Parse(cboJugadores.SelectedItem.ToString());
                if (txtOferta.Text == "")
                {
                    txtOferta.Text = "0";
                }
                else if (cboPropiedadO.SelectedIndex == -1)
                {
                    txtMapData.Text = "¡ No puedes hacer ofertas vacias !";
                    MessageBox.Show("¡ No puedes hacer ofertas vacias !");
                    rbSi.IsChecked = false;
                }
                else if (cboPropiedadQ.SelectedIndex == -1)
                {
                    txtMapData.Text = "¡ No puedes hacer ofertas vacias !";
                    MessageBox.Show("¡ No puedes hacer ofertas vacias !");
                    rbSi.IsChecked = false;
                }
                else
                {
                    characters ja = new characters();//variables que se van a usar para el metodo trade
                    characters jt = new characters();
                    holdings JA = new holdings();
                    holdings JT = new holdings();
                    int oferta = int.Parse(txtOferta.Text);

                    string propiedad1 = cboPropiedadO.SelectedItem.ToString();//empresas se almacenan en un string, para tener los nombres disponibles para hacer una comparacion
                    string propiedad2 = cboPropiedadQ.SelectedItem.ToString();
                    string[] campos = propiedad1.Split(',');
                    string[] celdas = propiedad2.Split(',');

                    List<holdings> _Empresas = new List<holdings>();
                    List<holdings> _empresas = new List<holdings>();

                    if (MessageBox.Show("Estás seguro?", "Trade", MessageBoxButton.YesNo) == MessageBoxResult.Yes)//dentro del if se asignan los valores necesarios a los variables
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].GetID() == jugadorActual)//se determina el jugadorActual
                            {
                                ja = players[i];//jugadorActual
                                _empresas = players[i].getHoldings();//empresas del jugadorActual se almacenan en _empresas
                                for (int j = 0; j < _empresas.Count; j++)
                                {
                                    if (_empresas[j].getName().Equals(campos[0]))
                                    {
                                        JA = _empresas[j];//empresa que el jugadorActual ofrece a otro jugador
                                    }
                                }
                            }

                            if (players[i].GetID() == jugadorTrade)//se determina el jugador que recibio la oferta para hacer un trade
                            {
                                jt = players[i];//jugador que el jugadorActual eligio para hacer un trade
                                _Empresas = players[i].getHoldings();
                                for (int j = 0; j < _Empresas.Count; j++)
                                {
                                    if (_Empresas[j].getName().Equals(celdas[0]))
                                    {
                                        JT = _Empresas[j];//empresa que el jugadorActual quiere recibir
                                    }
                                }
                            }
                        }
                        ja.trade(JA, jt, JT, oferta);// trade se hace con este metodo
                        actualizarDinero();//los datos de los jugadores involucrados en el trade se actualizan en el tablero
                        actualizarEmpresas();
                        GridTrade.Margin = new Thickness(831, 11, -213, 0);
                        btnTrade.Visibility = Visibility.Visible;
                        rbSi.IsChecked = false;
                    }
                    else
                    {
                        MessageBox.Show("Haga una mejor oferta");
                    }
                }
            }
        }

        private void rbNo_Checked(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Quiéres hacer otro trade?", "Trade", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                txtOferta.Text = "0";
                lblAR.Visibility = Visibility.Hidden;
                rbSi.Visibility = Visibility.Hidden;
                rbNo.Visibility = Visibility.Hidden;
            }
            else
            {
                GridTrade.Margin = new Thickness(831, 11, -213, 0);
                btnTrade.Visibility = Visibility.Visible;
            }
        }

        private void btnPrestamos_Click(object sender, RoutedEventArgs e)
        {
            gridPrestamo.Margin = new Thickness(615, 243, 0, -0.4);
            //gridPrestamo.Visibility = Visibility.Visible;
            cboPrestamo.Items.Clear();
            rbHacerPrestamo.IsChecked = false;
            rbCancelarPrestamo.IsChecked = false;
            List<holdings> _empresas = new List<holdings>();

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].GetID() == Turnoactual)//juego encuentra el jugadorActual
                {
                    _empresas = players[i].getHoldings();// empreas del jugador se almacenan en _empresas
                    foreach (holdings h in _empresas)
                    {
                        cboPrestamo.Items.Add(h.getName() + ", " + h.getColor().ToString());//empresas de jugador se agregan a combobox
                    }
                }
            }
        }

        private void rbHacerPrestamo_Checked(object sender, RoutedEventArgs e)
        {
            if (cboPrestamo.SelectedItem == null)//en caso de que un jugador intenta pedir un prestamo sin elegir una empresa
            {
                gridPrestamo.Margin = new Thickness(1038, 12, -418, 0);
                //gridPrestamo.Visibility = Visibility.Hidden;
                txtMapData.Text = "¡No puedes hacer un préstamo de nada!";
            }
            else
            {
                string empresa = cboPrestamo.SelectedItem.ToString();//empresa se almacena en un string, para tener el nombre disponible para hacer una comparacion
                string[] campos = empresa.Split(',');

                for (int i = 0; i < players.Count; i++)//para identificar el jugadorActual
                {
                    if (players[i].GetID() == Turnoactual)
                    {
                        foreach (holdings h in players[i].getHoldings())//recorre las empresas del jugadorActual
                        {
                            if (h.getName().Equals(campos[0]) && h.getPrestamo() == false)//encontramos la empresa en el cbo dentro de la lista del jugadorActual
                            {
                                players[i].pedirPrestamo(h);
                                MessageBox.Show(h.getName() + ", no puedes cobrar a jugadores que caen en ese espacio hasta que canceles el prestamo");
                            }
                            else if (h.getName().Equals(campos[0]) && h.getPrestamo() == true)
                            {
                                MessageBox.Show("Ya pediste un prestamo con acciones de este empresa");
                            }
                        }
                    }
                }
                actualizarDinero();
                gridPrestamo.Margin = new Thickness(1038, 12, -418, 0);
                //gridPrestamo.Visibility = Visibility.Hidden;              
            }
        }

        private void rbCancelarPrestamo_Checked(object sender, RoutedEventArgs e)
        {
            if (cboPrestamo.SelectedItem == null)
            {
                gridPrestamo.Margin = new Thickness(1038, 12, -418, 0);
                //gridPrestamo.Visibility = Visibility.Hidden;
            }
            else
            {
                string empresa = cboPrestamo.SelectedItem.ToString();//empresa se almacena en un string, para tener el nombre disponible para hacer una comparacion
                string[] campos = empresa.Split(',');

                for (int i = 0; i < players.Count; i++)//para identificar el jugadorActual
                {
                    if (players[i].GetID() == Turnoactual)
                    {
                        foreach (holdings h in players[i].getHoldings())//recorre las empresas del jugadorActual
                        {
                            if (h.getName().Equals(campos[0]) && h.getPrestamo() == true)//encontramos la empresa en el cbo dentro de la lista del jugadorActual
                            {
                                players[i].cancelarPrestamo(h);
                                MessageBox.Show(h.getName() + ", Este espacio te va a generar ingresos nuevamente");
                            }
                            else if (h.getName().Equals(campos[0]) && h.getPrestamo() == false)//en caso de que un jugador intenta cancelar su prestamo con activos de otra empresa
                            {
                                MessageBox.Show("No se puede cancelar");
                            }
                        }
                    }
                }
                actualizarDinero();
                gridPrestamo.Margin = new Thickness(1038, 12, -418, 0);
                //gridPrestamo.Visibility = Visibility.Hidden;
            }
        }

        private void btnTradeCancelar_Click(object sender, RoutedEventArgs e)
        {
            GridTrade.Margin = new Thickness(831, 11, -213, 0);
            btnTrade.Visibility = Visibility.Visible;
            txtOferta.Text = "";
            rbOferta.IsChecked = false;
            rbSi.IsChecked = false;
            rbNo.IsChecked = false;
        }

        private void musicback()
        {
            spm.SoundLocation = @"../../Sound/TitleScreen.wav";
            spm.PlayLooping();
        }
        private void PlayGameMusic()
        {
            spm.SoundLocation = @"../../Sound/GameMusic.wav";
            spm.PlayLooping();
        }
        private void Mute()
        {
            spm.Stop();
        }

        private void btnMute_Click(object sender, RoutedEventArgs e)
        {
            Mute();
            btnSound.Margin = new Thickness(57, 9, 0, 0);
            btnMute.Margin = new Thickness(44, -24, 25, 0);
        }

        private void btnSound_Click(object sender, RoutedEventArgs e)
        {
            PlayGameMusic();
            btnMute.Margin = new Thickness(57, 9, 0, 0);
            btnSound.Margin = new Thickness(89, -24, 0, 0);
        }
    }
}
