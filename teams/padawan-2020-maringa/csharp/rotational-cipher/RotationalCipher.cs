using System;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        string crypto = "";
        foreach (char letra in text)
        {
            int asciiCode = (int)letra;
            int shifted = asciiCode + shiftKey % 26;
            if (asciiCode >= 65 && asciiCode <= 90) //UPPERCASE
            {
                crypto += (shifted <= 90) ? Convert.ToChar(shifted) : Convert.ToChar(shifted - 26);
            }
            else if (asciiCode >= 97 && asciiCode <= 122) //lowercase
            {
                crypto += (shifted <= 122) ? Convert.ToChar(shifted) : Convert.ToChar(shifted - 26);
            }
            else
            {
                crypto += letra;
            }
        }
        return crypto;
    }
}