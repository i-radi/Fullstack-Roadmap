using System;

namespace Lab6
{
    class Customer : Person
    {
        public Customer()
        {
        }
        private int AcountNumber;


        public Customer(int id, string name) : base(id, name)
        {
        }

        public Customer(int id, string name, int acountNumber) : base(id, name)
        {
            AcountNumber = acountNumber;
        }


        public void SetId(int id)
        {
            Id = id;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetAcountNumber(int acountNumber)
        {
            AcountNumber = acountNumber;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        public float GetAcountNumber()
        {
            return AcountNumber;
        }
        public override void PrintData()
        {
            Console.WriteLine($"\tCustomer Data\n" +
                              $"Id : {Id} , Name : {Name} , Acount Number : {AcountNumber}");
        }
    }
}