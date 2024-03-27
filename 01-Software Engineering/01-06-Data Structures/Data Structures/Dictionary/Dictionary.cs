using System;

namespace Data_Structures.Dictionary;

public class Dictionary<Tkey, Tvalue> where Tkey : class
{
    KeyValuePair[] entries;
    int initialSize;
    int entriesCount;
    public Dictionary()
    {
        this.initialSize = 3;
        this.entries = new KeyValuePair[this.initialSize];
    }
    public void ResizeOrNot()
    {
        if (this.entriesCount < this.entries.Length - 1)
        {
            return;
        }

        int newSize = this.entries.Length + this.initialSize;

        Console.WriteLine("[resize] from "
            + this.entries.Length + " to " + newSize);

        KeyValuePair[] newArray = new KeyValuePair[newSize];
        Array.Copy(this.entries, newArray, this.entries.Length);
        this.entries = newArray;

    }
    public int Size()
    {
        return this.entriesCount;
    }

    public void Set(Tkey key, Tvalue value)
    {
        for (int i = 0; i < this.entries.Length; i++)
        {
            if (this.entries[i] != null &&
                this.entries[i].Key == key)
            {
                this.entries[i].Value = value;
                return;
            }
        }
        this.ResizeOrNot();
        KeyValuePair newPair = new KeyValuePair(key, value);
        this.entries[this.entriesCount] = newPair;
        this.entriesCount++;
    }

    public Tvalue Get(Tkey key)
    {
        for (int i = 0; i < this.entries.Length; i++)
        {
            if (this.entries[i] != null &&
                this.entries[i].Key == key)
            {
                return this.entries[i].Value;
            }
        }
        return default(Tvalue);
    }

    public Boolean Remove(Tkey key)
    {
        for (int i = 0; i < this.entries.Length; i++)
        {
            if (this.entries[i] != null &&
                this.entries[i].Key == key)
            {
                this.entries[i] = this.entries[this.entriesCount - 1];
                this.entries[this.entriesCount - 1] = null;
                this.entriesCount--;
                return true;
            }
        }
        return false;
    }
    public void Print()
    {
        Console.WriteLine("----------");
        Console.WriteLine("[size] " + this.Size());
        for (int i = 0; i < this.entries.Length; i++)
        {
            if (this.entries[i] == null)
            {
                Console.WriteLine("[" + i + "]");
                continue;
            }
            else
            {
                Console.WriteLine("[" + i + "]" + this.entries[i].Key
                  + ":" + this.entries[i].Value);
            }
        }
        Console.WriteLine("==========");
    }



    class KeyValuePair
    {
        Tkey _key;
        Tvalue _value;
        public Tkey Key
        {
            get { return _key; }
        }
        public Tvalue Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public KeyValuePair(Tkey key, Tvalue val)
        {
            _key = key;
            _value = val;
        }
    }
}
