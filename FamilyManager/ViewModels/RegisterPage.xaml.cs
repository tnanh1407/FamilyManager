// Remove one of the duplicate constructors for RegisterPage.
// Only one constructor with the same parameter types is allowed.

using FamilyManager.ViewModels; // Nhớ thêm dòng này

namespace FamilyManager.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        // Thêm dòng này để kết nối giao diện với code xử lý
        this.BindingContext = new RegisterViewModel();
    }
}