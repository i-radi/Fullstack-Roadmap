namespace Algorithms.Services;

public interface IAlgorithmService
{
    double CalcStandardDeviation(List<double> values);
    double CalcCorrelation(List<double> xValues, List<double> yValues);
}
