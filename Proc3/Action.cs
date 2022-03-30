using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Proc3
{
    public class Action
    {
        private double[] a;
        private double[] b;
        private int K;
        public Action(double[] mas, int num)
        {
            a = mas;
            b = new double[a.Length];
            K = num;
        }
        public void DO(object MinMax)
        {
            int[] mas = MinMax as int[];
            int min = mas[0], max = mas[1];
            int count = 0;
            for (int i = min; i < max && i < a.Length; i++)
            {
                count++;
                for (int j = 0; j < K; j++) b[i] += Math.Pow(a[i], 1.789);
            }
        }
        public void SetMas(double[] mas) { a = mas; }
        public void SetNumOp(int num) { K = num; }
    }
}
