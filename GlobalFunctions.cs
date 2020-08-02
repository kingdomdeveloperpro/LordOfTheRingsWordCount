using System;
using System.Collections.Generic;
using System.Text;

namespace LordOfTheRingsWordCount
{
    public static class GlobalFunctions
    {
        public static string RemovePunctuation(string value)
        {
            int removeFromStart = 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsPunctuation(value[i]))
                {
                    removeFromStart++;
                }
                else
                {
                    break;
                }
            }
            int removeFromEnd = 0;
            for (int i = value.Length - 1; i >= 0; i--)
            {
                if (char.IsPunctuation(value[i]))
                {
                    removeFromEnd++;
                }
                else
                {
                    break;
                }
            }
            if (removeFromStart == 0 &&
                removeFromEnd == 0)
            {
                return value;
            }
            if (removeFromStart == value.Length &&
                removeFromEnd == value.Length)
            {
                return "";
            }
            return value.Substring(removeFromStart,
                value.Length - removeFromEnd - removeFromStart);
        }
    }
}


