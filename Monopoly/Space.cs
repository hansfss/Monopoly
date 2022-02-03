using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Nasdaq_Alpha_v0._01
{
     class Space
    {
        int price;
        string name;
        Color color = new Color();
        Axis axis = new Axis();
        int position;
        string image;
        public Space(Color e, int x,int y,int z,int p ,int d, int s, string i, string n)
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

        public Space(Color e, int x, int y, int z, int s, int p, int d, string n)
        {
            this.color = e;
            this.price = d;
            this.position = p;
            this.axis.x = x;
            this.axis.y = y;
            this.axis.z = z;
            this.axis.s = s;
            this.name = n;
        }
        //hacer mas constructores.
    }
}
