using DopingTest.DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DopingTest
{
    public partial class MainWindow : Form
    {

        private Generator generator;

        public MainWindow()
        {
            InitializeComponent();
            ConfigureComponents();            
        }

        /// <summary>
        /// Setzt die Grenzen für die Anzahl der Tests
        /// Füllt das DropDown
        /// usw.
        /// </summary>
        private void ConfigureComponents()
        {
            generator = new Generator();
            ListOfVerbände.DataSource = generator.GetListOfVerbände();
            numberOfTestMembers.Maximum = generator.GetListOfVerbände().Count-1;
            numberOfTestMembers.Minimum = 1;
            ListOfVerbände.SelectedIndex = 11; /// Bisher Südbaden 
            dopingTestList.ReadOnly = true;
        }             

        /// <summary>
        /// Zeigt einen zufällige Ringer pro Landesverband an
        /// </summary>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Liste anzeigen
            dopingTestList.DataSource = generator.GenerateList((int)numberOfTestMembers.Value, ListOfVerbände.SelectedItem.ToString());
        }
        
    }
}
