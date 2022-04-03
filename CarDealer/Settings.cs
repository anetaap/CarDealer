﻿using System;
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

        public Settings()
        {
            var imageReader = new StreamReader(_imagePaths);
            var carsReader = new StreamReader(_carsPath);
            
            String json = imageReader.ReadToEnd();
            String cars = carsReader.ReadToEnd();
            
            _imageNames =  JsonConvert.DeserializeObject<Dictionary<int, List<string>>>(json);
            _cars = JsonConvert.DeserializeObject<Dictionary<int, List<String>>>(cars);
            
            imageReader.Close();
            carsReader.Close();
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