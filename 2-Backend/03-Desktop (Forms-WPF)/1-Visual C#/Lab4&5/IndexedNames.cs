namespace Lab5;

class IndexedNames
{
    private string[] namelist;
    public int Size { get; private set; }

    public IndexedNames(int s)
    {
        Size = s;
        namelist = new string[Size]; 
        for (int i = 0; i < Size; i++)
            namelist[i] = "N. A.";
    }


    public string this[int index]
    {
        get
        {
            string temp;
            if (index >= 0 && index <= Size - 1)
                temp = namelist[index];
            else 
                temp = "";

            return temp;
        }
        set
        {
            if (index >= 0 && index <= Size - 1)
                namelist[index] = value;
        }
    }

}