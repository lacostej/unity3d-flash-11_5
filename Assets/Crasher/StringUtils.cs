using UnityEngine;
using System.Collections;
using System.Text;

public class StringUtils {
	public static string RandomString(int size)
    {
    	string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        StringBuilder builder = new StringBuilder();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = alphabet[Random.Range(0, alphabet.Length)];                 
            builder.Append(ch);
        }

        return builder.ToString();
    }
}