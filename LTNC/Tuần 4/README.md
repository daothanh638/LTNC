# Bài thực hành 3 - Lập trình sự kiện

Ứng dụng Windows Forms quản lý sinh viên theo lớp, dựng theo yêu cầu và ảnh giao diện trong tài liệu bài tập.

## Chức năng

- Hiển thị danh sách lớp và sinh viên mẫu khi mở ứng dụng.
- Thêm, sửa, xóa sinh viên; thao tác sửa và xóa có hộp thoại xác nhận.
- Tìm sinh viên theo mã, họ tên, email hoặc lớp.
- Kiểm tra dữ liệu bằng Data Annotations.
- Quan hệ một lớp có nhiều sinh viên được biểu diễn qua `LopHoc.Students` và `SinhVien.Class`.
- Nút Làm mới xóa trắng biểu mẫu và chuyển con trỏ về mã sinh viên.

## Mở ứng dụng

Mở `WinFormsApp2.slnx` bằng Visual Studio có hỗ trợ .NET 9 và Windows Forms, sau đó chạy dự án.

Dữ liệu hiện được lưu trong bộ nhớ; khi đóng ứng dụng, các thay đổi được nhập trong phiên chạy sẽ không được giữ lại.
