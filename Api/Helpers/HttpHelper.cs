using System.Security.Cryptography;
using System.Text;

namespace Api.Helpers {
    public static class HttpHelper {
        public static String GetHash(String text, String key)
        {
            // change according to your needs, an UTF8Encoding
            // could be more suitable in certain situations
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        ///secret = ApiSecret, queryString = 
        public static string CreateSignature(string queryString, string secret)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(secret);
            byte[] queryStringBytes = Encoding.UTF8.GetBytes(queryString);
            HMACSHA256 hmacsha256 = new HMACSHA256(keyBytes);

            byte[] bytes = hmacsha256.ComputeHash(queryStringBytes);

            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}