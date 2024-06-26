﻿global using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Threading.Tasks.Dataflow;

//------------------------------------------------------------------------------------------------
// метод принимает на вход пустой массив заданной длины и возвращает его заполненным пользователем
static string [] Fill_Array (string [] str) 
{
   for (int i = 0; i < str.Length; i++) 
   {
   Console.Write($"Введите {i} элемент: ");
   str[i] = Console.ReadLine()!;
   }
   return str;
}
//------------------------------------------------------------------------------------------------

//------------------------------------------------------------------------------------------------------
// метод, заполняющий массив способом, выбранным пользователем. Возвращает заполненный исходный массив
static string [] Choose (int ch)
{
  switch (ch)
  {
    case 1: // выбираем способ заполнения исходного массива строк
    {
      Console.Write("Введите количество строк - элементов обрабатываемого массива: ");
      
      var k = Console.ReadLine()!;
      if (k.Length == 0) {Console.WriteLine("Вы не ввели размерность массива!"); return Array.Empty<string>();}
      else {
        int t = Convert.ToInt32(k);
        string [] str = new string [t];
        str = Fill_Array(str);
        return str;}
    }
    case 2:
    {
    // заданный массив строк по условию 
    string [] str = {"Hello", "2", "world", ":-)"};    
    //string [] str = {"1234", "1567", "-2", "computer science"};
    //string [] str = {"Russia", "Denmark", "Kazan"};  
    //string [] str = {"df6", "8%--", "9#-"};
    return str;
    }
    default: {return Array.Empty<string>();}
  }
}
//-----------------------------------------------------------------------------------------------

//-------------------------------------------------------------------------------------------------
// метод  ФОРМИРУЕТ НОВЫЙ  массив по условию задачи и возвращает его
static  string [] Get_new_Array (string [] str) 
{
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
return new_str;
}
//------------------------------------------------------------------------------------------------------

//------------------------------------------------------------------------------------------------
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

//------------------------------------------------------------------------------------------------------
// основное тело программы
Console.Write("Выберите способ ввода первоначального массива (1 - вручную, 2 - заданный на старте): ");
var ch = Console.ReadLine()!;
if (ch.Length==0) {Console.WriteLine("Вы не выбрали способ заполнения исходного массива.");}
else 
{
  int chs = Convert.ToInt32(ch);
  string [] str = Choose(chs);                                             //получаем массив, с которым нужно работать
  Console.WriteLine($"Исходный массив: [{String.Join(", ", str)}]");
  string [] str_new = Get_new_Array(str);                                 // формируем новый массив согласно условию задачи
  Console.WriteLine($"Полученный массив: [{String.Join(", ", str_new)}]");
  string [] new_str_R = Resize_mass(str);                                 // формируем новый массив по условию, используя метод Resize
  Console.WriteLine($"Полученный массив (решение с помощью метода Resize): [{String.Join(", ", new_str_R)}]");
}

