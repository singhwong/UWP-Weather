using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using static UsefulWeather.City;

namespace UsefulWeather
{
    class weatherAPI
    {
        public async static Task<RootObject> GetWeatherByLocation(double lat,double lon)
        {
            var http = new HttpClient();
            var uri = String.Format("http://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&appid=733d2c527b09b615dc30f6059bf4ac64&units=metric", lat,lon);
            var response = await http.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var memroryStream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(memroryStream);
            return data;
        }

        public async static Task<RootObject> GetWeatherByCityName(string cityname)
        {
            var http = new HttpClient();
            var uri = String.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&appid=733d2c527b09b615dc30f6059bf4ac64&units=metric", cityname);
            var response = await http.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var memroryStream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(memroryStream);
            return data;
        }
    }
    [DataContract]
    public class Main
    {
        [DataMember]
        private double _temp;
        [DataMember]
        public double temp
        {
            get { return this._temp; }
            set
            {
                this._temp = value;
                this.NotifyPropertyChanged("temp");
            }
        }
        [DataMember]
        public double temp_min { get; set; }
        [DataMember]
        public double temp_max { get; set; }
        [DataMember]
        public double grnd_level { get; set; }
        [DataMember]
        public int humidity { get; set; }
        [DataMember]
        public double temp_kf { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null)

            {
                temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    [DataContract]
    public class Weather
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string main { get; set; }
        [DataMember]
        public string _description;
        [DataMember]
        public string description
        {
            get { return this._description; }
            set
            {
                this._description = value;
                this.NotifyPropertyChanged("description");
            }
        }
        [DataMember]
        private string _icon;
        [DataMember]
        public string icon
        {
            get { return this._icon; }
            set
            {
                this._icon = value;
                this.NotifyPropertyChanged("icon");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    [DataContract]
    public class Clouds
    {
        [DataMember]
        public int all { get; set; }
    }
    [DataContract]
    public class Wind
    {
        [DataMember]
        public double speed { get; set; }
        [DataMember]
        public double deg { get; set; }
    }
    [DataContract]
    public class Sys
    {
        [DataMember]
        public string pod { get; set; }

    }

    [DataContract]
    public class List
    {
        [DataMember]
        public int dt { get; set; }
        [DataMember]
        private Main _main;
        [DataMember]
        public Main main
        {
            get { return this._main; }
            set
            {
                this._main = value;
                main.PropertyChanged += AddressChanged;
                this.NotifyPropertyChanged("main");
            }
        }
        [DataMember]
        private List<Weather> _weather;
        [DataMember]
        public List<Weather> weather
        {
            get { return this._weather; }
            set
            {
                this._weather = value;
                weather[0].PropertyChanged += AddressChanged;
                this.NotifyPropertyChanged("weather");
            }
        }
        [DataMember]
        public Clouds clouds { get; set; }
        [DataMember]
        public Wind wind { get; set; }
        [DataMember]
        public Sys sys { get; set; }
        [DataMember]
        private string _dt_txt;
        [DataMember]
        public string dt_txt
        {
            get { return this._dt_txt; }
            set
            {
                this._dt_txt = value;
                this.NotifyPropertyChanged("dt_txt");
            }
        }
        private void AddressChanged(object sender, PropertyChangedEventArgs args)
        {
            NotifyPropertyChanged("main");
            NotifyPropertyChanged("weather");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    [DataContract]
    public class Coord
    {
        [DataMember]
        public double lat { get; set; }
        [DataMember]
        public double lon { get; set; }
    }
    [DataContract]
    public class City
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        private string _name;
        [DataMember]
        public string name
        {
            get { return this._name; }
            set
            {
                this._name = value;
                this.NotifyPropertyChanged("name");
            }
        }
        [DataMember]
        public Coord coord { get; set; }
        [DataMember]
        public string country { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        [DataContract]
        public class RootObject
        {
            [DataMember]
            public string cod { get; set; }
            [DataMember]
            public double message { get; set; }
            [DataMember]
            public int cnt { get; set; }
            [DataMember]
            private List<List> _list;
            [DataMember]
            public List<List> list
            {
                get { return this._list; }
                set
                {
                    _list = value;
                    //getting data which will be printed inside of the list
                    for (int i = 0; i < 17; i += 4)
                    {
                        _list[i].PropertyChanged += AddressChanged;
                    }
                    NotifyPropertyChanged("list");
                }
            }
            [DataMember]
            private City _city;
            [DataMember]
            public City city
            {
                get { return this._city; }
                set
                {
                    _city = value;
                    _city.PropertyChanged += AddressChanged;
                    NotifyPropertyChanged("city");
                }
            }
            private void AddressChanged(object sender, PropertyChangedEventArgs args)
            {
                NotifyPropertyChanged("city");
                NotifyPropertyChanged("list");
            }
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(String propertyName)
            {
                PropertyChangedEventHandler temp = PropertyChanged;
                if (temp != null)
                {
                    temp(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}
