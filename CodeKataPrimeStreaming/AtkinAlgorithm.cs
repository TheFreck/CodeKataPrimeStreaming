﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKataPrimeStreaming
{
    public class AtkinAlgorithm : IEnumerable<ulong>
    {
        public readonly List<ulong> primes;
        private readonly ulong limit;

        public AtkinAlgorithm(ulong limit)
        {
            this.limit = limit;
            primes = new List<ulong>();
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            if (!primes.Any())
                FindPrimes();

            foreach (var p in primes)
                yield return p;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void FindPrimes()
        {
            var isPrime = new bool[limit + 1];
            var sqrt = Math.Sqrt(limit);

            for (ulong x = 1; x <= sqrt; x++)
                for (ulong y = 1; y <= sqrt; y++)
                {
                    var n = 4 * x * x + y * y;
                    if (n <= limit && (n % 12 == 1 || n % 12 == 5))
                        isPrime[n] ^= true;

                    n = 3 * x * x + y * y;
                    if (n <= limit && n % 12 == 7)
                        isPrime[n] ^= true;

                    n = 3 * x * x - y * y;
                    if (x > y && n <= limit && n % 12 == 11)
                        isPrime[n] ^= true;
                }

            for (ulong n = 5; n <= sqrt; n++)
                if (isPrime[n])
                {
                    var s = n * n;
                    for (ulong k = s; k <= limit; k += s)
                        isPrime[k] = false;
                }

            primes.Add(2);
            primes.Add(3);
            for (ulong n = 5; n <= limit; n += 2)
                if (isPrime[n])
                    primes.Add(n);
        }
    }
}
