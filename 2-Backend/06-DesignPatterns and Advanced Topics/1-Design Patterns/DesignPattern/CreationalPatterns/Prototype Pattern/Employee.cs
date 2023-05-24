namespace DesignPattern.CreationalPatterns.Prototype_Pattern
{
    public  class Employee:CloneablePrototype<Employee>
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public Address EmpAddress {get;set;}

        public override string ToString(){
            return 
            $@"
               Id: {this.Id}
               Name: {this.Name}
               Address: {this.EmpAddress.City},{this.EmpAddress.StreetName},{this.EmpAddress.Building}";
        }
    }
}