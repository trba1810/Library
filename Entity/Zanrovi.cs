using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Zanrovi
    {
        private int IDZanra { get; set; }
        private string nazivZanra { get; set; }



        public Zanrovi(int idZanra, string nazivZanra)
        {
            this.IDZanra = idZanra;
            this.nazivZanra = nazivZanra;

        }
    }
}
