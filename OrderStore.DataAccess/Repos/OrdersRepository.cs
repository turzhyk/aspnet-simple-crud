using Microsoft.EntityFrameworkCore;
using OrderStore.Core.Models;
using OrderStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderStore.DataAccess.Repos
{
    public class OrdersRepository : IOrdersRepository

    {
        private readonly OrderStoreDbContext _context;
        public OrdersRepository(OrderStoreDbContext context)
        {

        }
        public async Task<List<Order>> GetAll()
        {
            var orderEntities = await _context.Orders.AsNoTracking().ToListAsync();
            var orders = orderEntities.Select(o => Order.Create(o.Id, o.Descriprion, o.TotalPrice, o.AssignedTo).Order).ToList();
            return orders;
        }
        public async Task<Guid> Create(Order order)
        {
            var orderEntity = new OrderEntity
            {
                Id = order.Id,
                Descriprion = order.Descriprion,
                TotalPrice = order.TotalPrice,
                AssignedTo = order.AssignedTo
            };
            await _context.Orders.AddAsync(orderEntity);
            await _context.SaveChangesAsync();
            return order.Id;
        }
        public async Task<Guid> Update(Guid id, string description, decimal price, string assignedTo)
        {
            await _context.Orders.Where(o => o.Id == id).ExecuteUpdateAsync(i => i
            .SetProperty(o => o.Descriprion, o => description)
            .SetProperty(o => o.TotalPrice, o => price)
            .SetProperty(o => o.AssignedTo, o => assignedTo));
            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Orders.Where(o => o.Id == id).ExecuteDeleteAsync();
            return id;
        }
    }

}
