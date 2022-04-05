using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CarDealer
{
    public class Settings
    {
        private String _imagePaths = @"../../imageNames.json";
        private String _carsPath = @"../../cars.json";
        
        private Dictionary<int, List<String>> _imageNames;
        private Dictionary<int, List<String>> _cars;

        private StreamWriter _imageWriter;
        private StreamWriter _carsWriter;

        private StreamReader _imageReader;
        private StreamReader _carsReader;

        public Settings()
        {
            ImageNamesFromJson();
            CarsFromJson();
        }
        
        public void ImageNamesToJson()
        {
            _imageWriter= new StreamWriter(_imagePaths);
            
            String newImageNames = JsonConvert.SerializeObject(_imageNames);
            _imageWriter.Write(newImageNames);
            
            _imageWriter.Close();
        }
        public void CarsToJson()
        {
            _carsWriter= new StreamWriter(_carsPath);
            
            String newCars = JsonConvert.SerializeObject(_cars);
            _carsWriter.Write(newCars);
            
            _carsWriter.Close();
        }
        public void CarsFromJson()
        {
            _carsReader = new StreamReader(_carsPath);
            
            String cars = _carsReader.ReadToEnd();
            _cars = JsonConvert.DeserializeObject<Dictionary<int, List<String>>>(cars);
            
            _carsReader.Close();
        }

        public void ImageNamesFromJson()
        {
            _imageReader = new StreamReader(_imagePaths);
            String json = _imageReader.ReadToEnd();
            _imageNames =  JsonConvert.DeserializeObject<Dictionary<int, List<string>>>(json);
            
            _imageReader.Close();
        }

        public void Reload()
        {
            //_imageNames.Clear();
            //_cars.Clear();
            
            CarsFromJson();
            ImageNamesFromJson();
        }

        public Dictionary<int, List<string>> Imagenames
        {
            get => _imageNames;
            set => _imageNames = value;
        }
        
        public Dictionary<int, List<string>> Cars
        {
            get => _cars;
            set => _cars = value;
        }
    }
}