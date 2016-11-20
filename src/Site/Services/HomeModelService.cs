using System;
using Site.Models;

namespace Site.Services
{
    public class HomeModelService : IGetHomeModels
    {
        public HomeModel GetHomeModel()
        {
            return new HomeModel();
        }
    }
}