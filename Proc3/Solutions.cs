using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Proc3
{
    public class Solutions
    {
        private double[] a;
        private int K;
        public Solutions(int count, int countOP)
        {
            this.a = new double[count];
            CreateMassive();
            this.K = countOP;
        }
        private void CreateMassive()
        {
            Random random = new Random();
            for (int i = 0; i < a.Length; i++) a[i] = random.NextDouble()*100;
        }
        public void OneThreadSolution()
        {
            Action action = new Action(a,K);
            action.DO(new int[]{0 ,a.Length});
        }
        public void SolutionByMultipleThreads(int num)
        {
            Action action =  new Action(a, K);
            List<Thread> threads = new List<Thread>();
            int step = (int)Math.Ceiling((double)a.Length / num);
            for(int i=0;i<num;i++)
            {
                int min=step*i, max=step*(i+1);
                Thread thread = new Thread(new ParameterizedThreadStart(action.DO));
                threads.Add(thread);
                thread.Start(new int[] { min, max });
            }
            foreach (Thread nowThread in threads) nowThread.Join(); 
        }
    }
}
