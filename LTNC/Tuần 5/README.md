# Tuần 5 — Entity Framework Core Code First

Tuần này thực hành xây dựng ứng dụng theo hướng Code First với Entity Framework Core.

## Mục tiêu

- Khai báo entity và cấu hình quan hệ giữa các bảng.
- Tạo `DbContext` và cấu hình nhà cung cấp cơ sở dữ liệu.
- Sinh migration từ các lớp model và cập nhật cơ sở dữ liệu.
- Thực hiện các thao tác CRUD bằng Entity Framework Core.

## Quy trình thực hành

1. Tạo các lớp entity cho bài toán.
2. Khai báo `DbSet<T>` và cấu hình model trong `DbContext`.
3. Cấu hình connection string và đăng ký nhà cung cấp cơ sở dữ liệu.
4. Tạo migration ban đầu bằng `dotnet ef migrations add InitialCreate`.
5. Cập nhật cơ sở dữ liệu bằng `dotnet ef database update`.
6. Kiểm tra thêm, đọc, sửa và xóa dữ liệu qua `DbContext`.

Khi thay đổi entity hoặc cấu hình model, tạo migration mới trước khi cập nhật cơ sở dữ liệu.