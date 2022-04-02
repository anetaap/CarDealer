using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CarDealer
{
    public class Settings
    {
        private Dictionary<int, List<String>> _imagenames;
        private String _jsonpath = @"../../imageNames.json";
        
        private StreamReader _fileReader;
        private StreamWriter _fileWriter;

        public Settings()
        {
            _fileReader = new StreamReader(_jsonpath);
            String json = _fileReader.ReadToEnd();
            _imagenames =  JsonConvert.DeserializeObject<Dictionary<int, List<string>>>(json);
            
            _fileReader.Close();
        }

        public Dictionary<int, List<string>> Imagenames
        {
            get => _imagenames;
            set => _imagenames = value;
        }
    }
}