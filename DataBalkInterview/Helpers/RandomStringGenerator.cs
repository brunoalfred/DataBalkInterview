using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DataBalkInterview.Helpers
{
	public class RandomStringGenerator
	{
        private static readonly Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    
    public static string GenerateRandomString(int length)
    {
        var result = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            int index = random.Next(chars.Length);
            result.Append(chars[index]);
        }

        return result.ToString();
    }
}
}

