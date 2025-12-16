using FamilyManager.ViewModels;

namespace FamilyManager.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel; // Kết nối giao diện với logic
    }
}