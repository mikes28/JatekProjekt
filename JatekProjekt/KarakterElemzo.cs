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
            throw new NotImplementedException();
        }

        // Számítsd ki Average segítségével a karakterek átlagos szintjét double értékként!
        public double AtlagSzint()
        {
            throw new NotImplementedException();
        }

        // Állapítsd meg Any segítségével, hogy van-e olyan "Tolvaj" osztályú karakter, akinek a szintje eléri vagy meghaladja a 40-et!
        public bool VaneMagasSzintuTolvaj()
        {
            throw new NotImplementedException();
        }

        // Ellenőrizd Any segítségével, hogy létezik-e olyan karakter, akinek 10 000 aranynál több van a zsebében!
        public bool VanETizEzerAranynalTobb()
        {
            throw new NotImplementedException();
        }

        // Keresd meg FirstOrDefault segítségével az első olyan karaktert, akinek az aranya meghaladja az 5000-et!
        public Karakter LegelsoOvenKarakter()
        {
            throw new NotImplementedException();
        }


        // ==========================================
        // 3. RENDEZÉsek ÉS KERESÉsek
        // ==========================================

        // Add vissza az összes karaktert szint szerint csökkenő, azon belül pedig név szerint növekvő sorrendbe rendezve!
        public List<Karakter> KarakterekSzintSzerintRendezve()
        {
            throw new NotImplementedException();
        }

        // Keresd meg OrderByDescending és FirstOrDefault segítségével annak a karakternek a nevét, akinek a legtöbb aranya van!
        public string LeggazdagabbKarakterNeve()
        {
            throw new NotImplementedException();
        }

        // Keresd meg OrderBy és FirstOrDefault segítségével a legszegényebb (legkevesebb aranyú) karakter nevét!
        public string LegszegenyebbKarakterNeve()
        {
            throw new NotImplementedException();
        }

        // Keresd meg Max segítségével a legmagasabb szintű karakter szintjét!
        public int LegmagasabbSzint()
        {
            throw new NotImplementedException();
        }

        // Rendezd a karaktereket a nevük hossza szerint növekvő sorrendbe!
        public List<Karakter> KarakterekNevHosszaSzerint()
        {
            throw new NotImplementedException();
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