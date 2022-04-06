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
        private String _wishListPath = @"../../wishList.json";
        
        private Dictionary<int, List<String>> _imageNames;
        private Dictionary<int, List<String>> _cars;
        private Dictionary<String, List<String>> _wishList;

        private StreamWriter _imageWriter;
        private StreamWriter _carsWriter;
        private StreamWriter _wishListWriter;

        private StreamReader _imageReader;
        private StreamReader _carsReader;
        private StreamReader _wishListReader;

        public Settings()
        {
            ImageNamesFromJson();
            CarsFromJson();
            WishListFromJson();
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
            _carsWriter= new StreamWriter(_wishListPath);
            
            String newCars = JsonConvert.SerializeObject(_cars);
            _carsWriter.Write(newCars);
            
            _carsWriter.Close();
        }
        public void WishListToJson()
        {
            _wishListWriter= new StreamWriter(_wishListPath);
            
            String newWish = JsonConvert.SerializeObject(_wishList);
            _wishListWriter.Write(newWish);
            
            _wishListWriter.Close();
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
        public void WishListFromJson()
        {
            _wishListReader = new StreamReader(_wishListPath);
            String json = _wishListReader.ReadToEnd();
            _wishList =  JsonConvert.DeserializeObject<Dictionary<String, List<String>>>(json);
            
            _wishListReader.Close();
        }

        public void Reload()
        {
            CarsFromJson();
            ImageNamesFromJson();
            WishListFromJson();
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
        public Dictionary<string, List<string>> WishList
        {
            get => _wishList;
            set => _wishList = value;
        }
    }
}