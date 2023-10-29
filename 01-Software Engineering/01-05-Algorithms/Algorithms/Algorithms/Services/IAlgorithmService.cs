namespace Algorithms.Services;

public interface IAlgorithmService
{
    double CalcStandardDeviation(List<double> values);
    double CalcCorrelation(List<double> xValues, List<double> yValues);
    void MergeSort(int[] array, int start, int end);
    int BinarySearchAlgorithm(int[] array, int target);
    void SegregatePositiveAndNegativeNumbers(int[] array, int start, int end);
    List<int> GreedyActivitySelector(int[] startArr, int[] endArr);
    Dictionary<char, int> CharFreqAnyCodeMethod(string message);
}
