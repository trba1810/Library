using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Knjiga
    {
        public int ID_Knjige;
        public string Naziv_Knjige;
        public string Zanr;
        public int ID_Zanr;

        public Knjiga()
        {

        }

        public Knjiga(int id, string naziv, string zanr, int id_z)
        {
            this.ID_Knjige = id;
            this.Naziv_Knjige = naziv;
            this.Zanr = zanr;
            this.ID_Zanr = id_z;
        }

        public Knjiga(int id)
        {
            this.ID_Knjige = id;
        }
    }
}
