// Задача 52. Задайте двумерный массив из целых чисел. 
// Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

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
void PrintArray2D(int[,] array) // Метод вывода массива в консоль с выравниванием
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            // Выравнивание по правому краю каждого элемента с отступом 3 символа (#,#)
            Console.Write(String.Format("{0,3}\t", array[i, j]));
        }
        Console.WriteLine();
    }
}
void AverageColumn(int[,] array2D)
{
    double[] arrayAverage = new double[array2D.GetLength(1)]; // Меняем порядок, сначала фиксируем номер столбца
    for (int j = 0; j <= array2D.GetLength(1) - 1; j++)
    {
        double tempAverage = 0;
        for (int i = 0; i <= array2D.GetLength(0) - 1; i++) // Складываем элементы столбца
        {
            tempAverage += array2D[i, j];
        }
        arrayAverage[j] = tempAverage / array2D.GetLength(0); // Считаем среднее арифметическое
        Console.Write(String.Format("{0,3:0.#}\t", arrayAverage[j]));
    }
    Console.WriteLine();
}

Console.Clear();
Console.WriteLine("Программа нахождения среднего арифметического элементов в столбцах массива (m,n).");
Console.Write("Введите количество строк в массиве (m): ");
int numString = ReadNumber();
Console.Write("Введите количество столбцов в массиве (n): ");
int numRow = ReadNumber();
int min = 0, max = 10; // Границы генерации случайных чисел
int[,] array2D = FillIntArray2D(numString, numRow, min, max);
PrintArray2D(array2D);
Console.WriteLine("Среднее арифметическое каждого столбца:");
AverageColumn(array2D);