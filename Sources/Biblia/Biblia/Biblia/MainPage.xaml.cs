using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Biblia
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void NovoV(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://bible-api.com/?random=verse&translation=almeida";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject data = JObject.Parse(responseBody);

                    string bookname = (string)data["verses"][0]["book_name"];
                    Nome.Text = $"{bookname}";
                    double capitu = (double)data["verses"][0]["chapter"];
                    Capitulo.Text = $"{capitu}";
                    double verse = (double)data["verses"][0]["verse"];
                    Versiculo.Text = $"{verse}";

                    string text = (string)data["verses"][0]["text"];
                    texto.Text = $"{text}";

                }
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            using (HttpClient client = new HttpClient())
            {
                string url = "https://bible-api.com/?random=verse&translation=almeida";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject data = JObject.Parse(responseBody);

                    string bookname = (string)data["verses"][0]["book_name"];
                    Nome.Text = $"{bookname}"; 
                    double capitu = (double)data["verses"][0]["chapter"];
                    Capitulo.Text = $"{capitu}";
                    double verse = (double)data["verses"][0]["verse"];
                    Versiculo.Text = $"{verse}";

                    string text = (string)data["verses"][0]["text"];
                    texto.Text = $"{text}";

                }
            }
        }

        private void OpenWebsite(object sender, EventArgs e)
        {
            
            string siteUrl = "https://www.bibliaon.com/";

            
            Device.OpenUri(new Uri(siteUrl));
        }

    }
}

