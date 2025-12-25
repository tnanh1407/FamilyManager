using FamilyManager.ViewModels;

namespace FamilyManager.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();

        // Gán ViewModel cho Page
        BindingContext = new RegisterViewModel();
    }
}
