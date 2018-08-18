using System;

namespace Sortings
{
    class Program
    {
        static void Main(string[] args)
        {
           //var arr = new int[] { 6, 100,9,1,2};
            // var arr = new int[] { 8, 2, 10, 5 };
              var arr = new int[] { 4 ,2, 100, 5 };
           // QuickSort(arr, 0, arr.Length-1);

             QuickSortRec(arr, 0, arr.Length-1);
            Print(arr);

            Console.ReadLine();
        }



        private static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }


        private static void QuickSortRec(int[] arr, int left, int right)
        {



            if (left < right)
            {
                int pivot = QuickSort(arr, left, right);
                QuickSortRec(arr, left, pivot - 1);
                QuickSortRec(arr, pivot + 1, right);
            }



        }
        //https://www.youtube.com/watch?v=cnzIChso3cc&index=3&list=PLknUvGhDFrfZ3gMz8oNPBSBvF-fiV1428&t=6s

       // 1 4 6 0 9 5 
       // c j+1 j+2 ...       
       // i
       // if 1> 0 increase i +1  and do swap between 4 and 0 numbers j=1 and j = 3
       // at the end swap between curssor and i 

        //1 quick sort merge, swap between the pivot value location ( idx=0  which select orbitary
        //usualy the edge of the array index 0 or index length)  with the smallest running idx (j) when iterate throgh array
        //2 before swaping the pivot location with j index increase the pivot cursor +1 and then do the swap,
        // at the end swap between cursor and i idex , now we no all the nuber at the right side of the pivot cursor is lower then the right side 

        // left lower , right greater then
        // this function return the index for the pivot
        private static int QuickSort(int[] arr, int left, int right)
        {


            int cursor = left;
            // var pivot = arr[0];
            var pivot = arr[left];

            for (int i = left; i < right; i++)
            {
                if (pivot >= arr[i+1] )
                {
                    cursor++;
                    Swap(arr, cursor, i+1);                    
                }
            }
            //swap between pivot and and pivot cursor
            Swap(arr, cursor, left);

            return cursor;
        }

    

        private static void Swap(int[] arr, int left, int right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }

        

    }
}
