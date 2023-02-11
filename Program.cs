using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadExample
{
    class Program
    {
        static int recursoCompartilhado = 0;
        static object lockObject = new();

        static void Main(string[] args)
        {
            #region Threads
            //Stopwatch stopwatch = new();

            //stopwatch.Start();

            //List<Thread> threads = new()
            //{
            //    new Thread(LavarLouca),
            //    new Thread(LavarRoupa),
            //    new Thread(FazerJanta)
            //};

            //Thread lavarLouca = new Thread(LavarLouca);
            //Thread lavarRoupa = new Thread(LavarRoupa);
            //Thread fazerJanta = new Thread(FazerJanta);

            //foreach(Thread t in threads)
            //{
            //    t.Start();
            //}

            //foreach (Thread t in threads)
            //{
            //    t.Join();
            //}

            //lavarLouca.Start();
            //lavarRoupa.Start();
            //fazerJanta.Start();

            //LavarLouca();
            //LavarRoupa();
            //FazerJanta();            

            //lavarLouca.Join();
            //lavarRoupa.Join();
            //fazerJanta.Join();

            //stopwatch.Stop();

            //Console.WriteLine($"Todo o processo durou: {stopwatch.ElapsedMilliseconds} ms");
            //Console.WriteLine($"Recurso compartilhado = {recursoCompartilhado}");
            //Console.ReadKey();
            #endregion

            #region Parallel

            List<string> files = new()
            {
                "vs.exe",
                "note.exe",
                "calc.exe",
                "word.exe"
            };

            Stopwatch stopwatch2 = new();
            stopwatch2.Start();

            //foreach(string file in files)
            //{
            //    DownloadFile(file);
            //}

            ParallelOptions op = new();
            op.MaxDegreeOfParallelism = 2;

            //Parallel.For(0, files.Count, i =>
            //{
            //    DownloadFile(files[i]);
            //});

            Parallel.ForEach(files, op, file =>
            {
                DownloadFile(file);
            });

            //Parallel.Invoke(op, () => DownloadFile("vs.exe"),
            //                    () => DownloadFile("note.exe"),
            //                    () => DownloadFile("calc.exe"),
            //                    () => DownloadFile("word.exe"));

            stopwatch2.Stop();

            Console.WriteLine($"Todo o processo durou: {stopwatch2.ElapsedMilliseconds} ms");

            #endregion
        }

        public static void DownloadFile(string file)
        {            
            Thread.Sleep(5000);
            Console.WriteLine($"Download done: {file} - ThreadId: {Thread.CurrentThread.ManagedThreadId}");
        }


        static void LavarLouca()
        {
            Console.WriteLine("Iniciando a lavagem da louça");

            lock (lockObject)
            {
                for (int i = 0; i < 10000000; i++) recursoCompartilhado++;
            }
            
            Thread.Sleep(2000);            
            Console.WriteLine("Finalizada a lavagem da louça");
        }

        static void LavarRoupa()
        {
            Console.WriteLine("Iniciando a lavagem da roupa");
            
            lock (lockObject)
            {
                for (int i = 0; i < 10000000; i++) recursoCompartilhado++;
            }
                
            Thread.Sleep(3000);            
            Console.WriteLine("Finalizada a lavagem da roupa");
        }

        static void FazerJanta()
        {
            Console.WriteLine("Iniciando a confecção do jantar");
            
            lock (lockObject)
            {
                for (int i = 0; i < 10000000; i++) recursoCompartilhado++;
            }
                
            Thread.Sleep(8000);            
            Console.WriteLine("Finalizada a confecção do jantar");
        }
    }
}
