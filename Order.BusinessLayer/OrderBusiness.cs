using System;
using Order.Domain;
using Order.Domain.Entities;
using Order.Repository;
using Order.Repository.Repository;
using Order = Order.Domain.Entities.Order;

namespace Order.Business
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IRepository<Users> _orderRepository;

        public OrderBusiness(IRepository<Users> repository)
        {
            _orderRepository = repository;
        }

        public OrderBusiness()
        {
            
        }

        public Guid SaveOrderAsDraft(Users user)
        {
            _orderRepository.Insert(user);
            //_unitOfwork.SaveChangesAsync();
            return user.Id;
        }
    }
}
