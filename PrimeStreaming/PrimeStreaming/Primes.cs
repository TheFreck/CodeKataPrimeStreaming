using PrimeStreaming;
using System.Diagnostics;

namespace PrimeStreaming
{
    public class Primes
    {
        public List<int> primes;

        public Primes()
        {
            primes = new List<int>();
        }

        private void AtkinSieve(int m)
        {
            var primeBools = new bool[m + 1];
            var sqirt = Math.Sqrt(m);

            for (int x = 1; x <= sqirt; x++)
            {
                for (int y = 1; y <= sqirt; y++)
                {
                    int t = 4 * x * x + y * y;
                    int tee = 3 * x * x + y * y;
                    int tea = 3 * x * x - y * y;
                    if (t <= m && (t % 12 == 1 || t % 12 == 5))
                    {
                        primeBools[t] ^= true;
                    }
                    if (tee <= m && tee % 12 == 7)
                    {
                        primeBools[tee] ^= true;
                    }
                    if (tea <= m && x > y && tea % 12 == 11)
                    {
                        primeBools[tea] ^= true;
                    }
                }
            }
            for (int i = 5; i <= sqirt; i++)
            {
                if (primeBools[i])
                {
                    var g = i * i;
                    for (int j = g; j <= m; j += g)
                    {
                        primeBools[j] = false;
                    }
                }
            }
            primes.Add(2);
            primes.Add(3);
            for (int n = 5; n < m; n += 2)
            {
                if (primeBools[n]) primes.Add(n);
            }
        }

        public static IEnumerable<int> Stream()
        {
            var primer = new Primes();
            if (primer.primes.Count == 0) primer.AtkinSieve(10000000);
            if (primer.primes.Count == 0) yield return 0;

            foreach (var prime in primer.primes)
            {
                yield return prime;
            }
        }
    }
}

//﻿using CodeKataPrimeStreaming;
//using CokeKataPrimeStreaming;
//using System.Diagnostics;


//Console.WriteLine("How many prime numbers do you want to generate?");
//var quantity = Console.ReadLine();
//Console.WriteLine($"How many primes would you like to skip before taking {quantity}?");
//var skips = Console.ReadLine();
//var timer = new Stopwatch();
//if (int.TryParse(quantity, out var qty) && int.TryParse(skips, out var skip))
//{
//    var primes = new Primes();
//    timer.Start();
//    var streamed = Primes.Stream().ToArray();
//    var taken = streamed.Skip(skip).Take(qty).ToArray();
//    timer.Stop();
//    Console.WriteLine("Done: " + timer.ElapsedMilliseconds);

//    Console.WriteLine("number of primes: ", taken.Length);
//    for (var i = 0; i < taken.Length; i++)
//    {
//        Console.WriteLine(taken[i]);
//    }
//    //var count = 0;
//    //var continuate = true;
//    //do
//    //{
//    //    var i = 0;
//    //    for (i = count; i < Math.Min(primes.primes.Count,count+1000); i++)
//    //    {
//    //        Console.WriteLine(primes.primes[i]);
//    //    }
//    //    count = i;
//    //    Console.WriteLine("Press enter to continue");
//    //    var pause = Console.ReadLine();


//    //    if (i >= qty) continuate = false;
//    //} while (continuate);
//}
//else
//{
//    Console.WriteLine("That wasn't a number. Try again.");
//}
//var end = Console.ReadLine();
//Console.WriteLine(end);