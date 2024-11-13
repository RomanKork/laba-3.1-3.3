using System;
namespace laba_3._1_3._3
{
    internal class Programm
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность матрицы A (размер столбца и размер строки): ");
            work1 A = new work1(Check(), Check());
            Console.WriteLine("Введите размерность матрицы B (размер столбца и размер строки): ");
            work1 B = new work1(Check(), Check());
            Console.WriteLine("Введите размерность матрицы C (размер столбца и размер строки): ");
            work1 C = new work1(Check(), Check());
            Console.WriteLine("Матрица A:");
            Console.WriteLine(A);
            Console.WriteLine("Матрица B:");
            Console.WriteLine(B);
            Console.WriteLine("Матрица C:");
            Console.WriteLine(C);
            work1 result = (work1.Transpose(B) * A) - (C * 4) + B;
            result.ToString();
            Console.WriteLine("Результат выражения Вт * А - 4 * С + B:");
            Console.WriteLine(result);

            Console.WriteLine("Введите размерность матрицы(размер столбца и размер строки): ");
            work1 matrix1 = new work1(Check(), Check());
            matrix1.MasCanSort();
            Console.Write("Введите размерность квадратной матрицы: ");
            work1 matrix2 = new work1(Check());
            work1 matrix3 = new work1();


        }
        public static int Check()
        {
            int a;
            if (int.TryParse(Console.ReadLine(), out a) && a > 0)
            {
                return a;
            }
            Console.WriteLine("Вы ввели некорректное значение, введите значение вновь: ");
            return Check();
        }
    }
}