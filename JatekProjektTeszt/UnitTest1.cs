using JatekProjekt;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
namespace JatekProjektTeszt
{
    [TestFixture]
    public class Tests
    {

        private KarakterElemzo elemzo;

        [SetUp]
        public void Setup()
        {
            // Példányosítjuk az elemzőt a helyi teszt adatbázis adataival
            // (Feltételezve, hogy a MySQL fut és a JatekDb benne van a 32 karakterrel)
            elemzo = new KarakterElemzo();
        }

        // ==========================================
        // 1. KÖNNYŰ SZŰRÉsek ÉS LISTÁZÁSOK TESZTJEI
        // ==========================================

        [Test]
        public void MagasSzintuKarakterek_VisszaadjaA70NelNagyobmakat()
        {
            var eredmeny = elemzo.MagasSzintuKarakterek();
            Assert.That(eredmeny, Is.Not.Empty);
            Assert.That(eredmeny, Does.Contain("Gandalf")); // 80-as szint
            Assert.That(eredmeny, Does.Not.Contain("Thorin")); // 45-ös szint
        }

        [Test]
        public void MagusOsztalyuNevek_CsakMagusokatAdVissza()
        {
            var eredmeny = elemzo.MagusOsztalyuNevek();
            Assert.That(eredmeny.Count, Is.EqualTo(8));
            Assert.That(eredmeny, Does.Contain("Gandalf"));
            Assert.That(eredmeny, Does.Not.Contain("Thorin"));
        }

        [Test]
        public void OsszesKarakterNevListaba_MindenNevetTartalmaz()
        {
            var eredmeny = elemzo.OsszesKarakterNevListaba();
            Assert.That(eredmeny.Count, Is.EqualTo(32));
            Assert.That(eredmeny, Does.Contain("Thorin"));
            Assert.That(eredmeny, Does.Contain("Morana"));
        }

        [Test]
        public void EuSzerveresKarakterek_CsakEuKaraktereketAdVissza()
        {
            var eredmeny = elemzo.EuSzerveresKarakterek();
            Assert.That(eredmeny, Is.Not.Empty);
            Assert.That(eredmeny, Does.Contain("Thorin")); // EU-Central
            Assert.That(eredmeny, Does.Contain("Shadowfax")); // EU-West
            Assert.That(eredmeny, Does.Not.Contain("Gandalf")); // US-East
        }

        [Test]
        public void EgyediSzerverNevek_CsakEgyediErtekeketAd()
        {
            var eredmeny = elemzo.EgyediSzerverNevek();
            // EU-Central, US-East, EU-West, Asia-East (összesen 4 különböző szerver van)
            Assert.That(eredmeny.Count, Is.EqualTo(4));
            Assert.That(eredmeny, Does.Contain("EU-Central"));
            Assert.That(eredmeny, Does.Contain("US-East"));
        }

        // ==========================================
        // 2. AGGREGÁCIÓK ÉS ELDÖNTÉSEK TESZTJEI
        // ==========================================

        [Test]
        public void OsszesAranyMennyiseg_HelyesenSzamol()
        {
            int osszeg = elemzo.OsszesAranyMennyiseg();
            Assert.That(osszeg, Is.GreaterThan(0));
            // A 32 karakter összes aranyának összege fixen több, mint 100 000
            Assert.That(osszeg, Is.GreaterThan(100000));
        }

        [Test]
        public void AtlagSzint_HelyesErtekkelTerVissza()
        {
            double atlag = elemzo.AtlagSzint();
            Assert.That(atlag, Is.GreaterThan(0));
            Assert.That(atlag, Is.LessThan(100));
        }

        [Test]
        public void VaneMagasSzintuTolvaj_IgazatAdHaVan()
        {
            bool van = elemzo.VaneMagasSzintuTolvaj();
            // Illidan (95-ös szintű Tolvaj) miatt True
            Assert.That(van, Is.True);
        }

        [Test]
        public void VanETizEzerAranynalTobb_IgazatAd()
        {
            bool van = elemzo.VanETizEzerAranynalTobb();
            // Elrond (20000 arany), Arthas (12000 arany) miatt True
            Assert.That(van, Is.True);
        }

