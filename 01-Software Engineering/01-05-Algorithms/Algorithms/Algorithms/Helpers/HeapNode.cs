namespace Algorithms.Helpers;

public class HeapNode
{
    public char data;
    public int freq;
    public HeapNode left;
    public HeapNode right;
    public HeapNode(char data, int freq)
    {
        left = right = null;
        this.data = data;
        this.freq = freq;
    }
}
