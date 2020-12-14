using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zavd
{
    class MyMatrix
    {
        //поля
        private double[,] matrix;
        public int height { get; }
        public int width { get; }
        //конструктор
        public MyMatrix(int rows, int colms)
        {
            matrix = new double[rows, colms];
            this.height = rows;
            this.width = colms;
        }
        //конструктор зщ об'єкту
        public MyMatrix(MyMatrix ob)
        {
            matrix = ob.matrix;
            this.height = ob.height;
            this.width = ob.width;
        }
        //конструктор з прямокутної матриці
        public MyMatrix(double[,] arr)
        {

            if (arr.GetLength(0) == arr.GetLength(1))
            {
                matrix = arr;
                this.height = arr.GetLength(0);
                this.width = arr.GetLength(1);
            }
            else
            {
                Console.WriteLine("матриця не квадратна!");
            }
        }
        //конструктор з масиву рядків
        public MyMatrix(string[,] ob)
        {
            if (ob.GetLength(0) == ob.GetLength(1))
            {
                matrix = new double[ob.GetLength(0), ob.GetLength(1)];
                this.height = ob.GetLength(0);
                this.width = ob.GetLength(1);
                try
                {
                    for (int i = 0; i < ob.GetLength(0); i++)
                    {
                        for (int j = 0; j < ob.GetLength(1); j++)
                        {
                            matrix[i, j] = double.Parse(ob[i, j]);
                        }
                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine("помилка");
                }
            }
            else
            {
                Console.WriteLine("матриця не квадратна!");
            }
        }
        //конструктор з одного рядка
        public MyMatrix(string s)
        {
            string[] arr = s.Split(' ');
            if (Math.Sqrt(arr.Length) % 1 == 0)
            {
                this.height = this.width = (int)Math.Sqrt(arr.Length);
                matrix = new double[this.height, this.width];

                int p = 0;
                for (int i = 0; i < this.height; i++)
                {
                    for (int j = 0; j < this.width; j++)
                    {
                        matrix[i, j] = double.Parse(arr[p]);
                        p++;
                    }
                }
            }
            else
            {
                Console.WriteLine("помилка, потрiбно ввести таке число змінних, щоб вийшла прямокутна матриця. наприклад 4, 9, 16, 25 i тд.");
            }
        }
        //індексатор
        public double this[int row, int colm]
        {
            set
            {
                if (ok(row, colm))
                {
                    matrix[row, colm] = value;
                }
            }
            get
            {
                if (ok(row, colm))
                {
                    return matrix[row, colm];
                }
                return 0;
            }
        }
        private bool ok(int row, int colm)
        {
            if ((row >= 0 & row < matrix.GetLength(0)) && (colm >= 0 & colm < matrix.GetLength(1))) return true;
            return false;
        }
        //заповнення
        public void filingOfMatrix(MyMatrix ob)
        {
            Random rand = new Random();
            for (int i = 0; i < ob.height; i++)
            {
                for (int j = 0; j < ob.width; j++)
                {
                    ob.matrix[i, j] = rand.Next(-1, 9);
                }
            }
        }
        public static MyMatrix operator *(MyMatrix matrixA, MyMatrix matrixB)
        {
            if (matrixA.matrix.Length != matrixB.matrix.Length)
            {
                throw new Exception("Множення неможливо! Кiлькiсть стовпцiв першої матрицi не дорівнює кількостi рядкiв другої матрицi.");
            }
            MyMatrix matrixC = new MyMatrix(matrixA.height, matrixB.width);
            for (var i = 0; i < matrixA.height; i++)
            {
                for (var j = 0; j < matrixB.width; j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < matrixA.width; k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }
            return matrixC;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    result = result + matrix[i, j] + " ";
                }
                result = result + '\n';
            }
            return result;
        }
        //метод транспонування матриці
        public double[,] GetTransponedArray(MyMatrix ob)
        {
            double[,] result = new double[ob.height, ob.width];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = ob[j, i];
                }
            }
            return result;
        }
        //повертає транспоновану матрицю
        public MyMatrix GetTransponedCopy(MyMatrix ob)
        {
            double[,] resultArr = GetTransponedArray(ob);
            return new MyMatrix(resultArr);
        }
        public void TransponeMe(MyMatrix ob)
        {
            this.matrix = GetTransponedArray(ob);
        }
    }
}