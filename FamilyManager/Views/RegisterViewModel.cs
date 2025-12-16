// File: FamilyManager/ViewModels/RegisterViewModel.cs
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FamilyManager.Models;
using FamilyManager.Services;
using FamilyManager.Views;

namespace FamilyManager.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;

        public RegisterViewModel()
        {
            _databaseService = new DatabaseService(); // Hoặc Dependency Injection nếu đã cấu hình
            RegisterCommand = new Command(async () => await Register());
            NavigateBackCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        // Các thuộc tính Binding
        private string _fullName;
        public string FullName { get => _fullName; set { _fullName = value; OnPropertyChanged(); } }

        private string _email;
        public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }

        private string _password;
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }

        private string _confirmPassword;
        public string ConfirmPassword { get => _confirmPassword; set { _confirmPassword = value; OnPropertyChanged(); } }

        // Commands
        public ICommand RegisterCommand { get; }
        public ICommand NavigateBackCommand { get; }

        // Logic Đăng ký
        private async Task Register()
        {
            // 1. Validate dữ liệu
            if (string.IsNullOrWhiteSpace(FullName) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Lỗi", "Vui lòng nhập đầy đủ thông tin", "OK");
                return;
            }

            if (Password != ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Lỗi", "Mật khẩu xác nhận không khớp", "OK");
                return;
            }

            // 2. Kiểm tra Email đã tồn tại chưa
            var existingUser = await _databaseService.GetUserByEmailAsync(Email);
            if (existingUser != null)
            {
                await Application.Current.MainPage.DisplayAlert("Lỗi", "Email này đã được sử dụng", "OK");
                return;
            }

            // 3. Tạo User mới
            var newUser = new User
            {
                FullName = FullName,
                Email = Email,
                Password = Password // Lưu ý: Nên mã hóa password (MD5/SHA) trong thực tế
            };

            // 4. Lưu vào SQLite
            await _databaseService.SaveUserAsync(newUser);

            await Application.Current.MainPage.DisplayAlert("Thành công", "Đăng ký tài khoản thành công!", "OK");

            // 5. Quay lại trang đăng nhập
            await Shell.Current.GoToAsync("..");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}