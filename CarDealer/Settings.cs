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
        private String _reservationPath = @"../../Reservations.json";
        
        private Dictionary<int, List<String>> _imageNames;
        private Dictionary<int, List<String>> _cars;
        private Dictionary<String, List<String>> _wishList;
        private Dictionary<String, List<String>> _dates;

        private StreamWriter _imageWriter;
        private StreamWriter _carsWriter;
        private StreamWriter _wishListWriter;
        private StreamWriter _reservationsWriter;

        private StreamReader _imageReader;
        private StreamReader _carsReader;
        private StreamReader _wishListReader;
        private StreamReader _reservationsListReader;

        public Settings()
        {
            Reload();
        }
        
        // TO JSON FUNCTIONS
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
        public void ReservationsToJson()
        {
            _reservationsWriter= new StreamWriter(_reservationPath);
            
            String newR = JsonConvert.SerializeObject(_dates);
            _reservationsWriter.Write(newR);
            
            _reservationsWriter.Close();
        }
        
        // FROM JSON FUNCTIONS
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
        public void ReservationsFromJson()
        {
            _reservationsListReader = new StreamReader(_wishListPath);
            String json = _reservationsListReader.ReadToEnd();
            _dates =  JsonConvert.DeserializeObject<Dictionary<String, List<String>>>(json);
            
            _reservationsListReader.Close();
        }

        // RELOAD FUNCTION
        public void Reload()
        {
            CarsFromJson();
            ImageNamesFromJson();
            WishListFromJson();
            ReservationsFromJson();
        }

        // GETTERS AND SETTERS
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
        
        public Dictionary<string, List<string>> Dates
        {
            get => _dates;
            set => _dates = value;
        }

    }
}