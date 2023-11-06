using System;
using System.IO;
using System.Security.Cryptography;

namespace PasswordCracker
{
    public static class Validator
    {
        public static bool ValidateResults(string[] finalCrackedPasswords, string[] hashedPasswords)
        {
            Console.WriteLine(finalCrackedPasswords);

            if (finalCrackedPasswords.Length != hashedPasswords.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static string CalculateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}