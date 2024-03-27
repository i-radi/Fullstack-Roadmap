using Algorithms.Helpers.DynamicProgramming;
using Microsoft.OpenApi.Validations;
using System.Collections;

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

    public void SegregatePositiveAndNegativeNumbers(int[] array, int start, int end)
    {
        if (end <= start) return;

        int mid = (end + start) / 2;
        SegregatePositiveAndNegativeNumbers(array, start, mid);
        SegregatePositiveAndNegativeNumbers(array, mid + 1, end);
        MergePositiveAndNegativeNumbers(array, start, mid, end);

    }

    public static void MergePositiveAndNegativeNumbers(int[] array, int start, int mid, int end)
    {
        int i, j, k;
        int left_length = mid - start + 1;
        int right_length = end - mid;

        int[] left_array = new int[left_length];
        int[] right_array = new int[right_length];

        for (i = 0; i < left_length; i++)
        {
            left_array[i] = array[start + i];
        }
        for (j = 0; j < right_length; j++)
        {
            right_array[j] = array[mid + 1 + j];
        }

        i = 0;
        j = 0;
        k = start;

        while (i < left_length && left_array[i] <= 0)
        {
            array[k] = left_array[i];
            i++;
            k++;
        }
        while (j < right_length && right_array[j] <= 0)
        {
            array[k] = right_array[j];
            j++;
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

    public List<int> GreedyActivitySelector(int[] startArr, int[] endArr)
    {
        List<int> results = new List<int> { 0 };
        int j = 1;

        for (int i = 0; i < startArr.Length; i++)
        {
            if (startArr[i] >= endArr[j])
            {
                results.Add(i);
                j = i;
            }
        }
        return results;
    }

    #region Char. Freq.

    public Dictionary<char, int> CharFreqAnyCodeMethod(string message)
    {
        Hashtable freq = new Hashtable();

        for (int i = 0; i < message.Length; i++)
        {

            if (freq[message[i]] == null)
            {
                freq[message[i]] = 1;
            }
            else
            {
                freq[message[i]] = (int)freq[message[i]] + 1;
            }
        }

        Dictionary<char, int> freqDictionary = new Dictionary<char, int>();
        int[,] freqSorted = SortHash(freq);
        for (int i = 0; i < freqSorted.GetLength(0); i++)
        {
            freqDictionary.Add((char)freqSorted[i, 0], freqSorted[i, 1]);
        }
        return freqDictionary;
    }

    public int[,] SortHash(Hashtable freq)
    {
        int[,] freqArray = new int[freq.Count, 2];

        int i = 0;
        foreach (char k in freq.Keys)
        {
            freqArray[i, 0] = (int)k;
            freqArray[i, 1] = (int)freq[k];
            i++;
        }

        this.MergeSort(freqArray, 0, freq.Count - 1);

        return freqArray;

    }

    public void MergeSort(int[,] array, int start, int end)
    {
        if (end <= start) return;

        int midpoint = (end + start) / 2;
        MergeSort(array, start, midpoint);
        MergeSort(array, midpoint + 1, end);
        merge(array, start, midpoint, end);
    }

    public void merge(int[,] array, int start, int mid, int end)
    {
        int i, j, k;
        int left_length = mid - start + 1;
        int right_length = end - mid;

        int[,] left_array = new int[left_length, 2];
        int[,] right_array = new int[right_length, 2];

        for (i = 0; i < left_length; i++)
        {
            left_array[i, 0] = array[start + i, 0];
            left_array[i, 1] = array[start + i, 1];
        }
        for (j = 0; j < right_length; j++)
        {
            right_array[j, 0] = array[mid + 1 + j, 0];
            right_array[j, 1] = array[mid + 1 + j, 1];
        }

        i = 0;
        j = 0;
        k = start;
        while (i < left_length && j < right_length)
        {
            if (left_array[i, 1] <= right_array[j, 1])
            {
                array[k, 0] = left_array[i, 0];
                array[k, 1] = left_array[i, 1];
                i++;
            }
            else
            {
                array[k, 0] = right_array[j, 0];
                array[k, 1] = right_array[j, 1];
                j++;
            }
            k++;
        }
        while (i < left_length)
        {
            array[k, 0] = left_array[i, 0];
            array[k, 1] = left_array[i, 1];
            i++;
            k++;
        }
        while (j < right_length)
        {
            array[k, 0] = right_array[j, 0];
            array[k, 1] = right_array[j, 1];
            j++;
            k++;
        }

    }

    #endregion

    #region Dynamic Programming

    public (string MinimumCost, string MinimumPath) StagecoachProblem(string[] labels, int[][] data)
    {
        int n = data.Length;
        var states = new State[n];
        states[n - 1] = new State { From = "", To = "", Cost = 0 };

        for (int i = n - 2; i >= 0; i--)
        {
            states[i] = new State { From = labels[i], To = labels[0], Cost = int.MaxValue };
            for (int j = i + 1; j < n; j++)
            {
                if (data[i][j] == 0) continue;

                int newCost = data[i][j] + states[j].Cost;

                if (newCost < states[i].Cost)
                {
                    states[i].To = labels[j];
                    states[i].Cost = newCost;
                }
            }
        }

        var minCost = "Minimum Cost: " + states[0].Cost;

        List<string> path = new List<string> { "A" };
        int y = 0;
        int z = 0;
        while (y < states.Length)
        {
            if (states[y].From == path[z])
            {
                path.Add(states[y].To);
                z++;
            }
            y++;
        }

        var minPath = "Minimum path: " + string.Join(" -> ", path);
        return (minCost, minPath);
    }
    #endregion
}
