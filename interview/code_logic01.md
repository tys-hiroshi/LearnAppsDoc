# 課題

## コーディングロジック問題

以下のC# のコードで何をしているか説明して下さい。

### コード

```csharp
using System;

namespace CodeLogic01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var baseNumbers = new BaseNumbers(args);
                var result = Convert(baseNumbers);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        internal static double Convert(BaseNumbers baseNumbers)
        {
            double y = 0;
            int i = 0, z;
            while (baseNumbers.Value > 0)
            {
                z = baseNumbers.Value % baseNumbers.NNumbers;
                y += z * Math.Pow(10, i);  //Math.Pow(n, i)とは、n^i(nをiで累乗した値)
                baseNumbers.Value = baseNumbers.Value / baseNumbers.NNumbers;
                i++;
            }

            return y;
        }

        public class BaseNumbers
        {
            public int Value { get; set; }
            public int NNumbers { get; set; }

            public BaseNumbers(string[] args)
            {
                Value = int.Parse(args[0]);
                NNumbers = int.Parse(args[1]);
            }
        }
    }
}
```

### 実行例

```
> CodeLogic01.exe 10 2

> CodeLogic01.exe 13 2

> CodeLogic01.exe 3 3

> CodeLogic01.exe 14 3
```
