using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Knjiga
    {
        public int ID_Knjige { get; set; }
        public string Naziv_Knjige { get; set; }
        public string Autor { get; set; }
        public string Zanr { get; set; }
        public int ID_Zanr { get; set; }

        public Knjiga()
        {

        }

        public Knjiga(int id, string naziv, string autor, string zanr, int id_z)
        {
            this.ID_Knjige = id;
            this.Naziv_Knjige = naziv;
            this.Autor = autor;
            this.Zanr = zanr;
            this.ID_Zanr = id_z;
        }

        public Knjiga(int id, string naziv, string autor, int id_z)
        {
            this.ID_Knjige = id;
            this.Naziv_Knjige = naziv;
            this.Autor = autor;
            this.ID_Zanr = id_z;
        }

        public Knjiga(int id, string naziv, string autor, string zanr)
        {
            this.ID_Knjige = id;
            this.Naziv_Knjige = naziv;
            this.Autor = autor;
            this.Zanr = zanr;
        }

        public Knjiga(int id)
        {
            this.ID_Knjige = id;
        }
    }
}
