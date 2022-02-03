using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Monopoly_Nasdaq_Alpha_v0._01
{
    class characters
    {
        double Money;
        int ID;
        List<holdings> Propiedades = new List<holdings>();
        bool InJail;
        int Position;
        string Image;

        public characters()
        {
            this.Money = 0;
            this.ID = 0;
            this.Propiedades = new List<holdings>();
            this.InJail = false;
            this.Position = 0;
            this.Image = "";
        }

        public characters(int id)
        {
            ID = id;
        }
        public characters(double money, int iD, List<holdings> propiedades, bool inJail, int position, string i)
        {
            Money = money;
            ID = iD;
            Position = position;
            Propiedades = propiedades;
            InJail = inJail;
            Image = i;
        }
        public characters(double money, int iD, bool inJail, int position)
        {
            Money = money;
            ID = iD;
            Position = position;
            InJail = inJail;
        }

        public characters(double money, int iD, List<holdings> propiedades, bool inJail, int position)
        {
            Money = money;
            ID = iD;
            Position = position;
            Propiedades = propiedades;
            InJail = inJail;

        }

        public characters(double money, int iD, bool inJail, int position, string i)
        {
            Money = money;
            ID = iD;
            InJail = inJail;
            Position = position;
            Image = i;
        }

        public bool pagar(double precio, characters c)
        {
            Money = Money - precio;
            c.SetMoney(c.GetMoney() + precio);
            return true;
        }

        public bool trade(holdings h, characters c, holdings caracter, double oferta)
        {
            Propiedades.Remove(h);
            c.Propiedades.Remove(caracter);
            c.Propiedades.Add(h);
            Propiedades.Add(caracter);
            SetMoney(GetMoney() - oferta);
            c.SetMoney(c.GetMoney() + oferta);
            return true;
        }

        public bool bancarrota()
        {
            bool bancarrota = false;
            int contador = 0;

            if(Money == 0)
            {
                if(Propiedades.Count == 0)
                {
                    bancarrota = true;
                }
                else
                {
                    for (int i = 0; i < Propiedades.Count; i++)
                    {
                        if(Propiedades[i].getPrestamo() == true)
                        {
                            contador++;
                        }
                    }

                    if(Propiedades.Count == contador)
                    {
                        bancarrota = true;
                    }
                }
            }
            return bancarrota;
        }

        public bool pedirPrestamo(holdings h)
        {
            h.prestamo = true;
            Money = GetMoney() + (h.price / 2);
            return true;
        }

        public bool cancelarPrestamo(holdings h)
        {
            h.prestamo = false;
            Money = GetMoney() - (h.price / 2);
            return true;
        }

        public bool buy(double precio,holdings a)
        {
            Money = Money - precio;
            Propiedades.Add(a);
            return true;
        }

        public bool sell(double precio, holdings a)
        {
            if (Propiedades.Contains(a) == true)
            {
                Propiedades.Remove(a);
                Money = Money + precio;
                return true;
            } 
            else
            {
                return false;
            }
        }
        public bool jailed()
        {
            InJail = true;
            return true;
        }

        public bool free()
        {
            InJail = false;
            return true;
        }

        public void SetMoney(double i) 
        {
            Money = i;
        }
        public void SetPosition(int i) 
        {
            Position = i;
        }
        public void SetID(int i)
        {
            ID = i;
        }
        public int GetID()
        {
            return ID;
        }
        public List<holdings> GetHoldings()
        {
            return Propiedades;
        }
        public double GetMoney()
        {
            return Money;
        }
        public int GetPosition()
        {
            return Position;
        }
        public void setJail(bool i)
        {
            InJail = i;
        }
        public bool getJail()
        {
            return InJail;
        }
        public List<holdings> getHoldings()
        {
            return Propiedades;
        }
    }

}




