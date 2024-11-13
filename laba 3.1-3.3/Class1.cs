using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_3._1_3._3
{
    class work1
    {
        public int[,] mas;
        public work1(int n, int m, bool empty)
        {
            mas = new int[n, m];
        }

        public work1(int n, int m)
        {
            mas = new int[n, m];
            int a;
            Console.WriteLine("Заполните матрицу: ");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a = Check();
                    mas[j, i] = a;
                }
            }
            Console.WriteLine("Заданный массив " + n + "x" + m + ':');
            printMas(mas);
        }
        public work1(int n)
        {
            mas = new int[n, n];
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                mas[i, 0] = rand.Next(10);
                for (int j = 1; j < n; j++)
                {
                    mas[i, j] = mas[i, j - 1] + rand.Next(10);
                }
            }
            Console.WriteLine("Случайный массив " + n + "x" + n + ", возрастающий по строкам:");
            printMas(mas);
        }
        public work1()
        {
            Random rand = new Random();
            int n = rand.Next(5, 10);
            mas = new int[n, n];
            int num = 1, top = 0, bottom = n - 1, left = 0, right = n - 1;

            while (num <= n * n)
            {
                for (int i = left; i <= right; i++)
                {
                    mas[top, i] = num++;
                }
                top++;

                for (int i = top; i <= bottom; i++)
                {
                    mas[i, right] = num++;
                }
                right--;

                for (int i = right; i >= left; i--)
                {
                    mas[bottom, i] = num++;
                }
                bottom--;

                for (int i = bottom; i >= top; i--)
                {
                    mas[i, left] = num++;
                }
                left++;
            }
            Console.WriteLine("Квадратная матрица, заполненная по спирали, размерностью " + n + "x" + n + ':');
            printMas(mas);
        }
        public int Check()
        {
            int a;
            if (int.TryParse(Console.ReadLine(), out a))
            {
                return a;
            }
            Console.WriteLine("Вы ввели некорректное значение, введите значение вновь: ");
            return Check();
        }
        private void printMas(int[,] mass)
        {
            int maxLength = 0;
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    int length = mass[i, j].ToString().Length;
                    if (length > maxLength)
                    {
                        maxLength = length;
                    }
                }
            }

            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    int spaces = maxLength - mass[i, j].ToString().Length;
                    for (int s = 0; s < spaces; s++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(mass[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void MasCanSort()
        {
            Console.WriteLine("Проверка возможности сортировки строк по возрастанию:");

            int[,] sortedMatrix = (int[,])mas.Clone();

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                int[] row = new int[mas.GetLength(1)];
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    row[j] = mas[i, j];
                }
                Array.Sort(row);
                bool isStrictlyAscending = true;
                for (int j = 1; j < row.Length; j++)
                {
                    if (row[j] <= row[j - 1])
                    {
                        isStrictlyAscending = false;
                        break;
                    }
                }
                if (isStrictlyAscending)
                {
                    Console.WriteLine($"Строка {i + 1} может быть отсортирована в строго возрастающем порядке.");
                }
                else
                {
                    Console.WriteLine($"Строка {i + 1} не может быть отсортирована в строго возрастающем порядке.");
                }
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    sortedMatrix[i, j] = row[j];
                }
            }

            Console.WriteLine("Матрица с отсортированными по возрастанию строками:");
            printMas(sortedMatrix);
        }
        public static work1 operator *(work1 matrix, int scalar)
        {
            int n = matrix.mas.GetLength(0);
            int m = matrix.mas.GetLength(1);
            work1 result = new work1(n, m, true);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result.mas[i, j] = matrix.mas[i, j] * scalar;
                }
            }
            return result;
        }

        public static work1 operator +(work1 matrix1, work1 matrix2)
        {
            int n = matrix1.mas.GetLength(0);
            int m = matrix1.mas.GetLength(1);

            if (n != matrix2.mas.GetLength(0) || m != matrix2.mas.GetLength(1))
            {
                throw new ArgumentException("Матрицы должны быть одинакового размера для сложения.");
            }

            work1 result = new work1(n, m, true);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result.mas[i, j] = matrix1.mas[i, j] + matrix2.mas[i, j];
                }
            }
            return result;
        }

        public static work1 operator -(work1 matrix1, work1 matrix2)
        {
            int n = matrix1.mas.GetLength(0);
            int m = matrix1.mas.GetLength(1);

            if (n != matrix2.mas.GetLength(0) || m != matrix2.mas.GetLength(1))
            {
                throw new ArgumentException("Матрицы должны быть одинакового размера для вычитания.");
            }

            work1 result = new work1(n, m, true);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result.mas[i, j] = matrix1.mas[i, j] - matrix2.mas[i, j];
                }
            }
            return result;
        }

        public static work1 Transpose(work1 matrix)
        {
            int n = matrix.mas.GetLength(0);
            int m = matrix.mas.GetLength(1);
            work1 result = new work1(m, n, true);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result.mas[j, i] = matrix.mas[i, j];
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            int maxLength = 0;

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    int length = mas[i, j].ToString().Length;
                    if (length > maxLength)
                    {
                        maxLength = length;
                    }
                }
            }

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    result += mas[i, j].ToString().PadLeft(maxLength + 1);
                }
                result += "\n";
            }
            return result;
        }
        public static work1 operator *(work1 matrixA, work1 matrixB)
        {
            int rowsA = matrixA.mas.GetLength(0);
            int colsA = matrixA.mas.GetLength(1);
            int rowsB = matrixB.mas.GetLength(0);
            int colsB = matrixB.mas.GetLength(1);

            if (colsA != rowsB)
            {
                throw new InvalidOperationException("Число столбцов первой матрицы должно совпадать с числом строк второй матрицы.");
            }

            work1 resultMatrix = new work1(rowsA, colsB, true);

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    resultMatrix.mas[i, j] = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        resultMatrix.mas[i, j] += matrixA.mas[i, k] * matrixB.mas[k, j];
                    }
                }
            }

            return resultMatrix;
        }
    }
}
