using System.Text;

namespace Data_Structures.Dictionary;
public class HashTable<Tkey, Tvalue> where Tkey : class
{
    KeyValuePair[] entries;
    int initialSize;
    int entriesCount;

    public HashTable()
    {
        this.initialSize = 3;
        this.entriesCount = 0;
        this.entries = new KeyValuePair[this.initialSize];
    }

    int GetHash(Tkey key)
    {
        uint FnvOffsetBasis = 2166136261;
        uint FNVPrime = 16777619;

        byte[] data = Encoding.ASCII.GetBytes(key.ToString());

        uint hash = FnvOffsetBasis;

        for (int i = 0; i < data.Length; i++)
        {
            hash = hash ^ data[i];
            hash = hash * FNVPrime;
        }

        Console.WriteLine("[hash] " + key.ToString()
            + " " + hash + " " + hash.ToString("x")
              + " " + hash % (uint)this.entries.Length);

        return (int)(hash % (uint)this.entries.Length);
    }

    int CollisionHandling(Tkey key, int hash, bool Set)
    {
        int newHash;
        for (int i = 1; i < this.entries.Length; i++)
        {
            newHash = (hash + i) % this.entries.Length;

            Console.WriteLine("[coll] " + key.ToString()
                    + " " + hash + ", new hash: " + newHash);

            if (Set &&
                (this.entries[newHash] == null ||
                  this.entries[newHash].Key == key))
            {
                return newHash;
            }
            else if (!Set && this.entries[newHash].Key == key)
            {
                return newHash;
            }
        }
        return -1;
    }

    void AddToEntries(Tkey key, Tvalue value)
    {
        int hash = this.GetHash(key);
        if (this.entries[hash] != null && this.entries[hash].Key != key)
        {
            hash = this.CollisionHandling(key, hash, true);
        }
        if (hash == -1)
        {
            throw new Exception("Invalid Hashtable!!!!");
        }
        if (this.entries[hash] == null)
        {
            KeyValuePair newPair = new KeyValuePair(key, value);
            this.entries[hash] = newPair;
            this.entriesCount++;
        }
        else if (this.entries[hash].Key == key)
        {
            this.entries[hash].Value = value;
        }
        else
        {
            throw new Exception("Invalid Hashtable!!!!");
        }
    }



    public void ResizeOrNot()
    {
        if (this.entriesCount < this.entries.Length)
        {
            return;
        }
        int newSize = this.entries.Length * 2;

        Console.WriteLine("[resize] from " +
          this.entries.Length + " to " + newSize);

        KeyValuePair[] entriesCopy = new KeyValuePair[this.entries.Length];
        Array.Copy(this.entries, entriesCopy, entriesCopy.Length);

        this.entries = new KeyValuePair[newSize];
        this.entriesCount = 0;
        for (int i = 0; i < entriesCopy.Length; i++)
        {
            if (entriesCopy[i] == null) continue;
            this.AddToEntries(entriesCopy[i].Key, entriesCopy[i].Value);
        }
    }
    public void Set(Tkey key, Tvalue value)
    {
        this.ResizeOrNot();
        this.AddToEntries(key, value);
    }
    public Tvalue Get(Tkey key)
    {
        int hash = this.GetHash(key);
        if (this.entries[hash] != null && this.entries[hash].Key != key)
        {
            hash = this.CollisionHandling(key, hash, false);
        }
        if (hash == -1 || this.entries[hash] == null)
        {
            return default(Tvalue);
        }

        if (this.entries[hash].Key == key)
        {
            return this.entries[hash].Value;
        }
        else
        {
            throw new Exception("Invalid Hashtable!!!!");
        }

    }


    public int Size()
    {
        return this.entriesCount;
    }
    public void Print()
    {
        Console.WriteLine("-----------");
        Console.WriteLine("[Size] " + this.Size());

        for (int i = 0; i < this.entries.Length; i++)
        {
            if (this.entries[i] == null)
            {
                Console.WriteLine("[" + i + "] null");
            }
            else
            {
                Console.WriteLine("[" + i + "] " +
                  this.entries[i].Key + ":" +
                    this.entries[i].Value);
            }
        }

        Console.WriteLine("============");
    }
    class KeyValuePair
    {
        Tkey _key;
        Tvalue _value;
        public Tkey Key
        {
            get { return this._key; }
        }
        public Tvalue Value
        {
            get { return this._value; }
            set { this._value = value; }
        }
        public KeyValuePair(Tkey key, Tvalue val)
        {
            this._key = key;
            this._value = val;
        }

    }
}
