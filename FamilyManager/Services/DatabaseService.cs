using SQLite;
using FamilyManager.Models; // Đảm bảo dòng này không lỗi sau khi tạo Model ở Bước 4

namespace FamilyManager.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        // Hàm khởi tạo Database (Chỉ chạy 1 lần khi gọi)
        async Task Init()
        {
            if (_database is not null)
                return;

            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

            // Tạo các bảng dữ liệu (Sẽ thêm tiếp các bảng khác vào đây sau này)
            await _database.CreateTableAsync<Member>();
            // await _database.CreateTableAsync<AppTask>(); // Mở comment khi đã tạo Model Task
        }

        // --- CÁC HÀM XỬ LÝ CHO MEMBER (THÀNH VIÊN) ---

        public async Task<List<Member>> GetMembersAsync()
        {
            await Init();
            return await _database.Table<Member>().ToListAsync();
        }

        public async Task<int> SaveMemberAsync(Member item)
        {
            await Init();
            if (item.Id != 0)
                return await _database.UpdateAsync(item); // Cập nhật
            else
                return await _database.InsertAsync(item); // Thêm mới
        }

        public async Task<int> DeleteMemberAsync(Member item)
        {
            await Init();
            return await _database.DeleteAsync(item);
        }
    }
}