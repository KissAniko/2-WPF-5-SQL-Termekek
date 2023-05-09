using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2_WPF_5_SQL_Termekek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Termek> termekek = new List<Termek>(); 
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        private void btnBetolt_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection adatbazisKapcsolat = new MySqlConnection(
                "Server = 127.0.0.1; Port = 3306; Database = hardver; User = root; Password =");
            adatbazisKapcsolat.Open();

            // Listázza ki abc szerint azoknak a gyártóknak a nevét, akiknek van olyan termékük,
            // mint amit a felhasználó bekér. (kategória --> termék --> pl egér)...
            // annak darabszámát, legmagasabb árát és átlagárát a termékek táblából.

            string SQLSelect = " SELECT Gyártó, " +
                               " COUNT(*) as darabSzám, " +
                               " MAX(Ár) as maxÁr, " +
                               " AVG(Ár) as átlagÁr " +
                               " FROM termékek " +
                              $" WHERE kategória = '{txtKategoria.Text}'" +
                               " GROUP BY Gyártó;";

            MySqlCommand SQLParancs = new MySqlCommand(SQLSelect, adatbazisKapcsolat);
            MySqlDataReader reader= SQLParancs.ExecuteReader();

            while (reader.Read()) 
            {                              
                Termek ujsor = new Termek (reader.GetString("Gyártó"),      // objektumlista
                                           reader.GetInt32("darabSzám"),
                                           reader.GetDouble("maxár"),
                                           reader.GetDouble("átlagÁr")
                                           );
                termekek.Add(ujsor);
            }
            reader.Close();
            adatbazisKapcsolat.Close();
            dgtermekek.ItemsSource = termekek; // Itt kapcsolódik össze a DataGrid az objektum listával
                    
        }
                  
            private void btnTorles_Click(object sender, RoutedEventArgs e)
            {
            if (dgtermekek.Items.Count == 0)
            MessageBox.Show("Nincs törlendő lista!");
            /* else
            dgtermekek.Items.Clear(); */                          
                                                                 
        }
    }
         
}

/* MEGJEGYZÉS:   - Kivételkezelések: Ha nincs olyan kategória, amit bekér a felhasználó.
                 - A törlés gomb használata vagy a kategória törlése után beírható és újra kiíratható anélkül, hogy
                   újratöltenénk az oldalt. 
                 - ComboBox... */