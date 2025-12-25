using System.Windows.Input;
using FamilyManager.Models;
using FamilyManager.Services;

namespace FamilyManager.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly UserDatabaseService _userDb;

        public LoginViewModel()
        {
            _userDb = new UserDatabaseService();

            LoginCommand = new Command(
                async () => await LoginAsync(),
                CanLogin
            );

            GoToRegisterCommand = new Command(
                async () => await GoToRegisterAsync()
            );
        }

        // ========================
        // PROPERTIES (BIND UI)
        // ========================

        private string _loginInput;
        public string LoginInput
        {
            get => _loginInput;
            set
            {
                _loginInput = value;
                OnPropertyChanged();
                ((Command)LoginCommand).ChangeCanExecute();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
                ((Command)LoginCommand).ChangeCanExecute();
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
                ((Command)LoginCommand).ChangeCanExecute();
            }
        }

        // ========================
        // COMMANDS
        // ========================

        public ICommand LoginCommand { get; }
        public ICommand GoToRegisterCommand { get; }

        // ========================
        // METHODS
        // ========================

        private bool CanLogin()
        {
            return !IsBusy
                && !string.IsNullOrWhiteSpace(LoginInput)
                && !string.IsNullOrWhiteSpace(Password);
        }

        private async Task LoginAsync()
        {
            try
            {
                IsBusy = true;
                ErrorMessage = string.Empty;

                // Tìm user theo Email hoặc Username
                var user = await _userDb.GetUserByUsernameOrEmailAsync(LoginInput);

                if (user == null)
                {
                    ErrorMessage = "Tài khoản không tồn tại";
                    return;
                }

                // ❗ Hiện tại so sánh mật khẩu dạng plain text
                if (user.Password != Password)
                {
                    ErrorMessage = "Mật khẩu không đúng";
                    return;
                }

                // ========================
                // LOGIN SUCCESS
                // ========================

                if (user.Role == UserRole.Admin)
                {
                    // TODO: điều hướng trang Admin
                    // await Shell.Current.GoToAsync("//admin");
                }
                else
                {
                    // TODO: điều hướng trang User
                    // await Shell.Current.GoToAsync("//home");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Lỗi: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GoToRegisterAsync()
        {
            await Shell.Current.GoToAsync("register");
        }
    }
}
