using Lab7.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Lab7.Services; //This is how we can acces the public method GetSaleCollectionData

namespace Lab7.ViewModels
{
    //When you use ObserbaleProperty the class needs to be partial
    public partial class SalesListViewModel : ObservableObject //Observable object is what the view model inherits from, for proprty change notifications
    {
        //Observale Properties
        [ObservableProperty]
        private ObservableCollection<Sale> sales = new();

        [ObservableProperty]
        private string description = string.Empty;

        [ObservableProperty]
        private double? price;

        //Fields
        private readonly Task _loadSaleItems; //This is an object representing whether or not an object got completed

        //Constructor
        public SalesListViewModel()
        {
            _loadSaleItems = LoadSaleItems();
        }

        //Add methods
        public async Task LoadSaleItems() //This method is async, await cannot be used inside a constuctor so we put it in a method, and let the constructor call the method instead
        {
            //ask your JSON service for the sales records!
            Sales = await JsonStorageService.GetSaleCollectionData();
        }

        private void ClearInputs()
        {
            //EntryDescription.Text = "";
            //EntryPrice = null;

            //The inputs are two way binded so by chaning the values in the program it will change the values in the ui

            Description = string.Empty;
            Price = null;

        }
        //Commands that buttons can call
        [RelayCommand] //Will convert this into AddSaleCommand, TASK and async operation that does not return a value
        private async Task AddSale()
        {
            await _loadSaleItems; //Makes sure that the previously saved sales have finished loading before anything else is saved
            Sale newSale = new Sale(Description, Price.Value); //Creates a Sale Object, price.value extracts the actuall double from the nullable double

            Sales.Add(newSale); //Appends the sale object to the collection Sales the we declared earlier
            //This line only saves it to the current memory

            await JsonStorageService.SaveCollectionData(Sales); //Again this is using that service file called JsonStorageServices inside of the services folder
            //This line saves it to the actuall json file

            ClearInputs();

        }

    }
}
