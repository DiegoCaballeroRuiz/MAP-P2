namespace AlgsDeOrdenación
{
    internal class Program
    {
        const int N = 100;
        const int min = 0;
        const int max = 10;

        static Random rnd = new Random();

        static void Main()
        {
            int[] v = VectorAleatorio();
            //int[] v = VectorOrdenado();
            //int[] v = VectorDesordenado();

            //Debug(v);

            Compara(v);
        }

        static void OrdenaInsercion(int[] v)
        {
            for (int i = 1; i < v.Length; i++)
            {
                int temp = v[i];
                int j = i - 1;
                while (j >= 0 && v[j] > temp)
                {
                    v[j+1] = v[j];
                    j--;
                }
                v[j + 1] = temp;
            }
        }

        static void OrdenaSeleccion(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                int min = i;
                for (int j = i; j < v.Length; j++)
                {
                    if (v[j] < v[min]) min = j;
                }
                Swap(ref v[i], ref v[min]);
            }
        }

        static void OrdenaDobleSeleccion(int[] v)
        {
            for (int i = 0; i < v.Length/ 2; i++)
            {
                int min = i;
                int max = i;
                for (int j = i; j < v.Length - i; j++)
                {
                    if (v[j] < v[min]) min = j;
                    else if (v[j] > v[max]) max = j;
                }
                Swap(ref v[i], ref v[min]);
                if (max == i) max = min;
                Swap(ref v[v.Length - 1 - i], ref v[max]);
            }
        }

        static void OrdenaBurbujaMejorado(int[] v)
        {
            bool cont = true;
            int i = 0;
            while (i < v.Length - i && cont)
            {
                cont = false;
                for (int j = i + 1; j < v.Length; j++)
                {
                    if (v[j] < v[j - 1])
                    {
                        Swap(ref v[j], ref v[j - 1]);
                        cont = true;
                    }
                }
            }
        }

        static void OrdenaPalomar(int[] v)
        {
            int max = v[0];
            int min = v[0];
            for (int i = 1; i < v.Length; i++)
            {
                if (v[i] > max) max = v[i];
                else if (v[i] < min) min = v[i];
            }

            int[] t = new int[(max - min) + 1];

            for (int i = 0; i < t.Length; i++) t[i] = 0;

            for (int i = 0; i < v.Length; i++) t[v[i]]++;

            int posLibre = 0;
            for (int i = 0; i < t.Length; i++)
            {
                for(int j = t[i]; j > 0; j--)
                {
                    v[posLibre] = i;
                    posLibre++;
                }
            }
        }

        static void EscribeVector(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write($"{v[i]} ");
            }
        }

        static void Compara(int[] v)
        {
            //Burbuja
            int[] w = (int[])v.Clone();

            TimeSpan start = new TimeSpan(DateTime.Now.Ticks);
            OrdenaBurbujaMejorado(v);
            TimeSpan end = new TimeSpan(DateTime.Now.Ticks);

            double elapsed = end.Subtract(start).TotalMilliseconds;
            Console.WriteLine($"Burbuja: {elapsed}");

            //Inserción
            w = (int[])v.Clone();

            start = new TimeSpan(DateTime.Now.Ticks);
            OrdenaInsercion(v);
            end = new TimeSpan(DateTime.Now.Ticks);

            elapsed = end.Subtract(start).TotalMilliseconds;
            Console.WriteLine($"Inserción: {elapsed}");

            //Selección
            w = (int[])v.Clone();

            start = new TimeSpan(DateTime.Now.Ticks);
            OrdenaSeleccion(v);
            end = new TimeSpan(DateTime.Now.Ticks);

            elapsed = end.Subtract(start).TotalMilliseconds;
            Console.WriteLine($"Selección: {elapsed}");

            //Doble selección
            w = (int[])v.Clone();

            start = new TimeSpan(DateTime.Now.Ticks);
            OrdenaDobleSeleccion(v);
            end = new TimeSpan(DateTime.Now.Ticks);

            elapsed = end.Subtract(start).TotalMilliseconds;
            Console.WriteLine($"Doble seleccion: {elapsed}");

            //Palomar
            w = (int[])v.Clone();

            start = new TimeSpan(DateTime.Now.Ticks);
            OrdenaPalomar(v);
            end = new TimeSpan(DateTime.Now.Ticks);

            elapsed = end.Subtract(start).TotalMilliseconds;
            Console.WriteLine($"Palomar: {elapsed}");
        }

        static void Debug(int[] v)
        {
            Console.WriteLine("Vector desordenado: ");
            EscribeVector(v);

            OrdenaDobleSeleccion(v);

            Console.WriteLine("\nVector ordenado: ");
            EscribeVector(v);
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a; 
            a = b; 
            b = temp;
        }

        static int[] VectorAleatorio()
        {
            int[] v = new int[N];
            for (int i = 0; i < N; i++)
            {
                v[i] = rnd.Next(min, max + 1);
            }
            return v;
        }

        static int[] VectorOrdenado()
        {
            int[] v = new int[N];
            for (int i = 0; i < N; i++)
            {
                v[i] = i;
            }
            return v;
        }

        static int[] VectorDesordenado()
        {
            int[] v = new int[N];
            for (int i = 0; i < N; i++)
            {
                v[i] = max - i;
            }
            return v;
        }
    }
}