using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
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


namespace ApiLearning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IGetWeatherInfo
    {
        /*
         * Order of submission UriOneLocation + NAMEQUERY + CityName + APIKEY
         */
        public string CityName = "Katy";
        const string APIKEY = "&appid=fake";//fake apikey
        const string NAMEQUERY = "?q=";
        const string UriOneLocation = "http://api.openweathermap.org/data/2.5/weather";


        public MainWindow()
        {
            InitializeComponent();
        }

        //sets up correct URL info to get data via api call
        private void btnWeatherData_Click(object sender, RoutedEventArgs e)
        {
            string CompletedURL = WeatherDataRetrived.URLBuild(CityName, UriOneLocation, NAMEQUERY, APIKEY);
            WeatherDataRetrived wInfo = JsonConvert.DeserializeObject<WeatherDataRetrived>(GetWeatherData(CompletedURL));

            //Testing
            WeatherDataBox.Text = wInfo.name;
            WeatherDataBox.Text += "\n" + wInfo.main.temp;
            WeatherDataBox.Text += "\n" + wInfo.wind.speed;

            #region TestingTotalAmountOfPropertiesClassHas
            //using reflection and linq to check retrived data (wi = WeatherInfo)
            var dataobtained = from wi in Assembly.GetExecutingAssembly().GetTypes()
                               where wi.GetCustomAttributes().Any( a => a is WDRetrivedAttribute)
                               select wi;
                               

            foreach(Type WData in dataobtained)
            {//scaning each item for all properties
                foreach (var props in WData.GetProperties())
                {
                    Debug.WriteLine(props.Name);
                }
                
            }
            #endregion

        }

        public string GetWeatherData(string uri)
        {//established http request and response. then return the string value
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