        [Test]
        public void LegelsoOvenKarakter_NemNulltAdVissza()
        {
            var karakter = elemzo.LegelsoOvenKarakter();
            Assert.That(karakter, Is.Not.Null);
            Assert.That(karakter.Arany, Is.GreaterThan(5000));
        }

        // ==========================================
        // 3. RENDEZÉSEK ÉS KERESÉSEK TESZTJEI
        // ==========================================

        [Test]
        public void KarakterekSzintSzerintRendezve_CsokkenoSorrendetAd()
        {
            var lista = elemzo.KarakterekSzintSzerintRendezve();
            Assert.That(lista.First().Nev, Is.EqualTo("Elrond")); // 99-es szint
            Assert.That(lista.First().Szint, Is.EqualTo(99));
        }

        [Test]
        public void LeggazdagabbKarakterNeve_ElrondotAdVissza()
        {
            string nev = elemzo.LeggazdagabbKarakterNeve();
            Assert.That(nev, Is.EqualTo("Elrond")); // 20000 arany
        }

        [Test]
        public void LegszegenyebbKarakterNeve_BoranVagyMasKicsitAd()
        {
            string nev = elemzo.LegszegenyebbKarakterNeve();
            Assert.That(nev, Is.Not.Null);
            // Borannak van a legkevesebb aranya (150)
            Assert.That(nev, Is.EqualTo("Boran"));
        }

        [Test]
        public void LegmagasabbSzint_99etAdVissza()
        {
            int maxSzint = elemzo.LegmagasabbSzint();
            Assert.That(maxSzint, Is.EqualTo(99));
        }

        [Test]
        public void KarakterekNevHosszaSzerint_Rendezi()
        {
            var lista = elemzo.KarakterekNevHosszaSzerint();
            Assert.That(lista, Is.Not.Empty);
            // Ellenőrizzük, hogy az első elem neve rövidebb vagy egyenlő, mint a másodiké
            Assert.That(lista[0].Nev.Length, Is.LessThanOrEqualTo(lista[1].Nev.Length));
        }

        // ==========================================
        // 4. CSOPORTOSÍTÁS ÉS ÖSSZETETTEBB LINQ TESZTJEI
        // ==========================================

        [Test]
        public void OsztalyonkentKarakterSzam_DictionarytAdVissza()
        {
            var dictionary = elemzo.OsztalyonkentKarakterSzam();
            Assert.That(dictionary.ContainsKey("Harcos"), Is.True);
            Assert.That(dictionary.ContainsKey("Mágus"), Is.True);
            Assert.That(dictionary["Harcos"], Is.GreaterThan(0));
        }

        [Test]
        public void SzerverenKarakterekSzama_KitoltiADictot()
        {
            var dictionary = elemzo.SzerverenKarakterekSzama();
            Assert.That(dictionary.ContainsKey("EU-Central"), Is.True);
            Assert.That(dictionary["EU-Central"], Is.GreaterThan(0));
        }

        [Test]
        public void HarcosokAzonositoi_CsakHarcosokatAd()
        {
            var idLista = elemzo.HarcosokAzonositoi();
            Assert.That(idLista, Is.Not.Empty);
            // A Harcosok (Thorin-1, Arthas-5, Conan-8, stb.) ID-it tartalmazza
            Assert.That(idLista, Does.Contain(1));
            Assert.That(idLista, Does.Contain(5));
        }

        [Test]
        public void VanETolvajSpecKondicioval_VisszaadErteket()
        {
            bool eredmeny = elemzo.VanETolvajSpecKondicioval();
            // Van-e 50-nél magasabb Mágus, akinek 3000-nél kevesebb aranya van?
            // (Pl. Aria 40-es, Gandalf 5400 arany, Balthazar 55-ös de 2100 arany -> Balthazar teljesíti)
            Assert.That(eredmeny, Is.True);
        }

        [Test]
        public void LegmagasabbSzintuKarakterObjektum_ElrondotAd()
        {
            var karakter = elemzo.LegmagasabbSzintuKarakterObjektum();
            Assert.That(karakter, Is.Not.Null);
            Assert.That(karakter.Nev, Is.EqualTo("Elrond"));
            Assert.That(karakter.Szint, Is.EqualTo(99));
        }
    }
}

