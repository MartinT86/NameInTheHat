using Site.Models;

namespace Site.Services
{
    public interface IGetWinningNameService
    {
        WinningNameModel GetWinningName(string namesList);
    }
}