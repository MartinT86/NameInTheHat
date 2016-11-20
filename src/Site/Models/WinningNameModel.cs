namespace Site.Models
{
    public class WinningNameModel
    {
        private string _name;

        public WinningNameModel(string name)
        {
            _name = name;
        }
        public string Name { get{ return _name;} }
    }
}