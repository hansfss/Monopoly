using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monopoly_Nasdaq_Alpha_v0._01
{
    class Nasdaq : List<Cartas>
    {
        List<Cartas> nasdaq = new List<Cartas>();
        Cartas n = new Cartas();
        //Random r = new Random();
        //int rc = r.Next(0, 13);


        public Nasdaq()
        {
            //tipo: d=dinero, p = posicion, dp=dinero y posicion, f = free of jail, j=jail, pj= pagar a jugador, r= retroceder

            nasdaq.Add(new Cartas("Perdiste tu maletín en uno de tus viajes, compra uno nuevo por $15", "d", 0, -15));
            nasdaq.Add(new Cartas("Perdiste la apuesta con tus amigos, paga a cada jugador $50", "pj", 0, -50)); // pagar a jugador
            nasdaq.Add(new Cartas("El nuevo articulo a la venta en tu empresa ha sido un éxito, toma $50", "d", 0, 50));
            nasdaq.Add(new Cartas("Solo porque sí, toma $150", "d", 0, 150));
            nasdaq.Add(new Cartas("Te dieron ganas de hacer deporte, pero necesitas zapatillas... Avanza a 'Nike'", "p", 6, 0));
            nasdaq.Add(new Cartas("Toma un vuelo a 'GO' y cobra los $200","p", 0, 0));
            nasdaq.Add(new Cartas("Un video tuyo privado fue filtrado, corre a 'Facebook' para que lo borren", "p", 11, 0));
            nasdaq.Add(new Cartas("Necesitas cambiar tu auto, por qué no por un Porsche? Avanza hasta 'Porsche'", "p", 24, 0));
            nasdaq.Add(new Cartas("¿Quiéres ser tu propio jefe? Dirígete a la oficina de 'eToro' más cercana ", "p", 12,0)); //etoro
            nasdaq.Add(new Cartas("Te necesitan urgente en las oficinas de 'eToro' (Dírigite a la casilla de 'eToro' más cercana) ", "p", 33,0)); //etoro
            nasdaq.Add(new Cartas("Necesitas comprar una camisa nueva en 'Tommy Hilfiger', avanza a la casilla", "p", 39, 0));
            nasdaq.Add(new Cartas("Has sido descubierto robando dinero de la empresa, ve directo a la cárcel, no pases por 'GO' ni cobres los $200", "j", 10, 0)); //GO TO JAIL
            nasdaq.Add(new Cartas("Alguien te está intentado de ayudar a salir de la cárcel gratis", "f", 10, 0)); //FREE
        }

        public int drawNasdaqCard(int numeroazar)
        {
            MessageBox.Show(nasdaq[numeroazar].descripcion, "¡Nasdaq-100!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            //UpdateDinero(numeroazar);
            //moverFicha(rc,PlayerNumbers);
            return numeroazar;
        }

        public double UpdateDinero(int nr)
        {

            if (nasdaq[nr].tipo == "d")
            {
                //players[Turnoactual].SetMoney(players[Turnoactual].GetMoney() + chance[a].dinero);
                return nasdaq[nr].dinero;
            }
            //else if(chance[nr].tipo == "jp")
            return 0;
        }
        public int moverFicha(int a)
        {
            if (nasdaq[a].tipo == "p")
            {
                return nasdaq[a].posicion;
            }
            
            
            return 80;
        }
        public double pagarACadaJugador(int a)
        {
            if (nasdaq[a].tipo == "pj")
            {
                return nasdaq[a].dinero;
            }
            return 0;
        }

        public int gotojail(int a)
        {
            if (nasdaq[a].tipo == "j")
            {
                return nasdaq[a].posicion;
                ///players[Turnoactual].jailed();
            }
            return 80;


            //else if (nasdaq[a].tipo == "f")
            //{
            //    ///players[Turnoactual].free();
            //}
        }
    }
}
