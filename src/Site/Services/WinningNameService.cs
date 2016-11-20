using System;
using Site.Models;

namespace Site.Services
{
    public class WinningNameService : IGetWinningNameService
    {
        private readonly IGetRandomNumber _privateNumber;

        public WinningNameService(IGetRandomNumber privateNumber)
        {
            _privateNumber = privateNumber;
        }

        public WinningNameModel GetWinningName(string namesList)
        {
            string[] stringSeparators = new string[] {Environment.NewLine};
            var namesArray = namesList.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            var nameToTake = namesArray[_privateNumber.Get(namesArray.Length - 1)];

            return new WinningNameModel(nameToTake);
        }
    }
}