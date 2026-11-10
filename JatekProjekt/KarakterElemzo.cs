using JatekProjekt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JatekProjekt
{

    public class KarakterElemzo
    {
        private List<Karakter> karakterek;

        // Konstruktor: példányosítja az adatbázis-kezelőt és betölti az adatokat a listába
        public KarakterElemzo()
        {
            var dbKezelo = new AdatbazisKezelo();
            this.karakterek = dbKezelo.AdatokBetoltese();
        }

        public List<string> MagasSzintuKarakterek()
        {
            return karakterek.Where(k => k.Szint > 70).Select(k => k.Nev).ToList();
        }

        public List<string> MagusOsztalyuNevek()
        {
            return karakterek.Where(k => k.Osztaly == "Mágus").Select(k => k.Nev).ToList();
        }

        public List<string> OsszesKarakterNevListaba()
        {
            return karakterek.Select(k => k.Nev).ToList();
        }

        public List<string> EuSzerveresKarakterek()
        {
            return karakterek.Where(k => k.Szerver.StartsWith("EU-")).Select(k => k.Nev).ToList();
        }

        public List<string> EgyediSzerverNevek()
        {
            return karakterek.Select(k => k.Szerver).Distinct().ToList();
        }


        // ==========================================
        // 2. EGYSZERŰ AGGREGÁCIÓK ÉS ELDÖNTÉsek
        // ==========================================

        // Számold meg Sum segítségével, hogy mennyi a karakterek összes aranya a szerveren!
        public int OsszesAranyMennyiseg()
        {
            return karakterek.Sum(k => k.Arany);
        }

        public double AtlagSzint()
        {
            return karakterek.Average(k => k.Szint);
        }

        public bool VaneMagasSzintuTolvaj()
        {
            return karakterek.Any(k => k.Osztaly == "Tolvaj" && k.Szint >= 40);
        }

        public bool VanETizEzerAranynalTobb()
        {
            return karakterek.Any(k => k.Arany > 10000);
        }

        public Karakter LegelsoOvenKarakter()
        {
            return karakterek.FirstOrDefault(k => k.Arany > 5000);
        }


        // ==========================================
        // 3. RENDEZÉsek ÉS KERESÉsek
        // ==========================================

        // Add vissza az összes karaktert szint szerint csökkenő, azon belül pedig név szerint növekvő sorrendbe rendezve!
        public List<Karakter> KarakterekSzintSzerintRendezve()
        {
            return karakterek.OrderByDescending(k => k.Szint).ThenBy(k => k.Nev).ToList();
        }

        public string LeggazdagabbKarakterNeve()
        {
            return karakterek.OrderByDescending(k => k.Arany).FirstOrDefault()?.Nev;
        }

        public string LegszegenyebbKarakterNeve()
        {
            return karakterek.OrderBy(k => k.Arany).FirstOrDefault()?.Nev;
        }

        public int LegmagasabbSzint()
        {
            return karakterek.Max(k => k.Szint);
        }

        public List<Karakter> KarakterekNevHosszaSzerint()
        {
            return karakterek.OrderBy(k => k.Nev.Length).ToList();
        }


        // ==========================================
        // 4. CSOPORTOSÍTÁS ÉS ÖSSzetettebb LINQ MŰVELETek
        // ==========================================

        // Csoportosítsd a karaktereket az Osztaly tulajdonságuk alapján, és alakítsd át ToDictionary-vel úgy, hogy a kulcs az osztály neve, az érték pedig a karakterek darabszáma legyen!
        public Dictionary<string, int> OsztalyonkentKarakterSzam()
        {
            throw new NotImplementedException();
        }

        // Csoportosítsd a karaktereket a Szerver tulajdonságuk alapján, és számold meg, hány karakter játszik az egyes szervereken!
        public Dictionary<string, int> SzerverenKarakterekSzama()
        {
            throw new NotImplementedException();
        }

        // Gyűjtsd ki az összes "Harcos" osztályú karakter azonosítóját (Id) egy listába!
        public List<int> HarcosokAzonositoi()
        {
            throw new NotImplementedException();
        }

        // Állapítsd meg, hogy van-e olyan 50-es szintnél magasabb Mágus, akinek 3000-nél kevesebb aranya van!
        public bool VanETolvajSpecKondicioval()
        {
            throw new NotImplementedException();
        }

        // Keresd meg és add vissza a legmagasabb szintű karakter objektumát!
        public Karakter LegmagasabbSzintuKarakterObjektum()
        {
            throw new NotImplementedException();
        }

    }
}