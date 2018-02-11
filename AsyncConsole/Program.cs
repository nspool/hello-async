using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace AsyncConsole
{
    class Program
    {
        /// <summary>
        /// This class demonstrates await.
        /// </summary>
        static async Task DoSomethingAsync()
        {
            int val = 10;

            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            Trace.WriteLine(val.ToString());

            val *= 2;

            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            Trace.WriteLine(val.ToString());
        }


        /// <summary>
        /// Takes an IObservable<string> as its parameter. 
        /// Subject<string> implements this interface.
        /// (from http://www.introtorx.com/Content/v1.0.10621.0/03_LifetimeManagement.html)
        /// </summary>
        static void WriteSequenceToConsole(IObservable<int> sequence)
        {
            // sequence.Subscribe(Console.WriteLine);
            sequence.Subscribe(value => Trace.WriteLine(value));

        }

        /// <summary>
        /// Entry point for the program
        /// </summary>
        static void Main(string[] args)
        {
            Task doSomethingTask = DoSomethingAsync();

            // Block synchronously
            doSomethingTask.Wait();

            var subject = new Subject<int>();
            WriteSequenceToConsole(subject);
            subject.OnNext(1);
            subject.OnNext(2);
            subject.OnNext(3);
        }


    }
}
