using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FamilyManager.Services;

namespace FamilyManager.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        public LoginViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        // Tạo thuộc tính UserName có chức năng thông báo khi thay đổi (Binding)
        [ObservableProperty]
        string userName;

        // Tạo thuộc tính Password
        [ObservableProperty]
        string password;

        // Xử lý sự kiện khi bấm nút Login
        [RelayCommand]
        async Task Login()
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Lỗi", "Vui lòng nhập đầy đủ thông tin!", "OK");
                return;
            }

            // --- LOGIC GIẢ LẬP (Vì Model Member chưa có Password) ---
            // Sau này bạn có thể check Database ở đây.
            // Ví dụ: var user = await _databaseService.CheckLogin(UserName, Password);
            
            // Tạm thời cho phép đăng nhập luôn để test giao diện
            await Application.Current.MainPage.DisplayAlert("Thông báo", $"Xin chào {UserName}!", "OK");

            // Chuyển hướng vào trang chính (MainPage)
            // Dấu "//" nghĩa là reset stack, không cho back lại trang login
            await Shell.Current.GoToAsync("//MainPage");
        }

        // Xử lý sự kiện bấm nút Đăng ký (nếu có)
        [RelayCommand]
        async Task GoToRegister()
        {
            await Application.Current.MainPage.DisplayAlert("Thông báo", "Chức năng đang phát triển", "OK");
        }
    }
}