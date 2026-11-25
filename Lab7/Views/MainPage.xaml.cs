using Lab7.ViewModels;

namespace Lab7.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage(SalesListViewModel slvm)
        {
            InitializeComponent();
            BindingContext = slvm; //The binding context was already set, helps at runtime
        }

    }
}
