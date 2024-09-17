using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int[] array1 = { 5, 1, 4, 3, 2 };
        int[] array2 = { 5, 1, 4, 3, 2 };

        int[] largeArray1 = { 1, 2, 12, 6, 3, 4, 9, 11, 5, 8, 7, 10, 13, 15, 14 };
        int[] largeArray2 = { 1, 2, 12, 6, 3, 4, 9, 11, 5, 8, 7, 10, 13, 15, 14 };

        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine("Bubble Sort (array pequeño):");
        stopwatch.Start();
        BubbleSort(array1);
        stopwatch.Stop();
        Console.WriteLine($"BubbleSort Ticks (array pequeño): {stopwatch.ElapsedTicks}\n");

        Console.WriteLine("Selection Sort (array pequeño):");
        stopwatch.Restart();
        SelectionSort(array2);
        stopwatch.Stop();
        Console.WriteLine($"SelectionSort Ticks (array pequeño): {stopwatch.ElapsedTicks}\n");

        Console.WriteLine("Bubble Sort (array grande):");
        stopwatch.Restart();
        BubbleSort(largeArray1);
        stopwatch.Stop();
        Console.WriteLine($"BubbleSort Ticks (array grande): {stopwatch.ElapsedTicks}\n");

        Console.WriteLine("Selection Sort (array grande):");
        stopwatch.Restart();
        SelectionSort(largeArray2);
        stopwatch.Stop();
        Console.WriteLine($"SelectionSort Ticks (array grande): {stopwatch.ElapsedTicks}\n");

        Console.WriteLine("Ambos ordenamientos han terminado.\n");

        Console.WriteLine("---- High Score Ordenamiento ----\n");
        HighScoreOrdenamiento();
    }

    static void BubbleSort(int[] array)
    {
        int n = array.Length;
        int stepCount = 0;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
                PrintArray(array);
                stepCount++;
            }
        }
        Console.WriteLine($"Bubble Sort terminó en {stepCount} pasos.");
    }


    static void SelectionSort(int[] array)
    {
        int n = array.Length;
        int stepCount = 0;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
            PrintArray(array);
            stepCount++;
        }
        Console.WriteLine($"Selection Sort terminó en {stepCount} pasos.");
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    // Ordenamientos intermedios (High Score en Unity)
    static void HighScoreOrdenamiento()
    {
        Jugador[] jugadores = new Jugador[10];
        Random rnd = new Random();

        for (int i = 0; i < jugadores.Length; i++)
        {
            jugadores[i] = new Jugador
            {
                Nombre = "Jugador" + (i + 1),
                Matados = rnd.Next(0, 20),
                Asistencias = rnd.Next(0, 20),
                Muertes = rnd.Next(0, 20)
            };
            jugadores[i].CalcularScore();
        }

        Console.WriteLine("Jugadores antes de ordenar (por Score):");
        PrintJugadores(jugadores);

        BubbleSortJugadoresPorScore(jugadores);

        Console.WriteLine("\nJugadores después de ordenar (por Score):");
        PrintJugadores(jugadores);
    }
    static void BubbleSortJugadoresPorScore(Jugador[] jugadores)
    {
        int n = jugadores.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (jugadores[j].Score < jugadores[j + 1].Score)
                {
                    Jugador temp = jugadores[j];
                    jugadores[j] = jugadores[j + 1];
                    jugadores[j + 1] = temp;
                }
            }
        }
    }

    static void PrintJugadores(Jugador[] jugadores)
    {
        foreach (var jugador in jugadores)
        {
            Console.WriteLine($"{jugador.Nombre} - Matados: {jugador.Matados}, Asistencias: {jugador.Asistencias}, Muertes: {jugador.Muertes}, Score: {jugador.Score}");
        }
    }
}

class Jugador
{
    public string Nombre { get; set; }
    public int Matados { get; set; }
    public int Asistencias { get; set; }
    public int Muertes { get; set; }
    public int Score { get; set; }

    public void CalcularScore()
    {
        Score = (Matados * 3) + (Asistencias * 1) - (Muertes * 1);
    }
}
