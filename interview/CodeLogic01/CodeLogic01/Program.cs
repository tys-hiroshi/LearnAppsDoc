using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLogic01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var baseNumbers = new BaseNumbers(args);
                //http://jd-engineer.hateblo.jp/entry/2017/06/17/114824
                //n進数(x)からm進数に変換するコード
                var result = Convert(baseNumbers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private static double Convert(BaseNumbers baseNumbers)
        {
            double y = 0;
            int i = 0, z;
            while (baseNumbers.Value > 0)
            {
                z = baseNumbers.Value % baseNumbers.MNumbers;
                y += z * Math.Pow(baseNumbers.NNumbers, i);  //Math.Pow(n, i)とは、n^i(nをiで累乗した値)
                baseNumbers.Value = baseNumbers.Value / baseNumbers.MNumbers;
                i++;
            }

            return y;
        }

        public class BaseNumbers
        {
            public int Value { get; set; }
            public int NNumbers { get; set; }
            public int MNumbers { get; set; }

            public BaseNumbers(string[] args)
            {
                Value = int.Parse(args[0]);  //変換値(n進数)
                NNumbers = int.Parse(args[1]);  //n進数の指定
                MNumbers = int.Parse(args[2]);  //m進数の指定
            }
        }
    }
}
