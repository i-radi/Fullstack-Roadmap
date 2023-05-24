namespace Lab6
{
    abstract class Person
    {
        protected int Id;
        protected string Name;

        public Person()
        {
        }

        public Person(int id)
        {
            Id = id;
        }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }


        public void SetId(int id)
        {
            Id = id;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }
        
        public abstract void PrintData();
       
    }
}