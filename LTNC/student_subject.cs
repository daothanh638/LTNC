using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ExampleCAdvance.Entities
{
    public class Student
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "ID must be between 2-50 letters")]
        public string StuId { get; set; }

        [StringLength(15, MinimumLength = 1, ErrorMessage = "Name must be between 1-15 letters")]
        public string Name { get; set; }

        [Range(0, 10, ErrorMessage = "Mid Point must be 0-10")]
        public double MidPoint { get; set; }

        [Range(0, 10, ErrorMessage = "Final Point must be 0-10")]
        public double FinalPoint { get; set; }

        [Range(0, 10, ErrorMessage = "Math Point must be 0-10")]
        public double MathPoint { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
    }

    public class Subject
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "ID must be between 2-50 letters")]
        public string SubID { get; set; }

        [StringLength(15, MinimumLength = 1, ErrorMessage = "Name must be between 1-15 letters")]
        public string Name { get; set; }

        [Range(1, 5, ErrorMessage = "Credit must be between 1-5")]
        public int Credit { get; set; }

        [StringLength(15, MinimumLength = 1, ErrorMessage = "Teacher must be between 1-15 letters")]
        public string Teacher { get; set; }

        public List<Student> Students { get; set; }

        public Subject()
        {
            Students = new List<Student>
            {
                new Student { StuId = "S001", Name = "John Doe", MidPoint = 8.5, FinalPoint = 9.0, MathPoint = 7.5, Email = "john.doe@example.com" },
                new Student { StuId = "S002", Name = "Jane Smith", MidPoint = 7.5, FinalPoint = 8.0, MathPoint = 6.0, Email = "jane.smith@example.com" },
                new Student { StuId = "S003", Name = "Michael Brown", MidPoint = 9.0, FinalPoint = 8.5, MathPoint = 9.5, Email = "michael.brown@example.com" },
                new Student { StuId = "S004", Name = "Emily Davis", MidPoint = 6.5, FinalPoint = 7.5, MathPoint = 3.5, Email = "emily.davis@example.com" }
            };
        }

        public void removeStudent(string stuId)
        {
            var studentToRemove = Students.Find(s => s.StuId == stuId);
            if (studentToRemove != null)
            {
                Students.Remove(studentToRemove);
            }
        }

        public Student getStudentById(string stuId)
        {
            return Students.Find(s => s.StuId == stuId);
        }

        public List<Student> getStudentbyName(string name)
        {
            return Students.Where(s => s.Name.Contains(name)).ToList();
        }

        public List<Student> getStudentbyEmail(string email)
        {
            return Students.Where(s => s.Email.Contains(email)).ToList();
        }

        public List<Student> getStudentPassed()
        {
            return Students.Where(s => (s.MidPoint + s.FinalPoint + s.MathPoint) / 3 >= 4).ToList();
        }

        public List<Student> getStudentFailed()
        {
            return Students.Where(s => (s.MidPoint + s.FinalPoint + s.MathPoint) / 3 < 4).ToList();
        }

        public List<Student> getStudentMidPointPrintPlus1()
        {
            return Students.Select(s => new Student
            {
                StuId = s.StuId,
                Name = s.Name,
                MidPoint = s.MidPoint + 1,
                FinalPoint = s.FinalPoint,
                MathPoint = s.MathPoint,
                Email = s.Email
            }).ToList();
        }

        // Method 2: Use ForEach
        //     return Students.ForEach(s => new Student
        //     {
        //         StuId = s.StuId,
        //         Name = s.Name,
        //         MidPoint = s.MidPoint + 1,
        //         FinalPoint = s.FinalPoint,
        //         Email = s.Email
        //     });.ToList();
        // }
        public void updateStudent(Student student)
        {
            var StudentToUpdate = Students.Find(s => s.StuId == student.StuId);
            if (StudentToUpdate != null)
            {
                StudentToUpdate.Name = student.Name;
                StudentToUpdate.MidPoint = student.MidPoint;
                StudentToUpdate.FinalPoint = student.FinalPoint;
                StudentToUpdate.MathPoint = student.MathPoint;
                StudentToUpdate.Email = student.Email;
            }
        }
    }

    public class Program
    {
        static Subject subject = new Subject();

        static void Main(string[] args)
        {
            subject.SubID = "SUB001";
            subject.Name = "Toan";
            subject.Credit = 3;
            subject.Teacher = "Mr. Tran";

            while (true)
            {
                Console.WriteLine("\n===== QUAN LY SINH VIEN =====");
                Console.WriteLine("1. Hien thi danh sach sinh vien");
                Console.WriteLine("2. Them sinh vien");
                Console.WriteLine("3. Xoa sinh vien theo ID");
                Console.WriteLine("4. Tim theo ID");
                Console.WriteLine("5. Tim theo ten");
                Console.WriteLine("6. Tim theo email");
                Console.WriteLine("7. Cap nhat sinh vien");
                Console.WriteLine("8. Danh sach dat");
                Console.WriteLine("9. Danh sach truot");
                Console.WriteLine("10. Tang diem giua ky len 1 (xem truoc)");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": PrintStudents(subject.Students); break;
                    case "2": AddStudent(); break;
                    case "3": RemoveStudent(); break;
                    case "4": FindById(); break;
                    case "5": FindByName(); break;
                    case "6": FindByEmail(); break;
                    case "7": UpdateStudent(); break;
                    case "8": PrintStudents(subject.getStudentPassed()); break;
                    case "9": PrintStudents(subject.getStudentFailed()); break;
                    case "10": PrintStudents(subject.getStudentMidPointPrintPlus1()); break;
                    case "0": return;
                    default: Console.WriteLine("Lua chon khong hop le!"); break;
                }
            }
        }

        static void PrintStudents(List<Student> students)
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("(Khong co sinh vien nao)");
                return;
            }

            Console.WriteLine("{0,-8} {1,-15} {2,-8} {3,-8} {4,-8} {5,-25} {6,-6}",
                "ID", "Ten", "Giua", "Cuoi", "Toan", "Email", "TB");
            foreach (var s in students)
            {
                double avg = (s.MidPoint + s.FinalPoint + s.MathPoint) / 3;
                Console.WriteLine("{0,-8} {1,-15} {2,-8} {3,-8} {4,-8} {5,-25} {6,-6:F2}",
                    s.StuId, s.Name, s.MidPoint, s.FinalPoint, s.MathPoint, s.Email, avg);
            }
        }

        static string ReadString(string label)
        {
            Console.Write(label);
            return Console.ReadLine();
        }

        static double ReadDouble(string label)
        {
            while (true)
            {
                Console.Write(label);
                double value;
                if (double.TryParse(Console.ReadLine(), out value))
                    return value;
                Console.WriteLine("Nhap sai, vui long nhap lai!");
            }
        }

        static Student ReadStudent(string stuId)
        {
            return new Student
            {
                StuId = stuId,
                Name = ReadString("Ten: "),
                MidPoint = ReadDouble("Diem giua ky: "),
                FinalPoint = ReadDouble("Diem cuoi ky: "),
                MathPoint = ReadDouble("Diem toan: "),
                Email = ReadString("Email: ")
            };
        }

        static bool Validate(Student student)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(student);
            if (Validator.TryValidateObject(student, context, results, true))
                return true;

            foreach (var r in results)
                Console.WriteLine("Loi: " + r.ErrorMessage);
            return false;
        }

        static void AddStudent()
        {
            Student student = ReadStudent(ReadString("Ma sinh vien: "));
            if (!Validate(student))
            {
                Console.WriteLine("Them sinh vien that bai!");
                return;
            }
            if (subject.getStudentById(student.StuId) != null)
            {
                Console.WriteLine("Ma sinh vien da ton tai!");
                return;
            }
            subject.Students.Add(student);
            Console.WriteLine("Them sinh vien thanh cong!");
        }

        static void RemoveStudent()
        {
            string id = ReadString("Nhap ma sinh vien can xoa: ");
            if (subject.getStudentById(id) == null)
                Console.WriteLine("Khong tim thay sinh vien!");
            else
            {
                subject.removeStudent(id);
                Console.WriteLine("Xoa sinh vien thanh cong!");
            }
        }

        static void FindById()
        {
            Student s = subject.getStudentById(ReadString("Nhap ma sinh vien: "));
            if (s == null)
                Console.WriteLine("Khong tim thay sinh vien!");
            else
                PrintStudents(new List<Student> { s });
        }

        static void FindByName()
        {
            PrintStudents(subject.getStudentbyName(ReadString("Nhap ten can tim: ")));
        }

        static void FindByEmail()
        {
            PrintStudents(subject.getStudentbyEmail(ReadString("Nhap email can tim: ")));
        }

        static void UpdateStudent()
        {
            string id = ReadString("Nhap ma sinh vien can cap nhat: ");
            if (subject.getStudentById(id) == null)
            {
                Console.WriteLine("Khong tim thay sinh vien!");
                return;
            }

            Student student = ReadStudent(id);
            if (!Validate(student))
            {
                Console.WriteLine("Cap nhat that bai!");
                return;
            }
            subject.updateStudent(student);
            Console.WriteLine("Cap nhat thanh cong!");
        }
    }
}