global using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Threading.Tasks.Dataflow;

// метод возвращает новый массив по условию задачи, используя метод Resize (убирает двойное прохождение циклом по исходному массиву)
static string [] Resize_mass (string [] str) {
int k = 0;
string [] new_str = new string [k]; 
for (int i = 0; i < str.Length; i++)               
{
     if (str[i].Length <=3) {Array.Resize(ref new_str, new_str.Length + 1); new_str[k] = str[i]; k++;}
}
return new_str;
}
//-------------------------------------------------------------------------------------------------

//string [] str = {"Hello", "2", "world", ":-)"};    // заданный массив строк по условию
string [] str = {"1234", "1567", "-2", "computer science"};
//string [] str = {"Russia", "Denmark", "Kazan"};  
//string [] str = {"fff", "67", "cold", "told#", "%$@", "06b", "9"};
int count = 0;                                     
for (int i = 0; i < str.Length; i++)               
{   
    if (str[i].Length <=3)  count++; 
}
// так как в с# нет динамических массивов, а списком нельзя пользоваться, 
//то сначала проходим по заданному массиву, определяя количество его элементов,
// удовлетворяющих условию задачи, чтобы на этом основании знать, какое количество элементов будет в новом массиве
var new_str = new string [count]; 
int k = 0;
for (int i = 0; i < str.Length; i++)               // заполняем новый массив отобранными элементами
{
    if (str[i].Length <=3) {new_str[k] = str[i]; k++;}
}
Console.WriteLine($"Полученный массив: [{String.Join(", ", new_str)}]");


string [] new_str_R = Resize_mass(str);            // формируем новый массив по условию, используя метод Resize
Console.WriteLine($"Полученный массив (с помощью метода Resize): [{String.Join(", ", new_str_R)}]");

