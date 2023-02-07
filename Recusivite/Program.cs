using System;

namespace Recusivite
{

    //Đệ quy có nghĩa là một hàm tự gọi lại chính nó. Một hàm đệ quy gồm 2 phần:
    //Phần cơ sở: Điều kiện để thoát khỏi đệ quy.Nếu như không có phần này, hàm đệ quy sẽ thực hiện mãi mãi gây ra tràn bộ nhớ Stack.
    // Phần đệ quy: Thân hàm có chứa phần gọi đệ quy, thực hiện cho đến khi thỏa mãn điều kiện ở phần cơ sở.
    class Program
    {
        static void Main(string[] args)
        {
            count(5);

            Console.WriteLine("\n Somme de 1 à n: " + somme(4));
            Console.WriteLine("\n Factoriel n: " + factoriel(4));
            Console.WriteLine("\n Fibonacci n: " + fibonacci(8));

            Console.ReadKey();
        }

        public static void count(int i)
        {
            i++;

            if (i < 10)
            {
                Console.WriteLine("hello {0}", i);
                count(i);
            }
        }

        //Tính tổng các số từ 1 đến n.
        static int somme(int n)
        {
            if (n == 0)
                return 0;
            else
                return n + somme(n - 1);
        }

        //n = 5
        //5 + sum(4)
        //5 + 4 + sum(3)
        //5 + 4 + 3 + sum(2)
        //5 + 4 + 3 + 2 + sum(1)
        //5 + 4 + 3 + 2 + 1 + 0


        static int factoriel(int n)
        {
            if (n == 1)
                return 1;
            else
                return n * factoriel(n - 1);
        }

        //        Dãy Fibonacci là dãy vô hạn các số tự nhiên bắt đầu bằng hai phần tử 0 và 1, dãy được thiết lập theo quy tắc mỗi phần tử luôn bằng
        //tổng hai phần tử trước nó, ta có dãy Fibonacci sau: 0 1 1 2 3 5 8 13 21 34 55 …
        //            Dãy số Fibonacci 0 1 1 2 3 5 8 … …
        //                   Số thứ tự 1 2 3 4 5 6 7 … n
        //        Quy luật, ta nhận thấy số n sẽ là tổng của 2 chữ số đứng sau nó là(n-2) + (n-1).
        //Và ta biết chắc chắn rằng n1 = 0 và n2 = 1 là điều kiện dừng của dãy số.

        static int fibonacci(int n)
        {
            if (n <= 1) return n;
            else
                return fibonacci(n - 2) + fibonacci(n - 1);
       }


    }
}
