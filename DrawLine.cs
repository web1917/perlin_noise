using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perlin_noise
{
    class DrawLine
    {
        public void Draw(float[] f)
        {
            Console.Clear();
            int max_rows = max(f);
            int rows = 0;
            int cont = 0;
            int y = 0;
            while (true)
            {
                for (int i = 0; i < max_rows; i++)
                {
                    for (y = cont; y < f.Length; y++)
                    {
                        if (cont <= f.Length - 64)
                            if (rows <= 64)
                            {
                                if ((f[y] * 15 >= i) && (f[y] * 15 <= i + 1))
                                {
                                    rows++;
                                    Console.Write("+");
                                }
                                else
                                {
                                    rows++;
                                    Console.Write(" ");
                                }
                            }
                    }
                    rows = 0;
                    Console.WriteLine("");

                }
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(0);
                rows = 0;
                if (cont >= f.Length)
                    cont = 0;
                else
                    cont += 1;
            }
        }
        int max(float[] f)
        {
            int max = 0;
            foreach (float number in f)
            {
                if ((int)(number + 1) * 15 > max)
                    max = (int)(number + 1) * 15;
            }
            return max;

        }
    }
}
