using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice12
{
    class Program
    {


        static void PSort(double[] arr)
        {
            // сортировка неупорядоченного массива
            Console.WriteLine("Несортированный массив: " + String.Join(", ", arr));
            countChange = 0;
            countCompare = 0;
            double[] sortArr = PiromidSort(arr, arr.Length);
            Console.WriteLine("\nОтсортированный неупорядоченный массив: \n" + String.Join(", ", sortArr));
            Console.WriteLine("Затрачено {0} сравнений, {1} пересылок",
               countCompare, countChange);

            // сортировка упорядоченного по возрастанию массива
            countChange = 0;
            countCompare = 0;
            double[] sortSortedUpArr = PiromidSort(sortArr, arr.Length);
            Console.WriteLine("\nОтсортированный по возрастанию: \n" + String.Join(", ", sortSortedUpArr));
            Console.WriteLine("{0} сравнений, {1} пересылок", countCompare, countChange);

            Array.Reverse(sortArr);
            countChange = 0;
            countCompare = 0;
            double[] sortSortedDownArr = PiromidSort2(sortArr, arr.Length);
            Console.WriteLine("\nОтсортированный по убыванию массив: \n" + String.Join(", ", sortSortedDownArr));
            Console.WriteLine("{0} сравнений, {1} пересылок", countCompare, countChange);
        }


        static int add2pyramid(double[] arr, int i, int N)
        {
            int imax;
            double buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
                countCompare += 2;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                countChange++;
                if (imax < N / 2) i = imax;
                countCompare += 2;
            }
            return i;
        }
        public static double[] PiromidSort(double[] arr, int len)
        {
            //шаг 1: постройка пирамиды
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
                countCompare++;
            }

            //шаг 2: сортировка
            double buf;
            for (int k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                }
            }
            return arr;
        }

        static int add2pyramid2(double[] arr, int i, int N)
        {
            int imax;
            double buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] > arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
                countCompare += 2;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] > arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
                countCompare += 2;
                countChange++;
            }
            return i;
        }
        public static double[] PiromidSort2(double[] arr, int len)
        {
            //шаг 1: постройка пирамиды
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid2(arr, i, len);
                if (prev_i != i) ++i;
                countCompare++;
            }

            //шаг 2: сортировка
            double buf;
            for (int k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid2(arr, i, k);
                }
            }
            return arr;
        }

        public static int countChange = 0;
        public static int countCompare = 0;




        public static int[] countingSort(int[] arr, int min, int max, ref int kswap, ref int ksrv)
        {
            int[] count = new int[max - min + 1];
            int z = 0;

            for (int i = 0; i < count.Length; i++)
            {
                count[i] = 0;
                ksrv++;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i] - min]++;
            }

            for (int i = min; i <= max; i++)
            {
                while (count[i - min]-- > 0)
                {
                    arr[z] = i;
                    z++;
                    kswap++;
                    ksrv++;
                }
            }
            return arr;
        }
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int[] arrneup = new int[10];
            double[] arrneupforp = new double[10];
            int[] arr2povozr = new int[10];
            int[] arr2poubiv = new int[10];
            Console.WriteLine("Отсортированный неупорядоченный массив: ");
            for ( int i=0; i< arrneup.Length;i++)
            {
                arrneup[i] = rnd.Next(-101,101);
                Console.Write(arrneup[i] + " ");
            }

            for (int i = 0; i < arrneupforp.Length; i++)
            {
                arrneupforp[i] = rnd.Next(-101, 101);
                
            }
            Console.WriteLine();
            arr2povozr[0] = 0;
            arr2poubiv[0] = 0;
            Console.WriteLine("Отсортированный по возрастанию массив: ");
            for (int i = 1; i < arr2povozr.Length; i++)
            {
                arr2povozr[i] = rnd.Next(arr2povozr[i-1]+1, arr2povozr[i - 1] + 20) ;
                Console.Write((arr2povozr[i])+" ");
            }
            Console.WriteLine();


            Console.WriteLine("Отсортированный по убыванию массив: ");
            for (int i = 1; i < arr2poubiv.Length; i++)
            {
                arr2poubiv[i] = rnd.Next(arr2poubiv[i - 1] -20, arr2poubiv[i - 1] - 1);
                Console.Write(arr2poubiv[i]+" ");
            }

            int kswap1=0;
            int kswap2=0;
            int kswap3=0;
            int ksrv1=0;
            int ksrv2=0;
            int ksrv3=0;
            Console.WriteLine();
            Console.WriteLine("Сортировка подсчетом");
            countingSort(arrneup, arrneup.Min(), arrneup.Max(), ref  kswap1,ref  ksrv1);
            Console.WriteLine("\nНеотсортированный масив, количество пересылок={0},количество сравнений={1}", kswap1, ksrv1);
            countingSort(arr2povozr, arr2povozr.Min(), arr2povozr.Max(), ref kswap2, ref ksrv2);
            Console.WriteLine("\nОтсортированный по возрастанию масив, количество пересылок={0},количество сравнений={1}", kswap2, ksrv2);
            countingSort(arr2poubiv, arr2poubiv.Min(), arr2poubiv.Max(), ref kswap3, ref ksrv3);
            Console.WriteLine("\nОтсортированный по убыванию масив, количество пересылок={0},количество сравнений={1}", kswap3, ksrv3);
            Console.WriteLine("Пирамидальная сортировка");
            PSort(arrneupforp);





        }
    }
}
