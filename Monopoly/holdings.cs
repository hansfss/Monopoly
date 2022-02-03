using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Nasdaq_Alpha_v0._01
{
    class holdings
    {
        public double pricebase;
        public int level;
        public double price;
        public bool canBuy;
        public bool prestamo;
        public int owner;
        public string name;
        public Color color = new Color();
        public Axis axis = new Axis();
        public int position;
        public string image;

        public holdings()
        {
            this.pricebase = 0;
            this.level = 1;
            this.price = 0;
            this.canBuy = true;
            this.prestamo = false;
            this.owner = 0;
            this.name = "";
            this.color = Color.Blue;
            this.axis.x = 0;
            this.axis.y = 0;
            this.axis.z = 0;
            this.axis.s = 0;
            this.position = 0;
            this.image = "";
        }

        public holdings(Color e, int x, int y, int z, int p, int d, int s, string i, string n)
        {
            this.color = e;
            this.price = d;
            this.position = p;
            this.axis.x = x;
            this.axis.y = y;
            this.axis.z = z;
            this.axis.s = s;
            this.image = i;
            this.name = n;
        }

        public holdings(Color e, int x, int y, int z, int s, int p, int d, string n, int l)
        {
            this.color = e;
            this.price = d;
            this.position = p;
            this.axis.x = x;
            this.axis.y = y;
            this.axis.z = z;
            this.axis.s = s;
            this.name = n;
            this.level = l;
        }

        public holdings(Color e, bool buy, bool prestamo, int x, int y, int z, int s, int p, int d, string n, int l)
        {
            this.color = e;
            this.canBuy = buy;
            this.prestamo = prestamo;
            this.price = d;
            this.position = p;
            this.axis.x = x;
            this.axis.y = y;
            this.axis.z = z;
            this.axis.s = s;
            this.name = n;
            this.level = l;
        }

        public bool LevelUp ()
        {
            level++;
            double i = price * 0.25;
            price = price + i;
            return true;
        }

       public bool LevelDown()
       {
            level--;
            double i = price * 0.2;
            price = price - i;
            return true;
       }

       public void setOwner(int _owner)
       {
           owner = _owner;
       }
       public int getOwner()
       {
           return owner;
       }
       public double getPrice()
       {
           return price;
       }
       public string getName()
       {
           return name;
       }
       public Color getColor()
       {
           return color;
       }
       public bool getPrestamo()
       {
            return prestamo;
       }
    }
}
