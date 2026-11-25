using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using Lab7.Models;

namespace Lab7.Services
{
    public static class JsonStorageService //Static means we dont need an instance to call the class
    {
        //Tell the program where to store and retrieve the information
        private static readonly string _fileName =
            Path.Combine(FileSystem.AppDataDirectory, "Lab7.json"); //First part is the desginated store folder and the second part is the name we are giving the file "Lab7.json"

        #region Retrieve method
        public static async Task<ObservableCollection<Sale>> GetSaleCollectionData() //GetSaleCollection is the name of the method, and ObservableCollection sale will return a collection of sales objects
        {
            //This method will read the JSON string and convert it into C# objectsnext

            ObservableCollection<Sale> data = new(); //Empty collection that the ViewModel can use, its useful for when we are first booting the app, Lab7.json might not even exsist yet

            try
            {
                string jsonString = await File.ReadAllTextAsync(_fileName); //Reads all the text inside of the json file, jsonString stores the retrieved text

                data = JsonSerializer.Deserialize<ObservableCollection<Sale>>(jsonString)!; //"!" this is a null forgiving operator or i could do [?? new()], takes the json text, and converts it into sale objects
                //Take this JSON string and use it to construct an ObservableCollection containing Sale objects.
            }
            catch 
            {

            }

            return data; //Apperantly Im promising to return a collection of sales objects, whatever is inside of the Task<HERE> is the datatype the program expects to be returned
        }

        #endregion

        #region Save method

        public static async Task<bool> SaveCollectionData(ObservableCollection<Sale> data) //This whole method only retruns a boolean, the boolean is used to determine whether the data was stored succesfully either true or false
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(data);
                //Serializer can determine the type of data being passed in, it takes the C# data and converts it into a jsonString

                await File.WriteAllTextAsync(_fileName, jsonString); 
                //File.Write writes a string into a file format
                //_fileName tells the program where to store the information, refer back to the static readonly string
                //jsonString, is the first step in this method that converts the C# onbjects into a jsonString
                //await must be used becuase this is an async method

                return true; 
            }
            catch 
            {

            }

            return false; //If it fails to save return false
        }

        #endregion

    }
}
