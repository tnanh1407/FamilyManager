using FamilyManager.ViewModels;

namespace FamilyManager.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        // Gán BindingContext
        this.BindingContext = new LoginViewModel();
    }
}