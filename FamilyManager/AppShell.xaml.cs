
using FamilyManager.Views;

namespace FamilyManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Đăng ký đường dẫn trang chủ để Login xong thì nhảy vào đây
            Routing.RegisterRoute("MainPage", typeof(MainPage));
        }
    }
}