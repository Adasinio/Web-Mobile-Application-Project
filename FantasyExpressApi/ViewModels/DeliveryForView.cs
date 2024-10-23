using FantasyExpressApi.Helpers;
using FantasyExpressApi.Models.TableClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyExpressAPI.ViewModels
{
    public class DeliveryForView
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public DeliveryForView()
        {
            Orders = new HashSet<Order>();
        }
        public static implicit operator DeliveryForView(Delivery source)
        {
            var result = new DeliveryForView().CopyProperties(source);
            return result;
        }
        public static implicit operator Delivery(DeliveryForView source) 
        {
            var result = new Delivery().CopyProperties(source);
            result.CreatedDate = DateTime.Now;
            result.IsActive = true;
            return result;
        }
    }
}
