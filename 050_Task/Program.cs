// Задача 50. Напишите программу, которая на вход принимает позиции элемента 
// в двумерном массиве, и возвращает значение этого элемента или же указание, 
// что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

int ReadNumber() // Метод проверки соответствия вводимого числа условиям задачи
{
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
        {
            return number;
        }
        else Console.WriteLine("Не удалось распознать требуемое число, попробуйте еще раз.");
    }
}
int[,] FillIntArray2D(int m, int n, int min, int max) // Метод заполнения массива случайными числами
{
    int[,] array = new int[m, n];
    Random number = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = number.Next(min, max + 1);
        }
    }
    return array;
}
int[,] PrintArray2D(int[,] array) // Метод вывода массива в консоль с выравниванием
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            // Выравнивание по правому краю каждого элемента с отступом 3 символа (-##)
            Console.Write(String.Format("{0,3:0}\t", array[i, j]));
        }
        Console.WriteLine();
    }
    return array;
}
void FindElement(int[,] array, int position)
{
    int stringPosition = position;
    int i = 0,
        j = position - 1;
    while (stringPosition > array.GetLength(1))
    {
        stringPosition -= array.GetLength(1);   // По циклу находим номер строки массива с требуемым элементом,
        i++;                                    // записываем в счетчик.
        j = stringPosition - 1;                 // Остаток - это положение элемента в строке массива со сдвигом влево на 1.
    }
    Console.WriteLine("Искомое число: " + array[i, j]);
}

Console.Clear();
Console.WriteLine("Программа поиска элемента по его позиции в массиве.");
Console.Write("Введите количество строк в массиве (m): ");
int numString = ReadNumber();
Console.Write("Введите количество столбцов в массиве (n): ");
int numColumn = ReadNumber();
Console.Write("Введите позицию искомого элемента в массиве: ");
int position = ReadNumber();
int min = -10, max = 10; // Границы генерации случайных чисел
int[,] array2D = FillIntArray2D(numString, numColumn, min, max);

if (position > array2D.Length) // Проверка вхождения искомого числа в диапазон значений
    {
        Console.WriteLine();
        Console.WriteLine($"Количество элементов массива {array2D.Length}.\n"+
        $"Введенное число позиции элемента массива {position} выходит за текущий диапазон индексов.");
    }
else
{
    FindElement(PrintArray2D(array2D), position);
}