namespace FamilyManager.Views;
using FamilyManager.ViewModels;
using System;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
        InitializeComponent();
        this.BindingContext = new RegisterViewModel(); // Kết nối View với ViewModel
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }
}