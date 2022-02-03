using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Nasdaq_Alpha_v0._01
{
    class Cartas
    {
        #region Campos y Propiedades
        public string descripcion { get; set; }
        public string tipo { get; set; }
        public int posicion { get; set; }
        public double dinero { get; set; }
        #endregion

        #region Constructores

        public Cartas()
        {
            this.descripcion = string.Empty;
            this.tipo = string.Empty;
            this.posicion = 0;
            this.dinero = 0;
        }

        public Cartas(string descripcion, string tipo, int posicion, double dinero)
        {
            this.descripcion = descripcion;
            this.tipo = tipo;
            this.posicion = posicion;
            this.dinero = dinero;
        }
        public Cartas(Cartas c)
        {
            this.descripcion = c.descripcion;
            this.tipo = c.tipo;
            this.posicion = c.posicion;
            this.dinero = c.dinero;
        }

        public override string ToString()
        {
            return descripcion + "," + tipo + "," + posicion.ToString() + "," +dinero.ToString();
        }

        public Cartas(string linea)
        {
            String[] campos;
            campos = linea.Split(',');
            descripcion = campos[0];
            tipo = campos[1];
            posicion = int.Parse(campos[2]);
            dinero = double.Parse(campos[2]);
        }
        #endregion
    }
}
