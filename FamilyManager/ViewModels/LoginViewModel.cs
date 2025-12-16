using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FamilyManager.Services;
using FamilyManager.Views;

namespace FamilyManager.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        // Constructor: Inject DatabaseService
        public LoginViewModel()
        {
            _databaseService = new DatabaseService();
        }

        [ObservableProperty]
        string email; // Đổi UserName thành Email cho khớp với Model User

        [ObservableProperty]
        string password;

        // Xử lý sự kiện Login
        [RelayCommand]
        async Task Login()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Lỗi", "Vui lòng nhập Email và Mật khẩu", "OK");
                return;
            }

            // 1. Tìm user trong Database theo Email
            var user = await _databaseService.GetUserByEmailAsync(Email);

            // 2. Kiểm tra mật khẩu (Lưu ý: Thực tế nên mã hóa password)
            if (user == null || user.Password != Password)
            {
                await Application.Current.MainPage.DisplayAlert("Thất bại", "Email hoặc mật khẩu không đúng!", "OK");
                return;
            }

            // 3. Đăng nhập thành công
            await Application.Current.MainPage.DisplayAlert("Thành công", $"Xin chào {user.FullName}!", "OK");

            // Chuyển vào trang chính (Dùng /// để xóa lịch sử back về login)
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }

        // Xử lý sự kiện chuyển sang trang Đăng ký
        [RelayCommand]
        async Task GoToRegister()
        {
            // Điều hướng sang RegisterPage
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }
    }
}