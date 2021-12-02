using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace D1
{
    public class StringJSONParser
    {
        private Dictionary<string, string> dictToParse = new Dictionary<string, string>();

        private string KeyValueSocket(string k, string v, bool isNotLast)
        {
            string socket = "    \"" + k + "\": \"" + v + "\"";
            if (isNotLast)
                socket += ",\n";
            else
                socket += "\n";

            return socket;
        }

        private string BuildJsonString()
        {
            int dictLen = dictToParse.Count - 1;
            int currEl = 0;
            string str = "{\n";
            foreach(KeyValuePair<string, string> kvp in dictToParse)
            {
                if (currEl < dictLen)
                    str += KeyValueSocket(kvp.Key, kvp.Value, true);
                else
                    str += KeyValueSocket(kvp.Key, kvp.Value, false);
                currEl++;
            }
            str += "}";
            return str;
        }

        public byte[] StringToRaw()
        {
            return Encoding.UTF8.GetBytes(BuildJsonString());
        }

        public StringJSONParser(Dictionary<string, string> dictToParse)
        {
            foreach(KeyValuePair<string, string> kvp in dictToParse)
            {
                this.dictToParse.Add(kvp.Key, kvp.Value);
            }
        }

    }
}
