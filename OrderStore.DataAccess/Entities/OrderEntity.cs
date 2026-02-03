using System;
using System.Collections.Generic;
using System.Text;

namespace OrderStore.DataAccess.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public string Descriprion { get; set; }
        public decimal TotalPrice { get; set; }
        public string AssignedTo { get; set; }
    }
}
