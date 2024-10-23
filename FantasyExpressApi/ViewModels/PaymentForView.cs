using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyExpressAPI.ViewModels
{
    public class PaymentForView
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<OrderForView> Orders { get; set; }

        public PaymentForView()
        {
            Orders = new HashSet<OrderForView>();
        }
    }
}
