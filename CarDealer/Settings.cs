using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CarDealer
{
    public class Settings
    {
        private String _imagepaths = @"../../imageNames.json";
        private String _carspath = @"../../cars.json";
        
        private Dictionary<int, List<String>> _imagenames;
        private Dictionary<int, List<String>> _cars;
        
        private readonly StreamReader _imageReader;
        private readonly StreamReader _carsReader;
        private readonly StreamWriter _fileWriter;
        private readonly StreamWriter _carsWriter;

        public Settings()
        {
            _imageReader = new StreamReader(_imagepaths);
            _carsReader = new StreamReader(_carspath);
            
            String json = _imageReader.ReadToEnd();
            String cars = _carsReader.ReadToEnd();
            
            _imagenames =  JsonConvert.DeserializeObject<Dictionary<int, List<string>>>(json);
            _cars = JsonConvert.DeserializeObject<Dictionary<int, List<String>>>(cars);
            
            _imageReader.Close();
            _carsReader.Close();
        }

        public Dictionary<int, List<string>> Imagenames
        {
            get => _imagenames;
            set => _imagenames = value;
        }
        
        public Dictionary<int, List<string>> Cars
        {
            get => _cars;
            set => _cars = value;
        }
    }
}