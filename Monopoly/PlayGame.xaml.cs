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
        Queue<int> Turn = new Queue<int>();
        //crea el turno, es un queque
        int playernumber;
        //le entra el numero de jugadores
        List<holdings> Spaces = new List<holdings>();
        List<characters> players = new List<characters>();
       //crea la lista de casillas y la de personajes
        Dice dice = new Dice();
        //crea el dado
        characters player1 = new characters(1);
        characters player2 = new characters(2);
        characters player3 = new characters(3);
        characters player4 = new characters(4);
        //characters
        int turnsInJail1 = 0;
        int turnsInJail2 = 0;
        int turnsInJail3 = 0;
        int turnsInJail4 = 0;
        //tarjetas
        Chance chance = new Chance();
        Nasdaq nasdaq = new Nasdaq();
        //lista de tarjetas para escapar de la carcel
        List<int> jugador1 = new List<int>();
        List<int> jugador2 = new List<int>();
        List<int> jugador3 = new List<int>();
        List<int> jugador4 = new List<int>();
        public PlayGame(int PlayerNumbers)
        {
            PlayGameMusic();
            InitializeComponent();
            //metodo donde se crean todas las casillas
            StartOps();
            //metodo donde añade los jugadores a la lista
            //grid para intercambiar propiedades
            GridTrade.Visibility = Visibility.Hidden;
            gridPrestamo.Visibility = Visibility.Hidden;


            if (PlayerNumbers == 3)
            {
                //en caso de que solo existan 3 jugadores
                player4.SetID(0);//elimina ID jugador 4
                lblPlayer4.Margin = new Thickness(1819, 376, -1115, 0);//aleja sus propiedades del board
                txtDataPlayer4.Margin = new Thickness(1819, 376, -1115, 0); //aleja sus propiedades del board
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
                imgplayer1.Margin = new Thickness(549,395,217,25);
                imgplayer2.Margin = new Thickness(549, 395, 217, 25);
                imgplayer3.Margin = new Thickness(549, 395, 217, 25);
                //mueve las respectivas fotos para a posicion 0 
                Turn.Enqueue(1);
                Turn.Enqueue(2);
                Turn.Enqueue(3);
                //agrega 3 turnos.
                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
                playernumber = 3;
            }
            else if(PlayerNumbers == 2)
            {
                //lo mismo que el primero
                player4.SetID(0);
                player3.SetID(0);
                lblPlayer4.Margin = new Thickness(1819, 376, -1115, 0);
                txtDataPlayer4.Margin = new Thickness(1819, 376, -1115, 0);
                lblPlayer3.Margin = new Thickness(1819, 376, -1115, 0);
                txtDataPlayer3.Margin = new Thickness(1819, 376, -1115, 0);
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
                Turn.Enqueue(1);
                Turn.Enqueue(2);
                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                playernumber = 2;
            }
            else
            {
                //en caso que hayan 4 jugadores
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
                Turn.Enqueue(1);
                Turn.Enqueue(2);
                Turn.Enqueue(3);
                Turn.Enqueue(4);
                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
                txtDataPlayer4.Text = "$" + player4.GetMoney().ToString();
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
            //LOS NOMBRES OK
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
            txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
            txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
            txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
            txtDataPlayer4.Text = "$" + player4.GetMoney().ToString();
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
                    empresas1 = players[i].GetHoldings();
                    for (int j = 0; j < empresas1.Count; j++)
                    {
                        cboPropiedades1.Items.Add(empresas1[j].getName() + ", " + empresas1[j].getColor());
                    }
                }
                if (players[i].GetID() == 2)
                {
                    empresas2 = players[i].GetHoldings();
                    for (int j = 0; j < empresas2.Count; j++)
                    {
                        cboPropiedades2.Items.Add(empresas2[j].getName() + ", " + empresas2[j].getColor());
                    }
                }
                if (players[i].GetID() == 3)
                {
                    empresas3 = players[i].GetHoldings();
                    for (int j = 0; j < empresas3.Count; j++)
                    {
                        cboPropiedades3.Items.Add(empresas3[j].getName() + ", " + empresas3[j].getColor());
                    }
                }
                if (players[i].GetID() == 4)
                {
                    empresas4 = players[i].GetHoldings();
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

            for(int i = 0; i < players.Count; i++)
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

            for(int i = 0; i < players.Count; i++)
            {
                efectivo = 0;
                valorActivos = 0;
                efectivo = players[i].GetMoney();
                for(int j = 0; j < players[i].getHoldings().Count; j++)
                {
                    valorActivos += players[i].getHoldings()[j].getPrice();//se suma los valores de los activos
                }

                if(efectivo + valorActivos > riquezas)//si es verdad, ganador se asigna a players[i]
                {
                    riquezas = 0;
                    riquezas = efectivo + valorActivos;
                    ganador = players[i];
                }
            }
            MessageBox.Show("El ganador es player " + ganador.GetID().ToString());
        } //revisar

        public void terminarJuego()
        {
            MainWindow M = new MainWindow();
            M.ShowDialog();
            this.Close();
        } //revisar

        public void Iniciarturno()
        {
            //cada vez que inicia
            Turn.Dequeue();
            //se quita un turno
            Turnoactual++;
            //y el turno actual sube (esto solo sirve para en caso de que se planee saber quien mueve, es decir, indica quien se está moviendo)
            //cuando turno actuala es mayor al numero de jugadores se repite, cosa de que si son 4 jugadores, solamente pueden haber 4 turnos
            if (Turnoactual > playernumber)
            {
                Turnoactual = 1;
                //cuando turno es mayor a el numero de jugadores, se repite al primer turno
            }

            if (Turnoactual == 1)
            //si el turno actual es 1, le toca moverse al jugador 1
            {
                txtMapData.Text = "Comienza el turno del Jugador 1";
                Facep1.Margin = new Thickness(600, 250, 0, 0);
                Facep2.Margin = new Thickness(1018, 198, -418, 54);
                Facep3.Margin = new Thickness(1018, 198, -418, 54);
                Facep4.Margin = new Thickness(1018, 198, -418, 54);

                if (player1.getJail() == false) //si no está preso?
                {
                    //////s i s t e m a    d e    t u r n o s///////////////////
                    int valor = dice.throwDice();
                    player1.SetPosition(player1.GetPosition() + valor);//se le agrega el valor de los dados a la posicion actual, es decir, su puesto más los dados
                    if (player1.GetPosition() >= 40)
                        //si el jugador 1 esta en la posicion superior a 40, significa que ya dio una buela
                    {
                        player1.SetPosition(player1.GetPosition() - 40); //se le quita 40 posiciones para que si está en la 43, quede en la 3. 
                        player1.SetMoney(player1.GetMoney() + 200); // se le da el dinero por su vuelta
                        txtDataPlayer1.Text = "$" + player1.GetMoney().ToString(); //actualiza dinero
                    }

                    /////////////////////////////////////////////////
                    ////////////M O V I M I E N T O ////////////////
                    ///////////////////////////////////////////////

                    for (int i = 0; i <= player1.GetPosition(); i++)
                    //Mientras I sea menorque o igual a su posicion actual, se le agrega uno a I
                    // es decir, i reccore todos los numeros hasta la posicion actual (la con el valor de los dados) y cuando la supera
                    {
                        if (i >= 40)
                        {
                            txtMapData.Text = "Random event player 1: ¡Dirígete a 'GO' y ganas dinero!";
                            player1.SetPosition(0);
                            imgplayer1.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y), Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));
                            player1.SetMoney(player1.GetMoney() + 200);
                            i = 0;
                        }
                        if (Spaces[i].position.Equals(player1.GetPosition()))
                        {
                            //si el espacio es equivalente a la posicion actual, moverlo a la posicion de ese espacio
                            imgplayer1.Margin = new Thickness(Convert.ToDouble(Spaces[i].axis.x), Convert.ToDouble(Spaces[i].axis.y), Convert.ToDouble(Spaces[i].axis.z), Convert.ToDouble(Spaces[i].axis.s));

                        }
                        if (Spaces[30].position.Equals(player1.GetPosition()))
                        {
                            //si cae a la carcel, se mueve a la carcel
                            imgplayer1.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y), Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                            player1.jailed();
                            player1.SetPosition(10);
                        }
                        
                    }
                    //imprime los dos dados en los espacios de los dados.
                    txtDice1.Text = dice.getDice1().ToString();
                    txtDice2.Text = dice.getDice2().ToString();
                    txtDice3.Text = dice.getDice3().ToString();
                }
                else
                {
                    //metodo para salir de la carcel
                    escapeJail();
                }
                //////////////////////////////////////////////////////////////////////
                ////////////////other moves: like taxes and planes////////////////////
                //////////////////////////////////////////////////////////////////////
                ///TAX
                if (Spaces[38].position.Equals(player1.GetPosition()))
                {
                    // si no tiene dinero para pagar que pasaba, lo tengo que crear yo?
                    // si no lo mando para la carcel
                    if (player1.GetMoney() >= 300)
                    {
                        double impr = player1.GetMoney() - 300;
                        txtMapData.Text = "jugador 1 paga impuestos, tienes " + player1.GetMoney() + "$ pero quedas con " + impr;
                        player1.SetMoney(player1.GetMoney() - 300);

                    }
                    else
                    {
                        txtMapData.Text = "No tienes para pagar impuestos! \n pasas la noche en la cárcel!";
                        player1.SetPosition(10);
                    }
                }
                ///PLANE
                else if (Spaces[4].position.Equals(player1.GetPosition()) || Spaces[28].position.Equals(player1.GetPosition()) || Spaces[35].position.Equals(player1.GetPosition()))
                {
                    
                    Random DiceExtra = new Random();
                    int extradice = DiceExtra.Next(0, 40);
                    txtMapData.Text = "Woah, el jugador 1 tomó un avión con destino a la casilla " + extradice;
                    player1.SetPosition(extradice);
                    imgplayer1.Margin = new Thickness(Convert.ToDouble(Spaces[extradice].axis.x), Convert.ToDouble(Spaces[extradice].axis.y), Convert.ToDouble(Spaces[extradice].axis.z), Convert.ToDouble(Spaces[extradice].axis.s));
                }
                ///

                ////////////////////////////////////////////
                ///////////////carta chance/////////////////
                ////////////////////////////////////////////
                if (Spaces[7].position.Equals(player1.GetPosition()) || Spaces[22].position.Equals(player1.GetPosition()) || Spaces[25].position.Equals(player1.GetPosition()) || Spaces[36].position.Equals(player1.GetPosition()))
                {
                   
                    
                    
                        Random r = new Random();
                        int rc = r.Next(0, 14);
                        // lee la descripcion de la carta
                        chance.drawChanceCards(rc);


                        player1.SetMoney(player1.GetMoney() + chance.UpdateDinero(rc));
                        txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                        if (chance.cadaJugadorPaga(rc) != 0) //Tarjeta cada jugador paga
                        {
                            if (playernumber == 2) // si es que hay dos jugadores
                            {
                                player2.SetMoney(player2.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 2
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();

                                player1.SetMoney(player1.GetMoney() + 10); //player 1 recibe $10
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                            }
                            else if (playernumber == 3) //si es que hay 3 jugadores
                            {
                                player2.SetMoney(player2.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 2
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                                player3.SetMoney(player3.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 3
                                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();

                                player1.SetMoney(player1.GetMoney() + 20); //player 1 recibe $20
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                            }
                            else if (playernumber == 4) //si es que hay 4 jugadores
                            {
                                player2.SetMoney(player2.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 2
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                                player3.SetMoney(player3.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 3
                                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
                                player4.SetMoney(player4.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 4
                                txtDataPlayer4.Text = "$" + player4.GetMoney().ToString();

                                player1.SetMoney(player1.GetMoney() + 30); //player 1 recibe $30
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                            }

                        }
                        if (chance.moverFicha(rc) != 80)
                        {

                            if (chance.moverFicha(rc) == 0)
                            {

                                player1.SetPosition(chance.moverFicha(rc));
                                imgplayer1.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y), Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));
                                player1.SetMoney(player1.GetMoney() + 200); // se le da el dinero por su vuelta
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString(); //actualiza dinero
                            }
                            else
                            {
                                player1.SetPosition(chance.moverFicha(rc));
                                imgplayer1.Margin = new Thickness(Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.x), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.y), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.z), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.s));
                            }

                        }
                        else if (chance.gotojail(rc) != 80)
                        {
                            player1.jailed();
                            player1.SetPosition(chance.gotojail(rc));
                            imgplayer1.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y), Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                        }
                        else if (chance.devolverTarjetaF(rc) == true)
                        {
                            jugador1.Add(1);//se agrega un 1 a la lista, que despues se puede utilizar para escapar de la carcel
                        }
                    
                }
                    if (Spaces[2].position.Equals(player1.GetPosition()) || Spaces[5].position.Equals(player1.GetPosition()) || Spaces[15].position.Equals(player1.GetPosition()) || Spaces[17].position.Equals(player1.GetPosition()))
                    {
                    ////////////////////////////////////////////
                    ///////////////Carta Nasdaq/////////////////
                    ////////////////////////////////////////////
                   
                    Random r = new Random();
                        int rc = r.Next(0, 13);
                        //lee la descripcion de la carta
                        nasdaq.drawNasdaqCard(rc);
                        player1.SetMoney(player1.GetMoney() + nasdaq.UpdateDinero(rc));
                        txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                        if (nasdaq.pagarACadaJugador(rc) != 0) // el jugador le paga $50 a cada uno de los jugadores
                        {
                            if (playernumber == 2)
                            {
                                player1.SetMoney(player1.GetMoney() + nasdaq.pagarACadaJugador(rc)); //jugador 1 paga 50
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();

                                player2.SetMoney(player2.GetMoney() + 50);
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                            }
                            else if (playernumber == 3)
                            {
                                player1.SetMoney(player1.GetMoney() + (nasdaq.pagarACadaJugador(rc) * 2)); //jugador 1 paga 100
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();

                                player2.SetMoney(player2.GetMoney() + 50);
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                                player3.SetMoney(player3.GetMoney() + 50);
                                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
                            }
                            else if (playernumber == 4)
                            {
                                player1.SetMoney(player1.GetMoney() + (nasdaq.pagarACadaJugador(rc) * 3)); //jugador 1 paga 150
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();

                                player2.SetMoney(player2.GetMoney() + 50);
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                                player3.SetMoney(player3.GetMoney() + 50);
                                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
                                player4.SetMoney(player4.GetMoney() + 50);
                                txtDataPlayer4.Text = "$" + player4.GetMoney().ToString();

                            }
                        }
                        if (nasdaq.moverFicha(rc) != 80)
                        {
                            
                            if (nasdaq.moverFicha(rc) == 0)
                            {
                                player1.SetPosition(nasdaq.moverFicha(rc));
                                player1.SetMoney(player1.GetMoney() + 200); // se le da el dinero por su vuelta
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString(); //actualiza dinero
                            imgplayer1.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y), Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));
                            }
                        else
                        {
                            player1.SetPosition(nasdaq.moverFicha(rc));
                            imgplayer1.Margin = new Thickness(Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.x), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.y), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.z), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.s));

                        }

                         }
                        else if(nasdaq.gotojail(rc) != 80)
                        {
                            player1.jailed();
                            player1.SetPosition(nasdaq.gotojail(rc));
                             imgplayer1.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y), Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                        }
                        else if (nasdaq.moverFicha(rc) == 12)
                         {
                            if(player1.GetPosition() <= 17 || player1.GetPosition() >= 5)
                            {
                            player1.SetPosition(nasdaq.moverFicha(rc));
                            }                         
                         }
                        else if (nasdaq.moverFicha(rc) == 33)
                         {
                            if(player1.GetPosition() == 3)
                            {
                            player1.SetPosition(nasdaq.moverFicha(rc));
                            }
                         }
                       
                         
                    }           
            }
            //////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////
            ///////////////////C O M I E N Z A    J U G A D O R    D O S //////////////////
            //////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////
            //para revirsar codigo, revisar jugador 1
            else if (Turnoactual == 2)
            {
                txtMapData.Text = "Comienza el turno del Jugador 2";
                Facep1.Margin = new Thickness(1018, 198, -418, 54);
                Facep2.Margin = new Thickness(600, 250, 0, 0);
                Facep3.Margin = new Thickness(1018, 198, -418, 54);
                Facep4.Margin = new Thickness(1018, 198, -418, 54);
                if (player2.getJail() == false)
                {
                    //este es el que revisa si esta en la carcel o no, faltan mensajitos o algo
                    //idea: poner un texto sobre todo con la misma animación del presstart cuando vaya a Jail, para no usar 
                    //un message box, que igual es feo.- 
                    int valor = dice.throwDice();
                    player2.SetPosition(player2.GetPosition() + valor);
                    if (player2.GetPosition() >= 40)
                    {
                        player2.SetPosition(player2.GetPosition() - 40);
                        player2.SetMoney(player2.GetMoney() + 200);
                        txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                    }            
                    ///movimiento//
                    for (int i = 0; i <= player2.GetPosition(); i++)
                    {

                        if (i >= 40)
                        {
                            txtMapData.Text = "Random event player 2: ¡Dirígete a 'GO' y ganas dinero!";
                            player2.SetPosition(0);
                            imgplayer2.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y), Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));
                            player2.SetMoney(player2.GetMoney() + 200);
                            i = 0;
                        }

                        else if (Spaces[i].position.Equals(player2.GetPosition()))
                        {
                            imgplayer2.Margin = new Thickness(Convert.ToDouble(Spaces[i].axis.x), Convert.ToDouble(Spaces[i].axis.y), Convert.ToDouble(Spaces[i].axis.z), Convert.ToDouble(Spaces[i].axis.s));
                        }
                        if (Spaces[30].position.Equals(player2.GetPosition()))
                        {
                            imgplayer2.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y), Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                            player2.jailed();
                            player2.SetPosition(10);
                        }
                    }
                    txtDice1.Text = dice.getDice1().ToString();
                    txtDice2.Text = dice.getDice2().ToString();
                    txtDice3.Text = dice.getDice3().ToString();
                }
                else
                {
                    escapeJail();
                }
                //////////////////////////////////////////////////////////////////////
                /////////////////////other moves: like taxes and planes//////////////
                ////////////////////////////////////////////////////////////////////
                if (Spaces[38].position.Equals(player2.GetPosition()))
                {
                    // si no tiene dinero para pagar que pasaba, lo tengo que crear yo?
                    // si no lo mando para la carcel
                    if (player2.GetMoney() >= 300)
                    {
                        double impr = player2.GetMoney() - 300;
                        txtMapData.Text = "jugador 2 paga impuestos, tienes " + player2.GetMoney() + "$ pero quedas con " + impr;
                        player2.SetMoney(player2.GetMoney() - 300);
                    }
                    else
                    {
                        txtMapData.Text = "No tienes para pagar impuestos! \n pasas la noche en la cárcel!";
                        player2.SetPosition(10);
                    }
                }
                else if (Spaces[4].position.Equals(player3.GetPosition()) || Spaces[28].position.Equals(player3.GetPosition()) || Spaces[35].position.Equals(player3.GetPosition()))
                {
                    Random DiceExtra = new Random();
                    int extradice = DiceExtra.Next(0, 40);
                    txtMapData.Text = "Woah, el jugador 1 tomó un avión con destino a la casilla " + extradice;
                    player2.SetPosition(extradice);
                    imgplayer2.Margin = new Thickness(Convert.ToDouble(Spaces[extradice].axis.x), Convert.ToDouble(Spaces[extradice].axis.y), Convert.ToDouble(Spaces[extradice].axis.z), Convert.ToDouble(Spaces[extradice].axis.s));
                }
                ///////////////carta chance/////////////////
                if (Spaces[7].position.Equals(player2.GetPosition()) || Spaces[22].position.Equals(player2.GetPosition()) || Spaces[25].position.Equals(player2.GetPosition()) || Spaces[36].position.Equals(player2.GetPosition()))
                    {
                        
                        Random r = new Random();
                        int rc = r.Next(0, 14);
                        //lee la descripcion de la carta
                        chance.drawChanceCards(rc);
                        player2.SetMoney(player2.GetMoney() + chance.UpdateDinero(rc));
                        txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                        if (chance.cadaJugadorPaga(rc) != 0)
                        {
                            if (playernumber == 2) // si es que hay dos jugadores
                            {
                                player1.SetMoney(player1.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 1
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();

                                player2.SetMoney(player2.GetMoney() + 10); //player 2 recibe $10
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                            }
                            else if (playernumber == 3) //si es que hay 3 jugadores
                            {
                                player1.SetMoney(player1.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 1
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                                player3.SetMoney(player3.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 3
                                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();

                                player2.SetMoney(player2.GetMoney() + 20); //player 2 recibe $20
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                            }
                            else if (playernumber == 4) //si es que hay 4 jugadores
                            {
                                player1.SetMoney(player1.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 1
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                                player3.SetMoney(player3.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 3
                                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
                                player4.SetMoney(player4.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 4
                                txtDataPlayer4.Text = "$" + player4.GetMoney().ToString();

                                player2.SetMoney(player2.GetMoney() + 30); //player 2 recibe $30
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                            }

                        }
                        if (chance.moverFicha(rc) != 80)
                        {
                        if (chance.moverFicha(rc) == 0) //ir a go y cobrar 200
                        {
                            player2.SetPosition(chance.moverFicha(rc));
                            player2.SetMoney(player2.GetMoney() + 200); // se le da el dinero por su vuelta
                            txtDataPlayer2.Text = "$" + player2.GetMoney().ToString(); //actualiza dinero
                            imgplayer2.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y), Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));
                        }
                        else
                        {
                            player2.SetPosition(chance.moverFicha(rc));
                            imgplayer2.Margin = new Thickness(Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.x), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.y), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.z), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.s));

                        }
                    }
                        else if (chance.gotojail(rc) != 80)
                        {
                            player2.jailed();
                            player2.SetPosition(chance.gotojail(rc));
                        imgplayer2.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y), Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                    }
                        else if (chance.devolverTarjetaF(rc) == true)
                        {
                            jugador2.Add(1);//se agrega un 1 a la lista, que despues se puede utilizar para escapar de la carcel
                        }

                    }
                    if (Spaces[2].position.Equals(player2.GetPosition()) || Spaces[5].position.Equals(player2.GetPosition()) || Spaces[15].position.Equals(player2.GetPosition()) || Spaces[17].position.Equals(player2.GetPosition()))
                    {
                        ///////////////Carta Nasdaq/////////////////
                        Random r = new Random();
                        int rc = r.Next(0, 13);
                        //lee la descripcion de la carta
                        nasdaq.drawNasdaqCard(rc);
                        player2.SetMoney(player2.GetMoney() + nasdaq.UpdateDinero(rc));
                        txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                        if (nasdaq.pagarACadaJugador(rc) != 0) // el jugador le paga $50 a cada uno de los jugadores
                        {
                            if (playernumber == 2)
                            {
                                player2.SetMoney(player2.GetMoney() + nasdaq.pagarACadaJugador(rc)); //jugador 2 paga 50
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();

                                player1.SetMoney(player1.GetMoney() + 50);
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                            }
                            else if (playernumber == 3)
                            {
                                player2.SetMoney(player2.GetMoney() + (nasdaq.pagarACadaJugador(rc) * 2)); //jugador 2 paga 100
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();

                                player1.SetMoney(player1.GetMoney() + 50);
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                                player3.SetMoney(player3.GetMoney() + 50);
                                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
                            }
                            else if (playernumber == 4)
                            {
                                player2.SetMoney(player2.GetMoney() + (nasdaq.pagarACadaJugador(rc) * 3)); //jugador 2 paga 150
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();

                                player1.SetMoney(player1.GetMoney() + 50);
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                                player3.SetMoney(player3.GetMoney() + 50);
                                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
                                player4.SetMoney(player4.GetMoney() + 50);
                                txtDataPlayer4.Text = "$" + player4.GetMoney().ToString();
                            }
                        }
                        if (nasdaq.moverFicha(rc) != 80)
                        {
                           
                        if (nasdaq.moverFicha(rc) == 0)
                            {
                                player2.SetPosition(nasdaq.moverFicha(rc));
                                player2.SetMoney(player2.GetMoney() + 200); // se le da el dinero por su vuelta
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString(); //actualiza dinero
                                 imgplayer2.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y), Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));

                        }
                        else
                        {
                            player2.SetPosition(nasdaq.moverFicha(rc));
                            imgplayer2.Margin = new Thickness(Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.x), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.y), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.z), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.s));

                        }
                         }
                        else if (nasdaq.gotojail(rc) != 80)
                        {
                            player2.jailed();
                            player2.SetPosition(nasdaq.gotojail(rc));
                            imgplayer2.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y), Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                         }
                        else if (nasdaq.moverFicha(rc) == 12)
                          {
                            if (player2.GetPosition() <= 17 || player2.GetPosition() >= 5)
                             {
                               player2.SetPosition(nasdaq.moverFicha(rc));
                             }
                          }
                        else if (nasdaq.moverFicha(rc) == 33)
                         {
                            if (player2.GetPosition() == 3)
                             {
                                player2.SetPosition(nasdaq.moverFicha(rc));
                             }
                         }
                        

                }
                    
            }

            //////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////
            ///////////////////C O M I E N Z A    J U G A D O R    T R E S/////////////////
            //////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////
            //para revirsar codigo, revisar jugador 1
            else if (Turnoactual == 3)
            {
                txtMapData.Text = "Comienza el turno del Jugador 3";
                Facep1.Margin = new Thickness(1018, 198, -418, 54);
                Facep2.Margin = new Thickness(1018, 198, -418, 54);
                Facep3.Margin = new Thickness(600, 250, 0, 0);
                Facep4.Margin = new Thickness(1018, 198, -418, 54);
                if (player3.getJail() == false)
                {
                    int valor = dice.throwDice();
                    player3.SetPosition(player3.GetPosition() + valor);
                    if (player3.GetPosition() >= 40)
                    {
                        player3.SetPosition(player3.GetPosition() - 40);
                        player3.SetMoney(player3.GetMoney() + 200);
                        txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
                    }
                    ////////////////////////////////////////////////////////////
                    ////////////////////INICIA MOVIMIENTO//////////////////////
                    //////////////////////////////////////////////////////////

                    for (int i = 0; i <= player3.GetPosition() + 1; i++)
                    {
                        if (i >= 40)
                        {
                            txtMapData.Text = "Random event player 3: ¡Dirígete a 'GO' y ganas dinero!";
                            player3.SetPosition(0);
                            imgplayer3.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y), Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));
                            player3.SetMoney(player3.GetMoney() + 200);
                            i = 0;                  
                        }
                        else if (Spaces[i].position.Equals(player3.GetPosition()))
                        {
                            imgplayer3.Margin = new Thickness(Convert.ToDouble(Spaces[i].axis.x), Convert.ToDouble(Spaces[i].axis.y), Convert.ToDouble(Spaces[i].axis.z), Convert.ToDouble(Spaces[i].axis.s));
                        }
                        if (Spaces[30].position.Equals(player3.GetPosition()))
                        {
                            imgplayer3.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y), Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                            player3.jailed();
                            player3.SetPosition(10);
                        }
                    }
                    txtDice1.Text = dice.getDice1().ToString();
                    txtDice2.Text = dice.getDice2().ToString();
                    txtDice3.Text = dice.getDice3().ToString();
                }
                else
                {
                    escapeJail();
                }
                //////////////////////////////////////////////////////////////////////
                /////////////////////other moves: like taxes and planes//////////////
                ////////////////////////////////////////////////////////////////////
                if (Spaces[38].position.Equals(player3.GetPosition()))
                {
                    // si no tiene dinero para pagar que pasaba, lo tengo que crear yo?
                    // si no lo mando para la carcel
                    if (player3.GetMoney() >= 300)
                    {
                        double impr = player3.GetMoney() - 300;
                        txtMapData.Text = "jugador 3 paga impuestos, tienes " + player3.GetMoney() + "$ pero quedas con " + impr;
                        player3.SetMoney(player3.GetMoney() - 300);
                    }
                    else
                    {
                        txtMapData.Text = "No tienes para pagar impuestos! \n pasas la noche en la cárcel!";
                        player3.SetPosition(10);
                    }
                }
                else if (Spaces[4].position.Equals(player3.GetPosition()) || Spaces[28].position.Equals(player3.GetPosition()) || Spaces[35].position.Equals(player3.GetPosition()))
                {
                    Random DiceExtra = new Random();
                    int extradice = DiceExtra.Next(0, 40);
                    txtMapData.Text = "Woah, el jugador 1 tomó un avión con destino a la casilla " + extradice;
                    player3.SetPosition(extradice);
                    imgplayer3.Margin = new Thickness(Convert.ToDouble(Spaces[extradice].axis.x), Convert.ToDouble(Spaces[extradice].axis.y), Convert.ToDouble(Spaces[extradice].axis.z), Convert.ToDouble(Spaces[extradice].axis.s));
                }
                if (Spaces[7].position.Equals(player3.GetPosition()) || Spaces[22].position.Equals(player3.GetPosition()) || Spaces[25].position.Equals(player3.GetPosition()) || Spaces[36].position.Equals(player3.GetPosition()))
                    {
                        ///////////////carta chance/////////////////
                        Random r = new Random();
                        int rc = r.Next(0, 14);
                        //lee la descripcion de la carta
                        chance.drawChanceCards(rc);
                        player3.SetMoney(player3.GetMoney() + chance.UpdateDinero(rc));
                        txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
                        if (chance.cadaJugadorPaga(rc) != 0)
                        {

                            if (playernumber == 3) //si es que hay 3 jugadores
                            {
                                player2.SetMoney(player2.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 2
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                                player1.SetMoney(player1.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 1
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();

                                player3.SetMoney(player3.GetMoney() + 20); //player 3 recibe $20
                                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
                            }
                            else if (playernumber == 4) //si es que hay 4 jugadores
                            {
                                player2.SetMoney(player2.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 2
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                                player1.SetMoney(player1.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 1
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                                player4.SetMoney(player4.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 4
                                txtDataPlayer4.Text = "$" + player4.GetMoney().ToString();

                                player3.SetMoney(player3.GetMoney() + 30); //player 3 recibe $30
                                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
                            }

                        }
                        if (chance.moverFicha(rc) != 80)
                        {
                            if (chance.moverFicha(rc) == 0)
                            {
                            player3.SetPosition(chance.moverFicha(rc));
                            player3.SetMoney(player3.GetMoney() + 200); // se le da el dinero por su vuelta
                            txtDataPlayer3.Text = "$" + player3.GetMoney().ToString(); //actualiza dinero
                            imgplayer3.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y), Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));

                             }
                            else
                            {
                            player3.SetPosition(chance.moverFicha(rc));
                            imgplayer3.Margin = new Thickness(Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.x), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.y), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.z), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.s));

                            }
                        }
                        else if (chance.gotojail(rc) != 80)
                        {
                            player3.jailed();
                            player3.SetPosition(chance.gotojail(rc));
                            imgplayer3.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y), Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                    }
                        else if (chance.devolverTarjetaF(rc) == true)
                        {
                            jugador3.Add(1);//se agrega un 1 a la lista, que despues se puede utilizar para escapar de la carcel
                        }
                    }
                    if (Spaces[2].position.Equals(player3.GetPosition()) || Spaces[5].position.Equals(player3.GetPosition()) || Spaces[15].position.Equals(player3.GetPosition()) || Spaces[17].position.Equals(player3.GetPosition()))
                    {
                        ///////////////Carta Nasdaq/////////////////
                        Random r = new Random();
                        int rc = r.Next(0, 13);
                        //lee la descripcion de la carta
                        nasdaq.drawNasdaqCard(rc);
                        player3.SetMoney(player3.GetMoney() + nasdaq.UpdateDinero(rc));
                        txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
                        if (nasdaq.pagarACadaJugador(rc) != 0) // el jugador le paga $50 a cada uno de los jugadores
                        {
                            if (playernumber == 3)
                            {
                                player3.SetMoney(player3.GetMoney() + (nasdaq.pagarACadaJugador(rc) * 2)); //jugador 3 paga 100
                                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();

                                player1.SetMoney(player1.GetMoney() + 50);
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                                player2.SetMoney(player2.GetMoney() + 50);
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                            }
                            else if (playernumber == 4)
                            {
                                player3.SetMoney(player3.GetMoney() + (nasdaq.pagarACadaJugador(rc) * 3)); //jugador 3 paga 150
                                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();

                                player1.SetMoney(player1.GetMoney() + 50);
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                                player2.SetMoney(player2.GetMoney() + 50);
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                                player4.SetMoney(player4.GetMoney() + 50);
                                txtDataPlayer4.Text = "$" + player4.GetMoney().ToString();

                            }
                        }
                        if (nasdaq.moverFicha(rc) != 80)
                        {
                            
                        if (nasdaq.moverFicha(rc) == 0)
                            {
                                player3.SetPosition(nasdaq.moverFicha(rc));
                                player3.SetMoney(player3.GetMoney() + 200); // se le da el dinero por su vuelta
                                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString(); //actualiza dinero
                                imgplayer3.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y), Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));

                        }
                        else
                        {
                            player3.SetPosition(nasdaq.moverFicha(rc));
                            imgplayer3.Margin = new Thickness(Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.x), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.y), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.z), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.s));

                        }
                    }
                        else if (nasdaq.gotojail(rc) != 80)
                        {
                            player3.jailed();
                            player3.SetPosition(nasdaq.gotojail(rc));
                            imgplayer3.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y), Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                        }
                        else if (nasdaq.moverFicha(rc) == 12)
                        {
                             if (player3.GetPosition() <= 17 || player3.GetPosition() >= 5)
                                {
                                     player3.SetPosition(nasdaq.moverFicha(rc));
                                }
                        }
                        else if (nasdaq.moverFicha(rc) == 33)
                        {
                             if (player3.GetPosition() == 3)
                             {
                                player3.SetPosition(nasdaq.moverFicha(rc));
                             }
                         }
                        
                }

            }
            //////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////
            ///////////////////C O M I E N Z A    J U G A D O R    C U A T R O/////////////
            //////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////
            //para revirsar codigo, revisar jugador 1
            else if (Turnoactual == 4)
            {
                txtMapData.Text = "Comienza el turno del Jugador 4";
                Facep1.Margin = new Thickness(1018, 198, -418, 54);
                Facep2.Margin = new Thickness(1018, 198, -418, 54);
                Facep3.Margin = new Thickness(1018, 198, -418, 54);
                Facep4.Margin = new Thickness(600, 250, 0, 0);
                if (player4.getJail() == false)
                {
                    int valor = dice.throwDice();
                    player4.SetPosition(player4.GetPosition() + valor);
                    if (player4.GetPosition() >= 40)
                    {
                        player4.SetPosition(player4.GetPosition() - 40);
                        player4.SetMoney(player4.GetMoney() + 200);
                        txtDataPlayer4.Text = "$" + player4.GetMoney().ToString();
                    }
                    //////////////M O V I M I E N T O ///////////////////////
                    for (int i = 0; i <= player4.GetPosition() + 1; i++)
                    {
                        if (i > 39)
                        {
                            txtMapData.Text = "Random event player 1: ¡Dirígete a 'GO' y ganas dinero!";
                            player4.SetPosition(0);
                            imgplayer4.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y), Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));
                            player4.SetMoney(player4.GetMoney() + 200);
                            i = 0;
                        }
                        else if (Spaces[i].position.Equals(player4.GetPosition()))
                        {
                            imgplayer4.Margin = new Thickness(Convert.ToDouble(Spaces[i].axis.x), Convert.ToDouble(Spaces[i].axis.y), Convert.ToDouble(Spaces[i].axis.z), Convert.ToDouble(Spaces[i].axis.s));
                        }
                        if (Spaces[30].position.Equals(player4.GetPosition()))
                        {
                            imgplayer4.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y), Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                            player4.jailed();
                            player4.SetPosition(10);
                        }
                    }
                    txtDice1.Text = dice.getDice1().ToString();
                    txtDice2.Text = dice.getDice2().ToString();
                    txtDice3.Text = dice.getDice3().ToString();
                }
                else
                {
                    escapeJail();
                }
                //////////////////////////////////////////////////////////////////////
                /////////////////////other moves: like taxes and planes//////////////
                ////////////////////////////////////////////////////////////////////
                if (Spaces[38].position.Equals(player4.GetPosition()))
                {
                    // si no tiene dinero para pagar que pasaba, lo tengo que crear yo?
                    // si no lo mando para la carcel
                    if (player4.GetMoney() >= 300)
                    {
                        double impr = player4.GetMoney() - 300;
                        txtMapData.Text = "jugador 4 paga impuestos, tienes " + player4.GetMoney() + "$ pero quedas con " + impr;
                        player4.SetMoney(player4.GetMoney() - 300);
                    }
                    else
                    {
                        txtMapData.Text = "No tienes para pagar impuestos! \n pasas la noche en la cárcel!";
                        player4.SetPosition(10);
                    }
                }
                else if (Spaces[4].position.Equals(player4.GetPosition()) || Spaces[28].position.Equals(player4.GetPosition()) || Spaces[35].position.Equals(player4.GetPosition()))
                {
                    Random DiceExtra = new Random();
                    int extradice = DiceExtra.Next(0, 40);
                    txtMapData.Text = "Woah, el jugador 1 tomó un avión con destino a la casilla " + extradice;
                    player4.SetPosition(extradice);
                    imgplayer4.Margin = new Thickness(Convert.ToDouble(Spaces[extradice].axis.x), Convert.ToDouble(Spaces[extradice].axis.y), Convert.ToDouble(Spaces[extradice].axis.z), Convert.ToDouble(Spaces[extradice].axis.s));
                }

                if (Spaces[7].position.Equals(player4.GetPosition()) || Spaces[22].position.Equals(player4.GetPosition()) || Spaces[25].position.Equals(player4.GetPosition()) || Spaces[36].position.Equals(player4.GetPosition()))
                    {
                        ///////////////carta chance/////////////////
                        Random r = new Random();
                        int rc = r.Next(0, 14);
                        //lee la descripcion de la carta
                        chance.drawChanceCards(rc);
                        player4.SetMoney(player4.GetMoney() + chance.UpdateDinero(rc));
                        txtDataPlayer4.Text = "$" + player4.GetMoney().ToString();
                        if (chance.cadaJugadorPaga(rc) != 0)
                        {

                            player2.SetMoney(player2.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 2
                            txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                            player3.SetMoney(player3.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 3
                            txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();
                            player1.SetMoney(player1.GetMoney() + chance.cadaJugadorPaga(rc)); //le saca 10 a player 1
                            txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();

                            player4.SetMoney(player4.GetMoney() + 30); //player 4 recibe $30
                            txtDataPlayer4.Text = "$" + player4.GetMoney().ToString();


                        }
                        if (chance.moverFicha(rc) != 80)
                        {

                            if (chance.moverFicha(rc) == 0)
                            {
                            player4.SetPosition(chance.moverFicha(rc));
                            player4.SetMoney(player4.GetMoney() + 200); // se le da el dinero por su vuelta
                            txtDataPlayer4.Text = "$" + player4.GetMoney().ToString(); //actualiza dinero
                            imgplayer4.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y), Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));

                            }
                            else
                            {
                            player4.SetPosition(chance.moverFicha(rc));
                            imgplayer4.Margin = new Thickness(Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.x), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.y), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.z), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.s));

                            }
                        }
                        else if (chance.gotojail(rc) != 80)
                        {
                            player4.jailed();
                            player4.SetPosition(chance.gotojail(rc));
                        imgplayer4.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y), Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));

                    }
                        else if (chance.devolverTarjetaF(rc) == true)
                        {
                            jugador4.Add(1);//se agrega un 1 a la lista, que despues se puede utilizar para escapar de la carcel
                        }

                    }
                    if (Spaces[2].position.Equals(player4.GetPosition()) || Spaces[5].position.Equals(player4.GetPosition()) || Spaces[15].position.Equals(player4.GetPosition()) || Spaces[17].position.Equals(player4.GetPosition()))
                    {
                        ///////////////Carta Nasdaq/////////////////
                        Random r = new Random();
                        int rc = r.Next(0, 13);
                        //lee la descripcion de la carta
                        nasdaq.drawNasdaqCard(rc);
                        player4.SetMoney(player4.GetMoney() + nasdaq.UpdateDinero(rc));
                        txtDataPlayer4.Text = "$" + player4.GetMoney().ToString();
                        if (nasdaq.pagarACadaJugador(rc) != 0) // el jugador le paga $50 a cada uno de los jugadores
                        {
                            if (playernumber == 4)
                            {
                                player4.SetMoney(player4.GetMoney() + (nasdaq.pagarACadaJugador(rc) * 3)); //jugador 4 paga 150
                                txtDataPlayer4.Text = "$" + player4.GetMoney().ToString();

                                player1.SetMoney(player1.GetMoney() + 50);
                                txtDataPlayer1.Text = "$" + player1.GetMoney().ToString();
                                player2.SetMoney(player2.GetMoney() + 50);
                                txtDataPlayer2.Text = "$" + player2.GetMoney().ToString();
                                player3.SetMoney(player3.GetMoney() + 50);
                                txtDataPlayer3.Text = "$" + player3.GetMoney().ToString();

                            }
                        }
                        if (nasdaq.moverFicha(rc) != 80)
                        {
                            
                            if (nasdaq.moverFicha(rc) == 0)
                            {
                                player4.SetPosition(nasdaq.moverFicha(rc));
                                player4.SetMoney(player4.GetMoney() + 200); // se le da el dinero por su vuelta
                                txtDataPlayer4.Text = "$" + player4.GetMoney().ToString(); //actualiza dinero
                                imgplayer4.Margin = new Thickness(Convert.ToDouble(Spaces[0].axis.x), Convert.ToDouble(Spaces[0].axis.y), Convert.ToDouble(Spaces[0].axis.z), Convert.ToDouble(Spaces[0].axis.s));
                            }
                        else
                        {
                            player4.SetPosition(nasdaq.moverFicha(rc));
                            imgplayer4.Margin = new Thickness(Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.x), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.y), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.z), Convert.ToDouble(Spaces[nasdaq.moverFicha(rc)].axis.s));

                        }
                    }
                        else if (nasdaq.gotojail(rc) != 80)
                        {
                            player4.jailed();
                            player4.SetPosition(nasdaq.gotojail(rc));
                            imgplayer4.Margin = new Thickness(Convert.ToDouble(Spaces[10].axis.x), Convert.ToDouble(Spaces[10].axis.y), Convert.ToDouble(Spaces[10].axis.z), Convert.ToDouble(Spaces[10].axis.s));
                        }
                        else if (nasdaq.moverFicha(rc) == 12)
                         {
                            if (player4.GetPosition() <= 17 || player4.GetPosition() >= 5)
                            {
                                player4.SetPosition(nasdaq.moverFicha(rc));
                            }
                         }
                         else if (nasdaq.moverFicha(rc) == 33)
                         {
                             if (player4.GetPosition() == 3)
                             {
                                player4.SetPosition(nasdaq.moverFicha(rc));
                             }
                         }
                }
            }
        }

        //el codigo para salir del Jail
        public void escapeJail()
        {
                                                           //lista de cartas para escapar de la carcel
            //escapa de la carcel                                      // |
            if (Turnoactual == 1)                                      // |
            {                                                          // |
                                                                       // |
                int valor = dice.throwDice();                          // v
                if (dice.isDouble() == true || turnsInJail1 == 3 || jugador1.Count != 0)
                //revisa si salio un numero repetido, o si ya pasaron los 3 turnos
                {
                    jugador1.Clear();
                    turnsInJail1 = 0;
                    player1.free();
                    player1.SetPosition(player1.GetPosition() + valor);

                    for (int i = 0; i <= player1.GetPosition(); i++)
                    {
                        if (Spaces[i].position.Equals(player1.GetPosition()))
                        {
                            imgplayer1.Margin = new Thickness(Convert.ToDouble(Spaces[i].axis.x), Convert.ToDouble(Spaces[i].axis.y), Convert.ToDouble(Spaces[i].axis.z), Convert.ToDouble(Spaces[i].axis.s));
                        }
                    }
                }
                if (dice.isDouble() == false)
                {
                    //de lo contrario, suma 1 en el contador de turnos para salir
                    turnsInJail1++;
                }
                txtDice1.Text = dice.getDice1().ToString();
                txtDice2.Text = dice.getDice2().ToString();
                txtDice3.Text = dice.getDice3().ToString();
            }
            else if (Turnoactual == 2)
            {
                int valor = dice.throwDice();
                if (dice.isDouble() == true || turnsInJail2 == 3 || jugador2.Count != 0)
                {
                    jugador2.Clear();
                    turnsInJail2 = 0;
                    player2.free();
                    player2.SetPosition(player2.GetPosition() + valor);

                    for (int i = 0; i <= player2.GetPosition(); i++)
                    {
                        if (Spaces[i].position.Equals(player2.GetPosition()))
                        {
                            imgplayer2.Margin = new Thickness(Convert.ToDouble(Spaces[i].axis.x), Convert.ToDouble(Spaces[i].axis.y), Convert.ToDouble(Spaces[i].axis.z), Convert.ToDouble(Spaces[i].axis.s));
                        }
                    }
                }
                if (dice.isDouble() == false)
                {
                    turnsInJail2++;
                }
                txtDice1.Text = dice.getDice1().ToString();
                txtDice2.Text = dice.getDice2().ToString();
                txtDice3.Text = dice.getDice3().ToString();
            }
            else if (Turnoactual == 3)
            {
                int valor = dice.throwDice();
                if (dice.isDouble() == true || turnsInJail3 == 3 || jugador3.Count != 0)
                {
                    jugador3.Clear();
                    turnsInJail3 = 0;
                    player3.free();
                    player3.SetPosition(player3.GetPosition() + valor);

                    for (int i = 0; i <= player3.GetPosition(); i++)
                    {
                        if (Spaces[i].position.Equals(player3.GetPosition()))
                        {
                            imgplayer3.Margin = new Thickness(Convert.ToDouble(Spaces[i].axis.x), Convert.ToDouble(Spaces[i].axis.y), Convert.ToDouble(Spaces[i].axis.z), Convert.ToDouble(Spaces[i].axis.s));
                        }
                    }
                }
                if (dice.isDouble() == false)
                {
                    turnsInJail3++;
                }
                txtDice1.Text = dice.getDice1().ToString();
                txtDice2.Text = dice.getDice2().ToString();
                txtDice3.Text = dice.getDice3().ToString();
            }
            else if (Turnoactual == 4)
            {
                int valor = dice.throwDice();
                if (dice.isDouble() == true || turnsInJail4 == 3 || jugador4.Count != 0)
                {
                    jugador4.Clear();
                    turnsInJail4 = 0;
                    player4.free();
                    player4.SetPosition(player4.GetPosition() + valor);

                    for (int i = 0; i <= player4.GetPosition(); i++)
                    {
                        if (Spaces[i].position.Equals(player4.GetPosition()))
                        {
                            imgplayer4.Margin = new Thickness(Convert.ToDouble(Spaces[i].axis.x), Convert.ToDouble(Spaces[i].axis.y), Convert.ToDouble(Spaces[i].axis.z), Convert.ToDouble(Spaces[i].axis.s));
                        }
                    }
                }
                if (dice.isDouble() == false)
                {
                    turnsInJail4++;
                }
                txtDice1.Text = dice.getDice1().ToString();
                txtDice2.Text = dice.getDice2().ToString();
                txtDice3.Text = dice.getDice3().ToString();
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
                    {
                        players[i].GetID();
                    }
                    else if (Spaces[position].getOwner() != jugadorActual)
                    {
                        for (int j = 0; j < players.Count; j++)
                        {
                            if (players[j].GetID() == Spaces[position].getOwner() && Spaces[position].getPrestamo() == false)
                            {
                                //paga
                                double monto = Spaces[position].getPrice() / 10;
                                int id = players[j].GetID();
                                Spaces[position].LevelUp();
                                //msgbox, cambiar por texto ojalá, evitar messagebox
                                txtMapData.Text = "tienes que pagar $" + monto + " al player " + id;
                                MessageBox.Show("tienes que pagar " + monto + " al player " + id);
                                players[i].pagar(monto, players[j]);
                                break;
                            }
                        }
                    }
                }
            }
            actualizarDinero();          
        }

        private void btnNextTurn_Click(object sender, RoutedEventArgs e)
        {
            Turn.Enqueue(Turnoactual);
            //le pone el turno actual al queque, es decir, ahora le toca al ultimo
            Iniciarturno();
            pagarJugadores();
            mostrarTurno();
            //txtMapData.Text = "";
            if(jugadorSinDinero() == true)
            {
                determinarGanador();
                terminarJuego();
            }
            //el juego tiene que seguir
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Iniciarturno();
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
                        Spaces[posicion].canBuy = false;//atributo se cambia a false. lo cual indica que este empresa no puede ser comprado
                        Spaces[posicion].setOwner(players[i].GetID());
                        MessageBox.Show("Compraste " + Spaces[posicion].name + ". Felicitaciones!");
                    }
                    else if (players[i].GetMoney() < Spaces[posicion].getPrice())
                    {
                        MessageBox.Show("No tienes suficiente dinero para comprar la empresa");
                    }
                    else
                    {
                        MessageBox.Show("Este empresa ya tiene un dueño");
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
            GridTrade.Visibility = Visibility.Visible;//el grid para hacer un trade se hace visible cuando se apreta el boton
            lblAR.Visibility = Visibility.Hidden;
            rbSi.Visibility = Visibility.Hidden;
            rbNo.Visibility = Visibility.Hidden;
            
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
                    GridTrade.Visibility = Visibility.Hidden;
                    btnTrade.Visibility = Visibility.Visible;
                }
                
                if (players[i].GetID() == jugadorActual)
                {
                    _empresas = players[i].GetHoldings();//se almacenan las empresas del jugador que inicio el trade en la lista _empresas
                    foreach(holdings h in _empresas)
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
                        _Empresas = players[i].GetHoldings();
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
                GridTrade.Visibility = Visibility.Hidden;
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
                GridTrade.Visibility = Visibility.Hidden;
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
                    txtMapData.Text = "¡ No puedes hacer ofertas vacias !";
                    MessageBox.Show("¡ No puedes hacer ofertas vacias !");
                    rbSi.IsChecked = false;

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
                            if (players[i].GetID() == jugadorActual)
                            {
                                ja = players[i];//jugadorActual
                                _empresas = players[i].GetHoldings();//empresas del jugadorActual se almacenan en _empresas
                                for (int j = 0; j < _empresas.Count; j++)
                                {
                                    if (_empresas[j].getName().Equals(campos[0]))
                                    {
                                        JA = _empresas[j];//empresa que el jugadorActual ofrece a otro jugador
                                    }
                                }
                            }

                            if (players[i].GetID() == jugadorTrade)
                            {
                                jt = players[i];//jugador que el jugadorActual eligio para hacer un trade
                                _Empresas = players[i].GetHoldings();
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
                        GridTrade.Visibility = Visibility.Hidden;
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
                GridTrade.Visibility = Visibility.Hidden;
                btnTrade.Visibility = Visibility.Visible;
            }
        }

        private void btnPrestamos_Click(object sender, RoutedEventArgs e)
        {
            gridPrestamo.Visibility = Visibility.Visible;
            cboPrestamo.Items.Clear();
            rbHacerPrestamo.IsChecked = false;
            rbCancelarPrestamo.IsChecked = false;
            List<holdings> _empresas = new List<holdings>();

            for (int i = 0; i < players.Count; i++)
            {
                if(players[i].GetID() == Turnoactual)//juego encuentra el jugadorActual
                {
                    _empresas = players[i].GetHoldings();// empreas del jugador se almacenan en _empresas
                    foreach(holdings h in _empresas)
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
                gridPrestamo.Visibility = Visibility.Hidden;
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
                        foreach (holdings h in players[i].GetHoldings())//recorre las empresas del jugadorActual
                        {
                            if (h.getName().Equals(campos[0]) && h.getPrestamo() == false)//encontramos la empresa en el cbo dentro de la lista del jugadorActual
                            {
                                players[i].pedirPrestamo(h);
                                MessageBox.Show(h.getName() + ", no puedes cobrar a jugadores que caen en ese espacio hasta que canceles el prestamo");
                            }
                            else
                            {
                                MessageBox.Show("Ya pediste un prestamo con acciones de este empresa");
                            }
                        }
                    }
                }
                actualizarDinero();
                gridPrestamo.Visibility = Visibility.Hidden;              
            }
        }

        private void rbCancelarPrestamo_Checked(object sender, RoutedEventArgs e)
        {
            if (cboPrestamo.SelectedItem == null)
            {
                gridPrestamo.Visibility = Visibility.Hidden;
            }
            else
            {
                string empresa = cboPrestamo.SelectedItem.ToString();//empresa se almacena en un string, para tener el nombre disponible para hacer una comparacion
                string[] campos = empresa.Split(',');

                for (int i = 0; i < players.Count; i++)//para identificar el jugadorActual
                {
                    if (players[i].GetID() == Turnoactual)
                    {
                        foreach (holdings h in players[i].GetHoldings())//recorre las empresas del jugadorActual
                        {
                            if (h.getName().Equals(campos[0]) && h.getPrestamo() == true)//encontramos la empresa en el cbo dentro de la lista del jugadorActual
                            {
                                players[i].cancelarPrestamo(h);
                                MessageBox.Show(h.getName() + ", Este espacio te va a generar ingresos nuevamente");
                            }
                            else//en caso de que un jugador intenta cancelar su prestamo con activos de otra empresa
                            {
                                MessageBox.Show("No se puede cancelar");
                            }
                        }
                    }
                }
                actualizarDinero();
                gridPrestamo.Visibility = Visibility.Hidden;
            }
        }

        private void btnTradeCancelar_Click(object sender, RoutedEventArgs e)
        {
            GridTrade.Visibility = Visibility.Hidden;
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
