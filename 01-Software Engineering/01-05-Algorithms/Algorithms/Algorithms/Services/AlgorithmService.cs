namespace Algorithms.Services;

public class AlgorithmService : IAlgorithmService
{
    public double CalcCorrelation(List<double> xValues, List<double> yValues)
    {
        if (xValues.Count != yValues.Count)
        {
            throw new ArgumentException("Input lists must have the same number of elements.");
        }

        int n = xValues.Count;
        double xSum = xValues.Sum();
        double ySum = yValues.Sum();

        double xySum = xValues.Zip(yValues, (x, y) => x * y).Sum();
        double xSquareSum = xValues.Sum(x => x * x);
        double ySquareSum = yValues.Sum(y => y * y);

        double correlation = (n * xySum - xSum * ySum) /
                            Math.Sqrt((n * xSquareSum - xSum * xSum) *
                                      (n * ySquareSum - ySum * ySum));

        return Math.Round(correlation, 4);
    }

    public double CalcStandardDeviation(List<double> values)
    {
        if (values == null || values.Count == 0)
        {
            throw new ArgumentException("Input list must not be empty.");
        }

        int n = values.Count;
        double average = values.Average();
        double sumOfSquares = values.Sum(value => Math.Pow(value - average, 2));

        double standardDeviation = Math.Sqrt(sumOfSquares / n);
        return Math.Round(standardDeviation, 4);
    }

    public void MergeSort(int[] array, int start, int end)
    {
        if (end <= start) return;

        int midpoint = (end + start) / 2;
        MergeSort(array, start, midpoint);
        MergeSort(array, midpoint + 1, end);
        Merge(array, start, midpoint, end);
    }

    private static void Merge(int[] array, int start, int midpoint, int end)
    {
        int i, j, k;
        int left_length = midpoint - start + 1;
        int right_length = end - midpoint;

        int[] left_array = new int[left_length];
        int[] right_array = new int[right_length];

        for (i = 0; i < left_length; i++)
        {
            left_array[i] = array[start + i];
        }
        for (j = 0; j < right_length; j++)
        {
            right_array[j] = array[midpoint + 1 + j];
        }

        i = 0;
        j = 0;
        k = start;
        while (i < left_length && j < right_length)
        {
            if (left_array[i] <= right_array[j])
            {
                array[k] = left_array[i];
                i++;
            }
            else
            {
                array[k] = right_array[j];
                j++;
            }
            k++;
        }

        while (i < left_length)
        {
            array[k] = left_array[i];
            i++;
            k++;
        }
        while (j < right_length)
        {
            array[k] = right_array[j];
            j++;
            k++;
        }
    }

    public int BinarySearchAlgorithm(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == target)
            {
                return mid;
            }

            if (array[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }

}
