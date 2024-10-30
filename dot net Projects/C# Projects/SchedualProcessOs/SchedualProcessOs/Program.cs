using System;
using System.IO;
using SchedualProcessOs.Bl;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SchedualProcessOs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string jsonString = File.ReadAllText("processes.json");
            List<Processes> lstProcess = JsonConvert.DeserializeObject<List<Processes>>(jsonString);
            IShcedualProcess PricessAlgorithm = new ShortestProcess(lstProcess);
            
            int nTimeLineIndex = 0;
            Processes CurrentProcess = PricessAlgorithm.IncomingProcess();
            while (true)
            {
                if(CurrentProcess==null)
                {
                    if (PricessAlgorithm.MainProcess.Count > PricessAlgorithm.EndedProcess.Count)
                    {
                        Console.WriteLine("Ideal State Empty time line");
                        continue;
                    }
                        
                    else
                        break;
                }

                Console.WriteLine($"process name {CurrentProcess.ProcessName} Remain Busrt Time {CurrentProcess.RemainBurstTime}");
                CurrentProcess.RemainBurstTime--;

                if(CurrentProcess.RemainBurstTime==0)
                {
                    PricessAlgorithm.EndedProcess.Add(CurrentProcess);
                    if (PricessAlgorithm.WaitingProcess.Count > 0)
                        CurrentProcess = PricessAlgorithm.IncomingQueue(CurrentProcess);
                    else
                        CurrentProcess = null;
                }


                nTimeLineIndex++;
                CurrentProcess = PricessAlgorithm.IncomingProcess(CurrentProcess, nTimeLineIndex);

                if (PricessAlgorithm.WaitingProcess.Count > 0)
                {
                    CurrentProcess = PricessAlgorithm.IncomingQueue(CurrentProcess);
                }
            }
            Console.WriteLine("***********************************");
            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
