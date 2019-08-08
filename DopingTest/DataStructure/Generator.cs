using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DopingTest.DataStructure
{
    public class Generator
    {

        private DataBaseAccess _dbAccess;

		public Generator()
        {
            _dbAccess = new DataBaseAccess();
        }

        /// <summary>
        /// Gibt die Liste aller Verbände zurück, von denen Teilnehmer anwesend sind
        /// </summary>
        /// <returns>Liste aller Verbände, anhand der Teilnehmer</returns>
        public List<string> GetListOfVerbände()
        {
            return _dbAccess.GetAllVb();
        }

        /// <summary>
        /// Wird verwendet, um nur einen Ringer pro Landesverband zu erhalten
        /// </summary>
        /// <param name="ringerListe">Liste aus der ein Ringer ausgewählt werden soll</param>
        /// <param name="rdm">Zufallsgenerator, durch den ein zufälliger index ermittelt wird</param>
        /// <returns>Ein zufällig ausgewählter Ringer</returns>
        private Ringer GetZufallsRinger(IEnumerable<Ringer> ringerListe, Random rdm)
        {
            var index = rdm.Next(ringerListe.Count());
            return ringerListe.ElementAt(index);
        }

        /// <summary>
        /// Erstellt die endgültige Liste die Angezeigt wird
        /// </summary>
        /// <param name="ringerListe"> Liste aus der die Ringer gewählt werden </param>
        /// <param name="rdm">Zufallsgenerator, durch den ein zufälliger index ermittelt wird</param>
        /// <param name="anzahl">Anzahl der Ringer die ausgewählt werden sollen</param>
        /// <returns>Zufallsliste mit einer definierten Anzahl an Ringern</returns>
        private List<Ringer> GetZufallsRinger(IEnumerable<Ringer> ringerListe, Random rdm, int anzahl)
        {
            var ringerRueckgabe = new List<Ringer>();
            var ausgangsRinger = ringerListe.ToList();

            for (int i = 0; i < anzahl; i++)
            {
                var ringer = GetZufallsRinger(ausgangsRinger, rdm);

                ringerRueckgabe.Add(ringer);
                ausgangsRinger.Remove(ringer);
            }

            return ringerRueckgabe;
        }

        /// <summary>
        /// Ruft alle Teilnehmer aus der Datenbank ab, mit den Properties Name, Gewichtsklasse und Verband
        /// </summary>
        /// <returns>Liste aller Teilnehmer aus der Datenbank, reduziert auf die benötigten Daten</returns>
        private List<Ringer> GetMembers()
        {
            return _dbAccess.GetSpecifiedMembers();
        }

        public List<Ringer> GenerateList(int numberOfTestMembers, string host)
        {
            var count = numberOfTestMembers;
            List<Ringer> memberTestList = new List<Ringer>();
            List<Ringer> allMembers = GetMembers();
            Random rnd = new Random();

            //Von jedem Landesverband einen Ringer auswählen
            var einzelRinger = allMembers.GroupBy(m => m.Verband).Select(gruppe => GetZufallsRinger(gruppe, rnd)).ToList();

            //Den ersten Ringer aus dem Anbieterlandesverband zur Liste hinzufügen
            var initialRinger = einzelRinger.Single(ringer => ringer.Verband == host);
            memberTestList.Add(initialRinger);

            //Den ersten Ringer aus der Liste aller Ringer entfernen
            einzelRinger.Remove(initialRinger);

            //Die restlichen Ringer hinzufügen
            memberTestList.AddRange(GetZufallsRinger(einzelRinger, rnd, count - 1));

            return memberTestList.ToList();
        }
    }
}
