using DesafioCAPZ.Controllers;
using System.ComponentModel.DataAnnotations;

namespace DesafioCAPZ.Models
{
    public class Workforce
    {
        public int WorkforceID { get; set; }
        public string Name { get; set; }
        public string Shift { get; set; }
    }
}
