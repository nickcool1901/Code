using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AliExpressSearchApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SearchOnAliExpress(string productName, int minPrice, int maxPrice)
        {
            var options = new ChromeOptions();
            options.BinaryLocation = @"C:\Users\Nikita\Desktop\Automatizets\chrome-win64\chrome.exe"; // Norādām pareizo Chrome versiju
            options.AddExcludedArgument("enable-logging");

            // Pievienojam arguments ChromeDriver iestatīšanai
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = @"C:\Users\Nikita\Desktop\Automatizets\chromedriver-win64\chromedriver.exe", // ChromeDriver ceļš
                WindowStyle = ProcessWindowStyle.Hidden,  // Slēpj komandrindas logu
                Arguments = "--silent",  // Atslēdz ziņojumus
            };

            Process.Start(startInfo);  // Palaiž ChromeDriver bez komandrindas loga

            IWebDriver driver = new ChromeDriver(@"C:\Users\Nikita\Desktop\Automatizets\chromedriver-win64", options);
            driver.Navigate().GoToUrl($"https://www.aliexpress.com/wholesale?SearchText={productName}&minPrice={minPrice}&maxPrice={maxPrice}");

            // Atvērtu pārlūkprogrammu ar meklēšanas rezultātiem
        }

        private void OkButton_Click_1(object sender, EventArgs e)
        {
            string productName = productNameTextBox.Text;
            int minPrice = int.Parse(minPriceTextBox.Text);
            int maxPrice = int.Parse(maxPriceTextBox.Text);

            SearchOnAliExpress(productName, minPrice, maxPrice);
        }
    }
}
