using Lab7.ViewModels;

namespace Lab7.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage(SalesListViewModel slvm)
        {
            InitializeComponent();
            BindingContext = slvm;
        }

    }
}
