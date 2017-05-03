using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPTrafficGenerator
{
    internal class RandomUser
    {
        static Random _random = new Random();
        StringBuilder _builder;
        string[] _recipients;

        public RandomUser(string[] recipients)
        {
            _builder = new StringBuilder();
            _recipients = recipients;
        }

        internal Tuple<string, string> GetRecipientPair()
        {
            List<int> pair = GetRandomNumbers(2, _recipients.Length-1);

            string add1 = _recipients[pair[0]];
            string add2 = _recipients[pair[1]];

            return new Tuple<string, string>(add1, add2);
        }

        List<int> GetRandomNumbers(int count, int max)
        {
            List<int> randomNumbers = new List<int>();

            for (int i = 0; i < count; i++)
            {
                int number;

                do number = _random.Next(max);
                while (randomNumbers.Contains(number));

                randomNumbers.Add(number);
            }

            return randomNumbers;
        }
    }
}
