using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Controls;

namespace Monopoly_Nasdaq_Alpha_v0._01
{
   class Chance : List<Cartas>
    {
        List<Cartas> chance = new List<Cartas>();
        Cartas c = new Cartas();
        


        public Chance()
        {
            //tipo: d=dinero, p = posicion, dp=dinero y posicion, f = free of jail, j=jail, jp= jugadores pagan

            chance.Add(new Cartas("Por venta de stock, ganas $10", "d", 0, 10));
            chance.Add(new Cartas("Los clientes se han vuelto locos, ganas $20", "d", 0, 20));
            chance.Add(new Cartas("Por venta de stock, ganas $25", "d", 0, 25));
            chance.Add(new Cartas("¡Felicitaciones!Ganaste un concurso, cobra $50", "d", 0, 50));
            chance.Add(new Cartas("Has sido elegido accionista del año, toma $100", "d", 0, 100));
            chance.Add(new Cartas("Cada día mejor, toma un incentivo de $100", "d", 0, 10));
            chance.Add(new Cartas("Cine en tu casa, que cada jugador te pague $10", "jp", 0, -10)); //cada jugador paga 10
            chance.Add(new Cartas("¿Quiéres ser tu propio jefe? La oficina de 'eToro' te premia con $100", "d", 0, 100));
            chance.Add(new Cartas("Fuiste al casino y ganaste $200", "d", 0, 200));
            chance.Add(new Cartas("Toma un vuelo rápido al inicio, Viaja a 'GO' y cobra $200", "p", 0, 0));
            chance.Add(new Cartas("Perdiste la apuesta, paga $50", "d", 0, -50));
            chance.Add(new Cartas("Algunos de tus articulos caducaron, pierdes $50", "d", 0, -50));
            chance.Add(new Cartas("Tus empleados necesitan un incentivo, paga $100", "d", 0, -100));
            chance.Add(new Cartas("Has sido descubierto evadiendo impuestos, ve directo a la cárcel, no pases por 'GO' ni cobres $200", "j", 10, 0)); //GO TO JAIL
            chance.Add(new Cartas("Alguien te está intentado de ayudar a salir de la cárcel gratis (Usa esta tarjeta para salir de la cárcel gratis o guárdala para cuando la necesites)", "f", 10, 0)); //FREE

            
        }

        public int drawChanceCards(int numeroazar)
        {
            
                MessageBox.Show(chance[numeroazar].descripcion, "¡Chance!", MessageBoxButton.OK,MessageBoxImage.Question);
                //UpdateDinero(numeroazar);
                //moverFicha(rc,PlayerNumbers);
            
                return numeroazar;
            
        }

        public double UpdateDinero(int nr) 
        {

            if (chance[nr].tipo == "d")
            {
                //players[Turnoactual].SetMoney(players[Turnoactual].GetMoney() + chance[a].dinero);
                return chance[nr].dinero;
            }
            //else if(chance[nr].tipo == "jp")
            

            
            return 0;

        }

        public int moverFicha(int a)
        {
            if (chance[a].tipo == "p")
                {
                    return chance[a].posicion;
                }
            return 80;
        }

        public double cadaJugadorPaga(int a)
        {
            if (chance[a].tipo == "jp")
            {
                return chance[a].dinero;
            }
            return 0;
        }

        public int gotojail(int a)
        {
            if (chance[a].tipo == "j")
            {
                return chance[a].posicion;
                ///players[Turnoactual].jailed();
            }
            return 80;


        }

        public bool devolverTarjetaF(int a)// devuelve la carta chance para escapar si el tipo es f
        {
            bool tarjetaEscapar = false;
            if (chance[a].tipo == "f")
            {
                tarjetaEscapar = true;
            }
            return tarjetaEscapar;
        }

        public List<Cartas> getCartas()
        {
            return chance;
        }

    }
}
