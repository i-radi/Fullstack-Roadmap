using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    public class Encryption
    {
        private int[] Key { get; }
        public Encryption(string key)
        {
            if (!checkString(key))
                throw new Exception("Key not fit our requirements");
            //check repeated char
            HashSet<char> hash = new HashSet<char>(key);
            var keyArr = hash.ToArray();
            if (keyArr.Length != 10)
                throw new Exception("Key not fit our requirements");

            Key = Parse(keyArr);
        }

        private int[] Parse(char[] arr)
        {
            var ret = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                ret[i] = arr[i] - '0';
            return ret;
        }

        private bool checkString(string str)
        {
            //Check null
            if (string.IsNullOrEmpty(str))
                return false;
            //check any char in key
            foreach (var ch in str)
                if (!char.IsDigit(ch))
                    return false;
            return true;
        }

        public string GetCipher(string message)
        {
            string ret = "";
            int[] messageArr = Parse(message.ToCharArray());
            if (!checkString(message))
                return string.Empty;//""
            for (int i = 0; i < message.Length; i++)
                ret += (messageArr[i] + Key[i % Key.Length]) % 10;
            return ret;
        }

    }
}