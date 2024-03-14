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


        public static int[] AtkinSieveV1(int l)
        {
            var results = new List<int>
            {
                2,3,5
            };
            var sieve = new bool[l];
            for (var i = 0; i < sieve.Length; i++)
            {
                for (var j = 0; j < sieve.Length; j++)
                {
                    var n = 4 * i * i + j * j;
                    if (n <= l && (n % 12 == 1 || n % 12 == 5))
                    {
                        sieve[n] = true;
                    }
                    n = 3 * i * i + j * j;
                    if ((n <= l) && (n % 12 == 7))
                    {
                        sieve[n] = true;
                    }
                    n = 3 * i * i - j * j;
                    if (i > j && n <= l && n % 12 == 11)
                    {
                        sieve[n] = true;
                    }
                }
            }

            for (var i = 5; i * i < l; i++)
            {
                if (sieve[i])
                {
                    for (var j = i * i; j < l; j += i * i)
                    {
                        sieve[j] = false;
                    }
                }
            }

            for (var i = 5; i < l; i++)
            {
                if (sieve[i])
                {
                    results.Add(i);
                }
            }
            return results.ToArray();
        }

        public static int[] EratosthenesSieve(int l)
        {
            var nonPrimes = new bool[l];
            var primes = new List<int> { 2, 3 };
            for (var i = 2; i < l / 2; i++)
            {
                if (!nonPrimes[i])
                {
                    nonPrimes = FindMultiples(i, nonPrimes);
                }
            }
            for (var i = 4; i < nonPrimes.Length; i++)
            {
                if (!nonPrimes[i]) primes.Add(i);
            }
            return primes.ToArray();
        }

        public static bool[] FindMultiples(int m, bool[] nonPrimes)
        {
            for (var i = m * 2; i < nonPrimes.Length; i += m)
            {
                nonPrimes[i] = true;
            }
            return nonPrimes;
        }

        public static int[] Generate(int q)
        {
            var primes = new List<int>
            {
                2,3
            };
            var count = 3;
            do
            {
                count += 2;
                if (IsPrime(count))
                {
                    primes.Add(count);
                }
            } while (primes.Count < q);
            return primes.ToArray();
        }

        public static bool IsPrime(int v)
        {
            for (var i = 2; i <= Math.Sqrt(v); i++)
            {
                if (v % i == 0) return false;
            }
            return true;
        }
    }

}