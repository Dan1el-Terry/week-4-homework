namespace AlgoDS.DataStructures
{

    public class LinkedList { }
    public class Stack { }
    public class Queue { }
    public class HashTable { }

    public class LinkedList<T> { }
    public class Stack<T> { }
    public class Queue<T> { }
    public class HashTable<K, V> { }


}

namespace AlgoDS.Sorting
{
    public class QuickSort { }
    public class QuickSort<T> { }

}

namespace AlgoDS.Searching
{
    // Non-generic LinearSearch (for int[])
    public class LinearSearch
    {
        public static int Searching(int[] arr, int key)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == key) return i;
            }
            return -1;
        }
    }

    // Non-generic BinarySearch (for int[])
    public class BinarySearch
    {
        public static int Searching(int[] arr, int key)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == key) return mid;
                if (arr[mid] < key) left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }
    }

    // Generic LinearSearch (for T[])
    public class LinearSearch<T> where T : IEquatable<T>
    {
        public static int Searching(T[] arr, T key)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(key))
                {
                    return i;
                }
            }
            return -1;
        }
    }

    // Generic BinarySearch (for T[])
    public class BinarySearch<T> where T : IComparable<T>
    {
        public static int Searching(T[] arr, T key)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = arr[mid].CompareTo(key);
                if (comparison == 0) return mid;
                if (comparison < 0) left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }
    }
}
namespace AlgoDS.payments
{
     public interface IPaymentMethod
    {
        void Pay(decimal amount);
    }

     public class CreditCardPayment : IPaymentMethod
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Credit Card.");
        }
    }

    public class PaypalPayment : IPaymentMethod
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using PayPal.");
        }
    }

    public class ReceiptSender
    {
        public void SendReceipt(string recipient, decimal amount)
        {
            Console.WriteLine($"Receipt sent to {recipient} for {amount}");
        }
    }

    // Generic ReceiptSender
    public class ReceiptSender<T>
    {
        public void SendReceipt(T recipient, decimal amount)
        {
            Console.WriteLine($"Receipt sent to {recipient} for {amount}");
        }
    }

    public class Receipt
    {
        public string Recipient { get; set; }
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return $"Receipt for {Recipient}: {Amount:C}";
        }
    } 
public class SortedCollection<T> where T : IComparable<T>
{
    private List<T> items = new List<T>();
    public void AddItem(T item)
    {
        items.Add(item);
        items.Sort();
    }
    public void PrintAll()
    {
        foreach(var item in items) Console.WriteLine(item);
    }
}
}
