namespace Lab5;

public static class ExtentionDouble
{
    public static double ConvertToCelsius(this double fahrenheit)
        => Math.Round((fahrenheit - 32) / 1.8,2); 
}