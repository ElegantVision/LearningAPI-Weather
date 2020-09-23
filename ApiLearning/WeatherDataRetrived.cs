using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLearning
{
    [WDRetrived]
    class WeatherDataRetrived
    {
        //building properties for deserializing json via newtonsoft.json
        public List<Weatherinfo> weather { get; set; }
        public string name { get; set; }
        public MainTemps main { get; set; }
        public WindInfo wind { get; set; }

        //Able to retrive Id and base info of weather
        public class Weatherinfo
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        //Able to retrive Tempertures
        public class MainTemps
        {
            public float temp { get; set; }
            public float feels_like { get; set; }
            public float temp_min { get; set; }
            public float temp_max { get; set; }
            public float pressure { get; set; }
            public float humidity { get; set; }
        }

        //Wind Information
        public class WindInfo
        {
            public float speed { get; set; }
            public float deg { get; set; }
            public float gust { get; set; }
        }


        /// <summary>
        /// Put the Uri together into a valid URL Address
        /// </summary>
        /// <param name="_CityName"></param>
        /// <param name="_API_KEY"></param>
        /// <returns></returns>
        public static string URLBuild(string _CityName, string _UriOneLocation, string _NAMEQUERY, string _APIKEY)
        {
            //Building the new URL Address
            StringBuilder BuiltURL = new StringBuilder(_UriOneLocation + _NAMEQUERY + _CityName + _APIKEY);

            //building new URL address and returning it's value as string
            return BuiltURL.ToString();

        }
    }


    

    [AttributeUsage(AttributeTargets.Class)]
    class WDRetrivedAttribute : Attribute
    {

    }
}
