using System;
using CoreSite.Models;

namespace CoreSite.Services
{
    public class HomeModelService : IGetHomeModels
    {
        public HomeModel GetHomeModel()
        {
            return new HomeModel()
            {
                ID = 123,
                Title = "Tester from service"
            };
        }
    }
}