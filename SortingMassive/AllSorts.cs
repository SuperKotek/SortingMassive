using System;

public static class SortingAlgorithms
{
    // Генерация массивов
    public static int[] GenerateIntArray(int size, int min, int max)
    {
        Random rnd = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
            arr[i] = rnd.Next(min, max + 1);
        return arr;
    }

    public static int[] GenerateN2Array(int size)
    {
        Random rnd = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
            arr[i] = rnd.Next(1, 3); // 1 или 2
        return arr;
    }

    public static char[] GenerateFlagArray(int size)
    {
        char[] colors = { 'W', 'B', 'R' };
        Random rnd = new Random();
        char[] arr = new char[size];
        for (int i = 0; i < size; i++)
            arr[i] = colors[rnd.Next(0, 3)];
        return arr;
    }

    public static char[] GenerateHogwartsArray(int size)
    {
        char[] houses = { 'G', 'H', 'R', 'S' };
        Random rnd = new Random();
        char[] arr = new char[size];
        for (int i = 0; i < size; i++)
            arr[i] = houses[rnd.Next(0, 4)];
        return arr;
    }

    // Основные сортировки
    public static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
            for (int j = 0; j < arr.Length - i - 1; j++)
                if (arr[j] > arr[j + 1])
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
    }

    public static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }

    public static void MergeSort(int[] arr)
    {
        if (arr.Length <= 1) return;
        
        int mid = arr.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[arr.Length - mid];
        
        Array.Copy(arr, 0, left, 0, mid);
        Array.Copy(arr, mid, right, 0, arr.Length - mid);
        
        MergeSort(left);
        MergeSort(right);
        Merge(arr, left, right);
    }

    private static void Merge(int[] arr, int[] left, int[] right)
    {
        int i = 0, l = 0, r = 0;
        while (l < left.Length && r < right.Length)
            arr[i++] = left[l] < right[r] ? left[l++] : right[r++];
        while (l < left.Length) arr[i++] = left[l++];
        while (r < right.Length) arr[i++] = right[r++];
    }

    public static void QuickSort(int[] arr)
    {
        QuickSort(arr, 0, arr.Length - 1);
    }

    private static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
            if (arr[j] < pivot)
                (arr[++i], arr[j]) = (arr[j], arr[i]);
        (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
        return i + 1;
    }

    // Специальные сортировки
    public static void SortN2(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;
    
        while (left <= right)
        {
            if (arr[left] == 1)
            {
                left++;
            }
            else
            {
                
                (arr[left], arr[right]) = (arr[right], arr[left]);
                right--;
            }
        }
    }

    public static void SortFlag(char[] arr)
    {
        int low = 0;
        int mid = 0;
        int high = arr.Length - 1;
    
        while (mid <= high)
        {
            switch (arr[mid])
            {
                case 'W':
                    (arr[low], arr[mid]) = (arr[mid], arr[low]);
                    low++;
                    mid++;
                    break;
                case 'B':
                    mid++;
                    break;
                case 'R':
                    (arr[mid], arr[high]) = (arr[high], arr[mid]);
                    high--;
                    break;
            }
        }
    }

    public static void SortHogwarts(char[] arr)
    {
        int[] counts = new int[4]; // G,H,R,S
        foreach (char c in arr)
            counts[c switch { 'G' => 0, 'H' => 1, 'R' => 2, 'S' => 3 }]++;
        
        int i = 0;
        for (int j = 0; j < counts[0]; j++) arr[i++] = 'G';
        for (int j = 0; j < counts[1]; j++) arr[i++] = 'H';
        for (int j = 0; j < counts[2]; j++) arr[i++] = 'R';
        for (int j = 0; j < counts[3]; j++) arr[i++] = 'S';
    }

    // Утилиты
    public static string ArrayToString<T>(T[] arr) => string.Join(", ", arr);

}