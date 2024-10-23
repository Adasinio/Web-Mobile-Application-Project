using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyExpressAPI.ViewModels
{
    public class OrderForView
    {
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public int PaymentId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual DeliveryForView Delivery { get; set; } = null!;
        public virtual PaymentForView Payment { get; set; } = null!;
        public virtual ICollection<OrderItemForView> OrderItems { get; set; }

        public OrderForView()
        {
            OrderItems = new HashSet<OrderItemForView>();
        }
    }
}
