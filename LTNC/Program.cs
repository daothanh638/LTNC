using ExampleCAdvance.hinh;
using hello_world.hinh;
using system runtime.ConstrainExcecution;
hinhchunhat hinh = new hinhchunhat();
hinh.chieudai = 87;
int[] a = new int[10];
Console.WriteLine("Hello World!");
int a;
Console.WriteLine("Nhap a:");
a = Convert.ToInt32(Console.ReadLine());
int b;
Console.Write("nhap b;");
try
{
    b = int.Parse(Console.ReadLine());
}
catch (FormatException ex)
{
    Console.WriteLine("nhap sai dinh dang, vui long nhap lai!")
}
int c;
while (true)
//khai bao bien kieu duoc xac dinh tai luc runtime
// kieu du lieu k doi
var sum = a + b + c;
// kieu du lieu thay doi duoc
dynamic sum1 = a + b + c;
sum = 0.9;
sum1 = 0.9;
sum1 = "asfaasfaf";
const int max = 9;
