using System;

namespace Task1
{
    internal class QuickSort<T> where T : IComparable<T>
    {
        private static Random random = new Random();

        public static void Sort(T[] array, PivotChoice pivotChoice)
        {
            Sort(array, 0, array.Length - 1, pivotChoice);
        }

        private static void Sort(T[] array, int left, int right, PivotChoice pivotChoice)
        {
            if (left < right)
            {
                int partitionIndex = Partition(array, left, right, pivotChoice);
                Sort(array, left, partitionIndex - 1, pivotChoice);
                Sort(array, partitionIndex + 1, right, pivotChoice);
            }
        }

        private static int Partition(T[] array, int left, int right, PivotChoice pivotChoice)
        {
            int pivotIndex = ChoosePivotIndex(array, left, right, pivotChoice);
            T pivotValue = array[pivotIndex];
            Swap(array, pivotIndex, right);
            int partitionIndex = left;

            for (int i = left; i < right; i++)
            {
                if (array[i].CompareTo(pivotValue) <= 0)
                {
                    Swap(array, i, partitionIndex);
                    partitionIndex++;
                }
            }

            Swap(array, partitionIndex, right);
            return partitionIndex;
        }

        private static int ChoosePivotIndex(T[] array, int left, int right, PivotChoice pivotChoice)
        {
            switch (pivotChoice)
            {
                case PivotChoice.FirstElement:
                    return left;

                case PivotChoice.RandomElement:
                    return random.Next(left, right + 1);

                case PivotChoice.Median:
                    int middle = (left + right) / 2;
                    if (random.Next(0, 2) == 0)
                    {
                        Swap(array, left, middle);
                    }
                    else
                    {
                        Swap(array, right, middle);
                    }
                    return right;

                default:
                    throw new ArgumentException("Invalid pivot choice.");
            }
        }

        private static void Swap(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    enum PivotChoice
    {
        FirstElement,
        RandomElement,
        Median
    }
}
