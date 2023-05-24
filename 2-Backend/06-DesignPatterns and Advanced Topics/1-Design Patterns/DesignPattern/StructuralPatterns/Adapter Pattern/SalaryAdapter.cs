namespace DesignPattern.StructuralPatterns.Adapter_Pattern
{
    public class SalaryAdapter :SalaryCalculator
    {
         private Employee _emp;
         public double CalcSalary(MachineOperator _operator){
             _emp=new Employee();
             _emp.BasicSalary = _operator.BasicSalary;
            return base.CalcSalary(_emp);
         }
    }
}