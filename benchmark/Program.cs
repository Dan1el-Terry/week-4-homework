using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using AlgoDS.Searching;
using System.Collections.Generic;
// BenchmarkRunner.Run<MyBenchmark>();
[MemoryDiagnoser] // Shows memory usage in benchmark results
[SimpleJob(iterationCount: 10)] // Runs 10 iterations

public class MyBenchmark
{

    private int[] dataArray;
    private List<int> dataList;

    private const int DataSize = 10000;

    [GlobalSetup]

    public void Setup()
    {
        var random = new Random(42);

        dataArray = new int[DataSize];
        for (int i = 0; i < DataSize; i++)
        {
            dataArray[i] = random.Next();
        }

        dataList = new List<int>(dataArray);
    }

    [Benchmark]
    public void Do()
    {
        AlgoDS.DataStructures.Queue q = new AlgoDS.DataStructures.Queue();
    }
    [Benchmark]
    public int[] ArraySort()
    {
        var cloned = (int[])dataArray.Clone();
        Array.Sort(cloned);
        return cloned;
    }

    [Benchmark]
    public List<int> ListSort()
    {
        var cloned = new List<int>(dataList);
        cloned.Sort();
        return cloned;
    }
    [Benchmark]
    public void TestLinearSearch() {
int result = LinearSearch.Searching(dataArray, 8); // you could select an item from the array and search for it instead of hardcoding a number as I’ve done here
}
    [Benchmark]
    public void TestBinarySearch(){
int result = BinarySearch.Searching(dataArray, 8);
    }

public class Program
{
    static void Main(string[] args)
    {
        // Test non-generic linear search
        int[] arr = { 4, 6, 8, 10 };
        int result = LinearSearch.Searching(arr, 8);  // Using non-generic version for int[]
        Console.WriteLine($"Found at index: {result}");

        // Test generic linear search
        string[] stringArr = { "apple", "banana", "cherry" };
        int genericResult = LinearSearch<string>.Searching(stringArr, "banana");  // Using generic version with string[]
        Console.WriteLine($"Found at index: {genericResult}");
        //Non-Gernic Binary Search
        int[] arr1 = { 1, 3, 5, 7, 9, 11, 13, 15 };
        int target = 13;
        int result1 = BinarySearch.Searching(arr1, target);
        Console.WriteLine(result1);  // Expected Output: 3 (index of 7)
        //Gernic Binary search
        string[] arr2 = { "apple", "banana", "blaad", "date", "elderberry", "fig", "grape" };
        string target1 = "blaad";  // This is the element we want to find
        int result2 = BinarySearch<string>.Searching(arr2, target1);  // Perform the binary search
        Console.WriteLine(result2);  // Expected Output: 2 (index of "cherry")
    }
}
}
