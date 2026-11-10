using System;
using System.Collections.Generic;
using System.Text;

namespace JatekProjekt
{


    public class Karakter
    {

        private int id;
        private string nev;
        private string osztaly;
        private int szint;
        private int arany;
        private string szerver;

        public Karakter(int id, string nev, string osztaly, int szint, int arany, string szerver)
        {
            this.id = id;
            this.nev = nev;
            this.osztaly = osztaly;
            this.szint = szint;
            this.arany = arany;
            this.szerver = szerver;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Nev
        {
            get => nev;
            set => nev = value;
        }

        public string Osztaly
        {
            get => osztaly;
            set => osztaly = value;
        }

        public int Szint
        {
            get => szint;
            set => szint = value;
        }

        public int Arany
        {
            get => arany;
            set => arany = value;
        }

        public string Szerver
        {
            get => szerver;
            set => szerver = value;
        }


        public override string ToString()
        {
            return $"{Nev} [{Osztaly}] - Szint: {Szint} | Arany: {Arany} | Szerver: {Szerver}";
        }
    }
}