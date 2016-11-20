using System;

namespace Site.Services
{
    public class RandomNumberService : IGetRandomNumber
    {
        public int Get(int max)
        {
            var random = new Random();
            return random.Next(max);  
        }
    }
}