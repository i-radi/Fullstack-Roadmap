using System.Collections;

namespace Algorithms.Helpers;

public class Huffman
{
    private char internal_char = (char)0;
    public Hashtable codes = new Hashtable();
    private PriorityQueue<HeapNode, int> minHeap = new PriorityQueue<HeapNode, int>();

    public Huffman(string message)
    {
        // Get the chars frequences
        Hashtable freqHash = new Hashtable();
        int i;
        for (i = 0; i < message.Length; i++)
        {
            if (freqHash[message[i]] == null)
            {
                freqHash[message[i]] = 1;
            }
            else
            {
                freqHash[message[i]] = (int)freqHash[message[i]] + 1;
            }
        }

        // Convert Hashtable to Queue[minHeap]
        i = 0;
        foreach (char k in freqHash.Keys)
        {
            HeapNode newNode = new HeapNode(k, (int)freqHash[k]);
            minHeap.Enqueue(newNode, (int)freqHash[k]);
            i++;
        }

        // we will use the priority queue to build the huffman map .. because we can move nodes with it's child nodes as we did in the presentation .. this is the ultimate reson why we using Prioriy queue
        HeapNode top, left, right;
        int newFreq;
        while (minHeap.Count != 1)
        {
            left = minHeap.Dequeue();
            right = minHeap.Dequeue();
            newFreq = left.freq + right.freq;
            top = new HeapNode(internal_char, newFreq);
            top.right = right;
            top.left = left;
            minHeap.Enqueue(top, newFreq);

        }

        //Generate Codes
        this.generateCodes(minHeap.Peek(), "");

    }

    private void generateCodes(HeapNode node, string str)
    {
        if (node == null)
        {
            return;
        }
        if (node.data != internal_char)
        {
            codes[node.data] = str;
        }

        generateCodes(node.left, str + "0");
        generateCodes(node.right, str + "1");


    }
}