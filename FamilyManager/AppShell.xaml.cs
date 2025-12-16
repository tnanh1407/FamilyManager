using FamilyManager.Views;

namespace FamilyManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Đăng ký các đường dẫn (Route)
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage)); // Quan trọng: Đăng ký trang đăng ký
        }
    }
}