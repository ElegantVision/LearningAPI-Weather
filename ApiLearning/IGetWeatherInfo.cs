using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLearning
{
    interface IGetWeatherInfo
    {
        //For getting Api data
        string GetWeatherData(string uri);
    }
}
