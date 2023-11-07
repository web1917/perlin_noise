using System;
using System.Text;
using System.Threading;

Console.WriteLine("Hello, World! This is Perlin Noise 1D");
Perlin1D perlin1D = new Perlin1D();
DrawLine drawLine = new DrawLine();
drawLine.Draw(perlin1D.perlin());


class Perlin1D
{
    int int_part = 128;
    int float_part = 6;
   public float[] perlin()
    {
        Random rnd = new Random();
        double rnd_numeric = 0;
        List<float> perlin1d = new List<float>();
        List<float> list = new List<float>();
        float numeric = 0;
        for (int i = 0; i < int_part; i++)
        {
            perlin1d.Add((float)rnd.NextDouble()*1.5f);
        }
        numeric = Noise(perlin1d[0], perlin1d[1], perlin1d[int_part-1]);
        list.Add(numeric);
        for (int i = 1; i < int_part-1; i++)
        {
            numeric = Noise(list[i-1], perlin1d[i + 1], perlin1d[i]);
            list.Add(perlin1d[i]);
            list.Add(numeric);
        }
        numeric = Noise(perlin1d[int_part - 2], perlin1d[int_part - 1], perlin1d[0]);
        list.Add(numeric);
        
        for (int part = 0; part < float_part; part++)
        {
            perlin1d = list;
            list = new List<float>();
            numeric = Noise(perlin1d[0], perlin1d[1], perlin1d[int_part - 1]);
            list.Add(numeric);
            for (int i = 0; i < perlin1d.Count - 1; i++)
            {
                if (i == 0)
                    i = 1;
                numeric = Noise(list[i - 1], perlin1d[i + 1], perlin1d[i]);
                list.Add(numeric);
            }
            numeric = Noise(perlin1d[int_part - 2], perlin1d[int_part - 1], perlin1d[0]);
            list.Add(numeric);
        }
        return list.ToArray();
    }
    float Noise(float a, float b ,float t)
    {
        t = 0.5f;
          return a * t + b * t;

    }
}

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
                    if (rows < 65)
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

            Thread.Sleep(50);
            Console.Clear();
            rows = 0;
          
            if (cont >= f.Length)
                cont = 0;
            else
                cont +=1;
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