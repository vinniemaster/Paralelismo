using Parallelismo.Service;
using Parallelismo.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using System;

namespace Parallelismo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ceps = new string[5];
            ceps[0] = "08542140";
            ceps[1] = "83708746";
            ceps[2] = "58801500";
            ceps[3] = "39801293";
            ceps[4] = "09910190";

            //var parallelOpt = new ParallelOptions();
            //parallelOpt.MaxDegreeOfParallelism = 8;

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var listaCepReturnP = new List<Address>();

            Parallel.ForEach(ceps,  cep =>
            {
                listaCepReturnP.Add(new Correios().GetCEP(cep));
            });

            stopWatch.Stop();

            Console.WriteLine($"O Tempo total em processamento paralelo é de {stopWatch.ElapsedMilliseconds} ms");

            listaCepReturnP.ToList().ForEach(cep => Console.WriteLine(cep));

            Console.WriteLine($"\n\n");

            stopWatch.Start();

            var listaCepReturnS = new List<Address>();
            foreach (var cep in ceps)
            {
                listaCepReturnS.Add(new Correios().GetCEP(cep));
            }

            stopWatch.Stop();

            Console.WriteLine($"O Tempo total em processamento sequencial é de {stopWatch.ElapsedMilliseconds} ms");
            listaCepReturnS.ToList().ForEach(cep => Console.WriteLine(cep));

            

        }
    }
}