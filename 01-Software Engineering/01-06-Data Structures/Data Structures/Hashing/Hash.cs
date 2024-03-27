using System.Text;

namespace Data_Structures.Hashing;

public class Hash
{
    public uint Hash32(string str)
    {
        uint OffsetBasis = 2166136261;
        uint FNVPrime = 16777619;
        byte[] data = Encoding.ASCII.GetBytes(str);

        uint hash = OffsetBasis;
        for (int i = 0; i < data.Length; i++)
        {
            hash = hash ^ data[i];
            hash = hash * FNVPrime;
        }
        Console.WriteLine(str + ", " + hash + ", " + hash.ToString("x"));
        return hash;
    }
    public ulong Hash64(string str)
    {
        ulong OffsetBasis = 14695981039346656037;
        ulong FNVPrime = 1099511628211;
        byte[] data = Encoding.ASCII.GetBytes(str);

        ulong hash = OffsetBasis;
        for (int i = 0; i < data.Length; i++)
        {
            hash = hash ^ data[i];
            hash = hash * FNVPrime;
        }
        Console.WriteLine(str + ", " + hash + ", " + hash.ToString("x"));
        return hash;
    }
}
