using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Entity;

namespace Library.Models
{
    public class Books
    {
        public List<Knjiga> list { get; set; }
        public Knjiga Book { get; set; }
        public List<SelectListItem> listZanrova { get; set; }

        public Books()
        {
            list = new List<Knjiga>();
            this.Book = new Knjiga(1);
        }

        public Books(int id)
        {
            this.Book = new Knjiga(id);
            list = new List<Knjiga>();
        }

        public Books(int id,string naziv,string autor,int id_zanr)
        {
            Book.ID_Knjige = id;
            Book.Naziv_Knjige = naziv;
            Book.Autor = autor;
            Book.ID_Zanr = id_zanr;
        }

        public void FillBooks()
        {
            DataSet ds = DAL.Books.GetAllBooks();

            for (int i = 0; i < ds.Tables["book"].Rows.Count; i++)
            {
                int id = (int)ds.Tables["book"].Rows[i]["ID_Knjige"];
                string naziv = ds.Tables["book"].Rows[i]["Naziv"].ToString();
                string autor = ds.Tables["book"].Rows[i]["Autor"].ToString();
                string zanr = ds.Tables["book"].Rows[i]["Zanr"].ToString();
                
                Knjiga b = new Knjiga(id,naziv,autor,zanr);

                list.Add(b);
            }
        }

        public void DeleteBook()
        {
            DAL.Books.DeleteBook(Book.ID_Knjige);
        }

        public void SaveBook()
        {
            DAL.Books.SaveBook(Book.ID_Knjige, Book.Naziv_Knjige, Book.Autor, Book.ID_Zanr);
        }



        public void loadBook()
        {
            DataSet ds = DAL.Books.getBookByID(this.Book.ID_Knjige);

            if (Book.ID_Knjige == 0)
            {

                Book.Naziv_Knjige = "";
                Book.Autor = "";
                Book.ID_Zanr = 1;

            }
            else
            {

                for (int i = 0; i < ds.Tables["book"].Rows.Count; i++)
                {

                    Book.Naziv_Knjige = ds.Tables["book"].Rows[i]["Naziv"].ToString();
                    Book.Autor = ds.Tables["book"].Rows[i]["Autor"].ToString();
                    Book.ID_Zanr = (int)ds.Tables["book"].Rows[i]["ID_Zanr"];

                }
            }

            listZanrova = new List<SelectListItem>();

            DataSet ds2 = DAL.Books.getAllZanrovi();
            foreach (DataRow row in ds2.Tables["zanr"].Rows)
            {             
                listZanrova.Add(new SelectListItem() { Value = row["ID_Zanr"].ToString(), Text = row["Zanr"].ToString(), Selected = row["ID_Zanr"].ToString() == Book.ID_Zanr.ToString() });
            }

        }

        public void getGenres()
        {
            Book.ID_Zanr = 0;

            listZanrova = new List<SelectListItem>();
            DataSet ds2 = DAL.Books.getAllZanrovi();
            foreach (DataRow row in ds2.Tables["zanr"].Rows)
            {
                listZanrova.Add(new SelectListItem() { Value = row["ID_Zanr"].ToString(), Text = row["Zanr"].ToString(), Selected = row["ID_Zanr"].ToString() == Book.ID_Zanr.ToString() });
            }
        }

    }
}