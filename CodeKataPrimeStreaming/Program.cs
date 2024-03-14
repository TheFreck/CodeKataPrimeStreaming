using CodeKataPrimeStreaming;
using CokeKataPrimeStreaming;
using System.Diagnostics;


Console.WriteLine("How many prime numbers do you want to generate?");
var quantity = Console.ReadLine();
Console.WriteLine($"How many primes would you like to skip before taking {quantity}?");
var skips = Console.ReadLine();
var timer = new Stopwatch();
if (int.TryParse(quantity, out var qty) && int.TryParse(skips, out var skip))
{
    var primes = new Primes();
    timer.Start();
    var streamed = Primes.Stream().ToArray();
    var taken = streamed.Skip(skip).Take(qty).ToArray();
    timer.Stop();
    Console.WriteLine("Done: " + timer.ElapsedMilliseconds);

    Console.WriteLine("number of primes: ", taken.Length);
    for(var i=0; i<taken.Length; i++)
    {
        Console.WriteLine(taken[i]);
    }
    //var count = 0;
    //var continuate = true;
    //do
    //{
    //    var i = 0;
    //    for (i = count; i < Math.Min(primes.primes.Count,count+1000); i++)
    //    {
    //        Console.WriteLine(primes.primes[i]);
    //    }
    //    count = i;
    //    Console.WriteLine("Press enter to continue");
    //    var pause = Console.ReadLine();


    //    if (i >= qty) continuate = false;
    //} while (continuate);
}
else
{
    Console.WriteLine("That wasn't a number. Try again.");
}
var end = Console.ReadLine();
    Console.WriteLine(end);
