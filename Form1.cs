using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;



namespace RozmiarPliku
{
    public partial class Informacja : Form
    {
        public Informacja()
        {
            InitializeComponent();
        }

        private void Informacja_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Email();
            Application.Exit();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        static void Email()
        {
            StreamReader sr = new StreamReader("C:\\folder z plikiem cfg\\config.ini");   // Odczyt lokalizacji pliku bazy oraz adresu email z pliku lokalnego "konfig.ini"
            string baza = sr.ReadLine();
            string adres = sr.ReadLine();

            sr.Close();                                         // zamknięcie pliku.

            // obsługa wysyłki wiadomości email
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Nazwa konta", "adres@email"));
            message.To.Add(MailboxAddress.Parse(adres));
            message.Subject = "Tytuł wiadomości email ";
            message.Body = new TextPart("Plain")
            {
                Text = @"Plik danych przekroczył ostrzegawczy rozmiar, lokalizacja: " + baza
            };
            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect("domena serwera", 587, MailKit.Security.SecureSocketOptions.None);
                client.Authenticate("adres@eamil", "password");
                client.Send(message);

                MessageBox.Show("Email Wysłany!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

    }
}