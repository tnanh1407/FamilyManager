
using SQLite;
using FamilyManager.Models;
namespace FamilyManager.Services
{
public class UserDatabaseService
    {
        private SQLiteAsyncConnection _database;
        // Khởi tạo database (chỉ chạy 1 lần)
        private async Task Init()
        {
            if (_database != null)
                return;

            _database = new SQLiteAsyncConnection(
                Constants.DatabasePath,
                Constants.Flags
            );

            await _database.CreateTableAsync<User>();
        }

        // Lấy user theo email hoặc username (đăng nhập)
        public async Task<User?> GetUserByUsernameOrEmailAsync(string input)
        {
            await Init();
            return await _database.Table<User>()
                .Where(u => u.Email == input || u.Username == input)
                .FirstOrDefaultAsync();
        }
        // Lấy user theo Id
        public async Task<User?> GetUserByIdAsync(int id)
        {
            await Init();
            return await _database
                .Table<User>()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }

        // Thêm user mới (đăng ký)
        public async Task<int> CreateUserAsync(User user)
        {
            await Init();
            return await _database.InsertAsync(user);
        }

        // Cập nhật user
        public async Task<int> UpdateUserAsync(User user)
        {
            await Init();
            return await _database.UpdateAsync(user);
        }

        // Xóa user
        public async Task<int> DeleteUserAsync(User user)
        {
            await Init();
            return await _database.DeleteAsync(user);
        }

        // Lấy danh sách toàn bộ user (admin)
        public async Task<List<User>> GetUsersAsync()
        {
            await Init();
            return await _database.Table<User>().ToListAsync();
        }
    }
}
