using System;

namespace ApiCart.Utils
{
    public class GenerateID
    {
        int count = 0;

        public int GenerateRandomID()
        {
            Random randNum = new Random();
            var num = randNum.Next(count, 100);
            count++;
            return num;
        }
    }
}
