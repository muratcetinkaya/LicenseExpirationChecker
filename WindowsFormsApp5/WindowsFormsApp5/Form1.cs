using System;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        private DateTime expirationDate = new DateTime(2024, 01, 03); // yy-dd-mm

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime turkeyTime = await WorldTimeApi.GetCurrentDateTimeAsync("Europe/Istanbul");

                // Türkiye'nin saatini gösterme
                MessageBox.Show($"Türkiye's time: {turkeyTime}"+ $"expirationDate: {expirationDate}");
       

                // Belirli bir tarihten sonra olduğunu kontrol et
                if (turkeyTime > expirationDate)
                {
                    MessageBox.Show("Expired! The program will close.");
                    this.Close(); // Programı kapat
                }
                else
                {
                    MessageBox.Show("License continues");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"fail: {ex.Message}");
                this.Close(); // Programı kapat

            }
        }
    }
}
