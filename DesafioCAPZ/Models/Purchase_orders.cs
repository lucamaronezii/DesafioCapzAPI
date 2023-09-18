using DesafioCAPZ.Controllers;
using System.ComponentModel.DataAnnotations;

namespace DesafioCAPZ.Models
{
    public class Purchase_orders
    {
        public int PurchaseOrderID { get; set; }
        public string DeliveryDate { get; set; }
        public string Supplier { get; set; }
        public string MaterialID { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public int TotalCost { get; set; }
    }
}
