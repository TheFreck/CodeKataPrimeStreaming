using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CokeKataPrimeStreaming
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