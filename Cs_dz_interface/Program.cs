using System.Drawing;

namespace Cs_dz_interface;

internal class Program
{
    static void Main(string[] args)
    {
        MyArray arr = new MyArray();
        arr.Show();
        Console.Write(arr.Less(7));
        Console.Write(arr.Greater(8));
        arr.ShowEven();
        arr.ShowOdd();
        Console.Write(arr.CountDistinct());
        Console.Write(arr.EqualToValue(5));
    }
}

interface ICalc
{
    int Less(int valueToCompare);  // возвращает количество значений меньших, чем valueToCompare   
    int Greater(int valueToCompare);  // возвращает количество значений  больших, чем valueToCompare
}

interface IOutput2
{
    void ShowEven();  // отображает четные значения из контейнера с данными
    void ShowOdd();  // отображает нечетные значения из контейнера с данными
}

interface ICalc2
{
    int CountDistinct();  // возвращает количество уникальных значений в контейнере данных
    int EqualToValue(int valueToCompare);  // возвращает количество значений равных valueToCompare
}

class MyArray : ICalc, IOutput2, ICalc2
{
    Random rnd = new Random();
    int[] arr;
    public MyArray(int size)  // конструктор с параметром размер
    {
        arr = new int[size];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(1,20);
        }
    }
    public MyArray()  // конструктор без параметра
    {
        Console.WriteLine("\nВведите длину массива (от 1 до 20):");
        uint length = 0;  // переменная для длины массива
        do  // цикл для повтора выброса исключения
        {
            try  // генерируем исключение
            {
                length = Convert.ToUInt32(Console.ReadLine());
                if (length < 1 || length > 20)  // если длина массива меньше 1 или больше 20
                    throw new Exception("Длина массива должна быть от 1 до 20");  // выбрасываем исключение
            }
            catch (Exception ex)  // выполнение кода при генерации исключения
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        while (length < 1 || length > 20);  // пока нужная длина массива не указана
       
        arr = new int[length];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(1, 20);
        }
    }

    public void Show()  // вывод массива в консоль
    {
        Console.WriteLine("Мой массив:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }

    public int Less(int valueToCompare)  // возвращает количество значений меньших, чем valueToCompare
    {
        Console.WriteLine($"\nКол-во значений, меньших чем {valueToCompare}");
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < valueToCompare)
                count++;
        }
        return count;
    }

    public int Greater(int valueToCompare)  // возвращает количество значений  больших, чем valueToCompare
    {
        Console.WriteLine($"\nКол-во значений, больших чем {valueToCompare}");
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > valueToCompare)
                count++;
        }
        return count;
    }

    public void ShowEven()  // отображает четные значения
    {
        Console.WriteLine("\nЧетные значения:");
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0)
                Console.Write(arr[i] + " ");
        }
    }

    public void ShowOdd()  // отображает нечетные значения
    {
        Console.WriteLine("\nНечетные значения:");
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 != 0)
                Console.Write(arr[i] + " ");
        }
    }

    public int CountDistinct()  // возвращает количество уникальных значений
    {
        Console.WriteLine("\nУникальные значения:");
        int count = 0;  // счетчик уникальных значений
        for (int i = 0; i < arr.Length; i++)
        {
            // если индекс первого вхождения i-го эл. равен индексу последнего вхождения i-го эл
            if (Array.IndexOf(arr, arr[i]) == Array.LastIndexOf(arr, arr[i]))
                count++;          
        }
        return count;
    }

    public int EqualToValue(int valueToCompare)  // возвращает количество значений равных valueToCompare
    {
        Console.WriteLine($"\nКол-во значений, равных {valueToCompare}");
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == valueToCompare)
                count++;
        }
        return count;
    }
}