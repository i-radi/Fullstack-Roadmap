namespace Data_Structures;
public class Queue<Tdata>
{
    LinkedList<Tdata> data_list;
    public Queue()
    {
        data_list = new LinkedList<Tdata>();
    }
    public void enqueue(Tdata _data)
    {
        data_list.AddLast(_data);
    }
    public Tdata dequeue()
    {
        Tdata node_data = data_list.First.Value;
        data_list.RemoveFirst();
        return node_data;
    }
    public Tdata peek()
    {
        if (data_list.First == null)
            return default;
        return data_list.First.Value;
    }
    public bool hasData()
    {
        if (data_list.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int size() { return data_list.Count; }
}
