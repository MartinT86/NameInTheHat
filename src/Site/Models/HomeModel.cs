using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class HomeModel
    {
        [Required]
        public string EnteredNames { get; set; }
        public string SelectedName {get;set;}
    }
}