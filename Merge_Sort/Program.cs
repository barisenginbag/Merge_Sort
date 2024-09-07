using System;

class Program
{
    static void Main()
    {
        int[] arr = { 16, 21, 11, 8, 12, 22 };

        Console.WriteLine("Orijinal Dizi: ");
        PrintArray(arr);

        // Merge Sort fonksiyonunu çağırıyoruz
        MergeSort(arr, 0, arr.Length - 1);

        Console.WriteLine("\nSıralanmış Dizi: ");
        PrintArray(arr);

        Console.ReadKey();
    }

    // Merge Sort fonksiyonu
    static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            // Sol yarıyı sırala
            MergeSort(array, left, middle);

            // Sağ yarıyı sırala
            MergeSort(array, middle + 1, right);

            // Sıralı iki yarıyı birleştir
            Merge(array, left, middle, right);
        }
    }

    // Birleştirme işlemi
    static void Merge(int[] array, int left, int middle, int right)
    {
        // Alt dizileri tanımla
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] LeftArray = new int[n1];
        int[] RightArray = new int[n2];

        // Sol yarıyı kopyala
        for (int i = 0; i < n1; i++)
            LeftArray[i] = array[left + i];

        // Sağ yarıyı kopyala
        for (int j = 0; j < n2; j++)
            RightArray[j] = array[middle + 1 + j];

        // Birleştirme süreci
        int k = left; // Birleşmiş dizi için başlangıç indeksi
        int a = 0, b = 0;

        while (a < n1 && b < n2)
        {
            if (LeftArray[a] <= RightArray[b])
            {
                array[k] = LeftArray[a];
                a++;
            }
            else
            {
                array[k] = RightArray[b];
                b++;
            }
            k++;
        }

        // Kalan elemanları kopyala
        while (a < n1)
        {
            array[k] = LeftArray[a];
            a++;
            k++;
        }

        while (b < n2)
        {
            array[k] = RightArray[b];
            b++;
            k++;
        }
    }

    // Diziyi yazdırma fonksiyonu
    static void PrintArray(int[] array)
    {
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
