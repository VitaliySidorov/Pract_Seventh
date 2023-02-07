// Задача 47. Задайте двумерный массив размером m×n, 
// заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

double[,] FillArray2D(int m, int n, int min, int max) // Метод заполнения массива случайными вещественными числами
{
    double[,] array = new double[m, n];
    Random number = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            // Приведение сгенерированного случаного вещественного числа к виду с одним знаком после запятой
            array[i, j] = Math.Round(number.NextDouble() * (max - min) + min, 1);
        }
    }
    return array;
}
void PrintArray2D(double[,] array) // Метод вывода массива в консоль с выравниванием
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            // Выравнивание по правому краю каждого элемента с отступом 4 символа (-#.#)
            Console.Write(String.Format("{0,4:0.#}\t", array[i, j]));
        }
        Console.WriteLine();
    }
}
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

Console.Clear();
Console.WriteLine("Программа заполнения массива размером m x n случайными вещественными числами.");
Console.Write("Введите количество строк в массиве (m): ");
int numString = ReadNumber();
Console.Write("Введите количество столбцов в массиве (n): ");
int numRow = ReadNumber();
int min = -10, max = 10; // Границы генерации случайных чисел
PrintArray2D(FillArray2D(numString, numRow, min, max));