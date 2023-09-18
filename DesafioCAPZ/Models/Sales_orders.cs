using DesafioCAPZ.Controllers;
using System.ComponentModel.DataAnnotations;

namespace DesafioCAPZ.Models
{
    public class Sales_orders
    {
        public int PurchaseOrderID { get; set; }
        public string DeliveryDate { get; set; }
        public string Customer { get; set; }
        public string MaterialID { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public int TotalValue { get; set; }
    }
}
