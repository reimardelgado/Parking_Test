﻿using System.Security.Cryptography;
using System.Text;

namespace ParkingLots.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string ToMd5Hash(this string input)
        {
            // Step 1, calculate MD5 hash from input
            using var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            var sb = new StringBuilder();
            foreach (var t in hashBytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}