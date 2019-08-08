using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DopingTest.DataStructure
{

    /// <summary>
    /// Ruft alle Verbände ab, die Teilnehmer in den Wettkampf schicken
    /// </summary>
    /// <returns>Liste aller Verbände, anhand der Teilnehmer</returns>
    public class DataBaseAccess
    {
        public List<string> GetAllVb()
        {
            List<string> AllVerbände = new List<string>();
            var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["RingerDB"].ConnectionString);
            connection.Open();

            OleDbCommand command;
            OleDbDataReader reader;

            var sql = "SELECT DISTINCT Verbandsname " +
                      "FROM Verbände " +
                      "INNER JOIN Teilnehmer " +
                      "ON Teilnehmer.Verband = Verbände.LandesVerband "; ;

            command = new OleDbCommand(sql, connection);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                AllVerbände.Add(reader.GetValue(0).ToString());
            }

            reader.Close();
            connection.Close();

            return AllVerbände;
        }

        /// <summary>
        /// Ruft alle Teilnehmer aus der Datenbank ab, mit den Properties Name, Gewichtsklasse und Verband
        /// </summary>
        /// <returns>Liste aller Teilnehmer aus der Datenbank, reduziert auf die benötigten Daten</returns>
        public List<Ringer> GetSpecifiedMembers()
        {
            List<Ringer> AllRingers = new List<Ringer>();
            var connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["RingerDB"].ConnectionString);
            connection.Open();

            OleDbCommand command;
            OleDbDataReader reader;

            var sql = "SELECT Teilnehmer.Name, Altersklassen.AKlassenName, Verbände.Verbandsname " +
                      "FROM (Teilnehmer " +
                      "INNER JOIN Altersklassen " +
                      "ON Teilnehmer.AKlassenID = Altersklassen.AKlassenID) " +
                      "INNER JOIN Verbände " +
                      "ON Teilnehmer.Verband = Verbände.LandesVerband ";

            command = new OleDbCommand(sql, connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                AllRingers.Add(new Ringer
                {
                    Name = reader.GetValue(0).ToString(),
                    Gewichtsklasse = reader.GetValue(1).ToString(),
                    Verband = reader.GetValue(2).ToString()
                });
            }

            reader.Close();
            connection.Close();

            return AllRingers;
        }
    }
}
