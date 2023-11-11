using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NetworkConnection _conn = new NetworkConnection("127.0.0.1", 2048);
            string input;
            while((input = Console.ReadLine()) != "#") {
                string[] parts = input.Split(' ');
                string letter = parts[0];
                string Abrev = parts[1].ToUpper();

                Request temp;
                if (letter.ToLower() == "b")
                    temp = new Request(Abrev, RequestType.Buy);
                else if (letter.ToLower() == "s")
                    temp = new Request(Abrev, RequestType.Sell);
                else continue;

                Response response = _conn.Request(temp) as Response;
                if (response.Rate != -1) Console.WriteLine(response);
                else Console.WriteLine("Unknown Country");
            }
            _conn.Close();
        }
    }
}
