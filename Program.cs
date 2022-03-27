using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RozmiarPliku
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Oblicz();
        }

        static void Oblicz()            // funkcja pobiera lokalizację do pliku bazy danych i bada rozmiar.
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\sciezka do pliku z cfg\\config.ini"); // Odczyt pliku bazy oraz adresu email z pliku lokalnego "config.ini"
                string sciezka = sr.ReadLine();

                sr.Close();

                string filename = sciezka;
                FileInfo fi = new FileInfo(filename);

                // sprawdzenie rozmiaru pliku, i przeliczenie do wykonania warunku.
                long size = fi.Length;
                if ((size / 1073741824.0) > 1.6)
                {
                     Application.Run(new Informacja());
                }
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}