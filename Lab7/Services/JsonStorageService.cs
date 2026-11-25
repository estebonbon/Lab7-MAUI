using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Lab7.Services
{
    public static class JsonStorageService //Static means we dont need an instance to call the class
    {
        //Tell the program where to store and retrieve the information
        private static readonly string _fileName =
            Path.Combine(FileSystem.AppDataDirectory, "Lab7.json"); //First part is the desginated store folder and the second part is the name we are giving the file "Lab7.json"


    }
}
