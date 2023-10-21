namespace Algorithms.Services;

public class AlgorithmService : IAlgorithmService
{
    public double CalcCorrelation(List<double> xValues, List<double> yValues)
    {
        int n = xValues.Count();
        double xSum = xValues.Sum();
        double ySum = yValues.Sum();
        List<double> xyValues = xValues.Zip(yValues, (x, y) => x * y).ToList();
        List<double> xSquare = xValues.Select(x => x * x).ToList();
        List<double> ySquare = yValues.Select(y => y * y).ToList();

        double r = (n * xyValues.Sum() - xSum * ySum) 
                 / Math.Sqrt((n * xSquare.Sum() - Math.Pow(xSum,2)) 
                    * (n * ySquare.Sum() - Math.Pow(ySum, 2)));

        return r;
    }

    public double CalcStandardDeviation(List<double> values)
    {
        int n = values.Count();
        double avg = values.Average();
        double sum = 0;

        foreach (double value in values)
        {
            sum += Math.Pow(value - avg, 2);
        }

        double std = Math.Sqrt(sum / n);
        return std;
    }
}
