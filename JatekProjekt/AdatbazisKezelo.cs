using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JatekProjekt
{

    public class AdatbazisKezelo
    {
        private readonly string connectionString;


        public AdatbazisKezelo()
        {

            this.connectionString = "";// Irjuk meg a connectionstringet a megfelelő adatbázisra hivatkozva
        }

   
        /// Beolvassa az összes karaktert az adatbázisból egy List<Karakter>-be.
       
        public List<Karakter> AdatokBetoltese()
        {
            var karakterek = new List<Karakter>();
            
            return karakterek;
        }
    }
}
