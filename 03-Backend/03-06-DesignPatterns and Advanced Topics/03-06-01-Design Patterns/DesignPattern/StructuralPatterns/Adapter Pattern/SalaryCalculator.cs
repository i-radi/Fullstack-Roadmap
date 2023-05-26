namespace DesignPattern.StructuralPatterns.Adapter_Pattern
{
    public class SalaryCalculator
    {
        public double CalcSalary(Employee emp ) => emp.BasicSalary * 1.2;
    }
}