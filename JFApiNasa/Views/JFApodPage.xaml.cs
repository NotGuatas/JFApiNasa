using JFApiNasa.ViewModels;
namespace JFApiNasa.Views;

public partial class JFApodPage : ContentPage
{
	public JFApodPage()
	{
		InitializeComponent();

        BindingContext = new  JFApodViewModel();
    }
}