using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PasswordCracker
{
    /// <summary>
    /// A list of md5 hashed passwords is contained within the passwords_hashed.txt file.  Your task
    /// is to crack each of the passwords.  Your input will be an array of strings obtained by reading
    /// in each line of the text file and your output will be validated by passing an array of the
    /// cracked passwords to the Validator.ValidateResults() method.  This method will compute a SHA256
    /// hash of each of your solved passwords and compare it against a list of known hashes for each
    /// password.  If they match, it means that you correctly cracked the password.  Be warned that the
    /// test is ALL or NOTHING.. so one wrong password means the test fails.
    /// </summary>
    class Program
    {
        public static string md5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("MD5 Password Cracker v1.0");

            string[] hashedPasswords = File.ReadAllLines("passwords_hashed.txt");
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            // Create a List to store the cracked passwords
            List<string> crackedPasswords = new List<string>();

            foreach (char a in alphabet)
                foreach (char b in alphabet)
                    foreach (char c in alphabet)
                        foreach (char d in alphabet)
                            foreach (char e in alphabet)
                            {
                                string password = $"{a}{b}{c}{d}{e}";
                                string hash = md5(password);

                                // Compare the generated hash with the hashedPasswords
                                /*foreach (string hashedPassword in hashedPasswords)
                                {*/
                                    if (hashedPasswords.Contains(hash))
                                    {
                                        // This shows the passwords cracked ( comment this out if u want it to run faster )
                                        // Console.WriteLine($"Password: {password}, Hash: {hash}");

                                        // Add the cracked password to the List
                                        crackedPasswords.Add(password);

                                        if(crackedPasswords.Count == hashedPasswords.Length) 
                                            break;
                                    }
/*                                }*/
                            }

            // Convert the List to an array if needed
            string[] finalCrackedPasswords = crackedPasswords.ToArray();

            // Use this method to test if you managed to correctly crack all the passwords
            bool passwordsValidated = Validator.ValidateResults(finalCrackedPasswords);
        }
        
    }
}