using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BIM.Booking.Application.Common
{
    public class StringFunctions
    {
        private static string GenerateRandomString(int size)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[4 * size];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }

        public static string GenerateOTP()
        {
            int size = 6;
            char[] chars = "1234567890".ToCharArray();
            byte[] data = new byte[4 * size];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }

        public static string GenerateDefaultPassword()
        {
            string password = GenerateRandomString(8);
            //password = "12345678";
            return password;
        }

        public static string GenerateHashCode()
        {
            return GenerateRandomString(30);
        }

        public static string GenerateRefreshToken()
        {
            return GenerateRandomString(80);
        }

        public static bool IsValidBase64String(string base64)
        {
            try
            {
                var result = Convert.FromBase64String(base64);
                return true;
            }
            catch (FormatException ex)
            {
                return false;
            }
        }

        public static string GenerateFileName(string fileName, string prefix = "")
        {
            string[] name = fileName.Split('.');
            string dateTime = DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss").Replace("-", "");
            if (name.Length > 1)
            {
                string extension = name[name.Length - 1];
                string result = $"{prefix}{dateTime}.{extension}";
                return result;
            }
            else
            {
                string result = $"{prefix}{dateTime}.png";
                return result;
            }
        }

        public static string FormatValidationErrorMessage(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary ModelState)
        {
            var errors = new List<string>();
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            string result = String.Join(", ", errors);
            return result;
        }

        public static string GenerateNewOrderNo()
        {
            return GenerateRandomString(6);
        }
    }
}
