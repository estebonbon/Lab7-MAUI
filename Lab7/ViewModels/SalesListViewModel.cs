using Lab7.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace Lab7.ViewModels
{
    public class SalesListViewModel
    {
        private readonly Task _loadSaleItems;
        public SalesListViewModel()
        {
            _loadSaleItems = LoadSaleItems();
        }
        public async Task LoadSaleItems()
        {
            //ask your JSON service for the sales records!
        }

    }
}
