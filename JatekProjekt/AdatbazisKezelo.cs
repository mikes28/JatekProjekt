using MySql.Data.MySqlClient;

namespace JatekProjekt
{

    public class AdatbazisKezelo
    {
        private readonly string connectionString;

        public AdatbazisKezelo()
        {
            this.connectionString = "Server=localhost;Port=22650;Database=JatekDb;Uid=root;Pwd=root;";
        }

        public List<Karakter> AdatokBetoltese()
        {
            var karakterek = new List<Karakter>();

            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT `Id`, `Nev`, `Osztaly`, `Szint`, `Arany`, `Szerver` FROM `Karakterek`";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                karakterek.Add(new Karakter(
                    reader.GetInt32("Id"),
                    reader.GetString("Nev"),
                    reader.GetString("Osztaly"),
                    reader.GetInt32("Szint"),
                    reader.GetInt32("Arany"),
                    reader.GetString("Szerver")
                ));
            }

            return karakterek;
        }
    }
}
