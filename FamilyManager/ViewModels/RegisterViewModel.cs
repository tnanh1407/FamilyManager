using System.Windows.Input;
using FamilyManager.Models;
using FamilyManager.Services;

namespace FamilyManager.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly UserDatabaseService _userDb = new();

        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public ICommand RegisterCommand { get; }
        public ICommand NavigateBackCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => await RegisterAsync());
            NavigateBackCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        private async Task RegisterAsync()
        {
            if (Password != ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Lỗi", "Mật khẩu không khớp", "OK");
                return;
            }

            var existing = await _userDb.GetUserByUsernameOrEmailAsync(Email);
            if (existing != null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Lỗi", "Email đã tồn tại", "OK");
                return;
            }

            var user = new User
            {
                FullName = FullName,
                Username = Username,
                Email = Email,
                Password = Password,
                Role = UserRole.User
            };

            await _userDb.CreateUserAsync(user);

            await Application.Current.MainPage.DisplayAlert(
                "Thành công", "Đăng ký thành công", "OK");

            await Shell.Current.GoToAsync("..");
        }
    }
}

