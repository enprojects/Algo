using System;

namespace MergeSort
{

    // 
    class Program
    {
        static void Main(string[] args)
        {

            var arr = new int[] { 88, 99, 100 , 9, 10, 13};
            // var arr = new int[] { 5, 2, 7 };
            // MergeSort(arr, 0, arr.Length - 1);
            merge_sort(arr, 0, arr.Length - 1);

        }

        public static void merge_sort(int[] data, int left, int right)
        {

            var mid = left + (right - left) / 2;


            if (left < right)
            {
                 merge_sort(data, left, mid);
                 merge_sort(data, mid + 1, right);
                 DoMerge(data, left, mid, right);
            }

        }

        private static void DoMerge(int[] data, int left, int mid, int right)
        {
            int idxL = left, idxR = 0, idx = 0 , startPointData=left;

            var tempL = new int[mid - left+1];
            var tempR = new int[right - mid]; //+1

            for (int i = 0; i < tempL.Length; i++)
            {

                tempL[i] = data[startPointData++];
                 
            }

            for (int i = left; i < tempR.Length; i++)
            {
                tempR[i] = data[startPointData++];
            }



            while (idxL < tempL.Length && idxR < tempR.Length)
            {
                if (tempL[idxL] > tempR[idxR])
                {
                    data[idx] = tempR[idxR];
                    idx++;
                    idxR++;
                }
                else
                {
                    data[idx] = tempL[idxL++];
                    idx++;
                }
            }

            if (idxL == tempL.Length)
            {

                for (int i = idxR; i <= tempR.Length - 1; i++)
                {
                    data[idx++] = tempL[idxR];
                    idxR++;
                }

            }

            if (idxR == tempR.Length)
            {
                for (int i = idxL; i <= tempL.Length - 1; i++)
                {
                    data[idx++] = tempL[idxL];
                    idxL++;
                }
            }

        }

        // split the array in to left  and right 
        public static void MergeSort(int[] data, int left, int right)
        {
            if (left < right)
            {
                int m = left + (right - left) / 2;

                // left
             //   MergeSort(data, left, m);
                // right
            //    MergeSort(data, m + 1, right);
                Merge(data, left, m, right);
            }
        }

        private static void Merge(int[] data, int left, int mid, int right)
        {

            //var nLeft = mid - left;
            //var nRight = right - mid + 1;

            //var tempL = new int[nLeft];
            //var tempR = new int[nRight];

            //for (int i = 0; i < nLeft; i++)
            //{
            //    tempL[i] = data[i + nLeft];
            //}



            #region MyRegion

            int i, j, k;
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] L = new int[n1];
            int[] R = new int[n2];

            for (i = 0; i < n1; i++)
                L[i] = data[left + i];

            for (j = 0; j < n2; j++)
                R[j] = data[mid + 1 + j];

            i = 0;
            j = 0;
            k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    data[k] = L[i];
                    i++;
                }
                else
                {
                    data[k] = R[j];
                    j++;
                }

                k++;
            }

            while (i < n1)
            {
                data[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                data[k] = R[j];
                j++;
                k++;
            }
            #endregion
        }
    }

}
