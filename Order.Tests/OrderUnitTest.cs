using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Domain.Entities;
using Order.Repository.Repository;
using Order.Repository.UnitOfWork;
using Xunit;

namespace Order.Tests
{
    [TestClass]
    public class OrderUnitTest: OrderBaseTests
    {

        public OrderUnitTest(IUnitOfWork unitOfWork, IRepository<Users> repo) : base(unitOfWork, repo)
        {
        }

        [TestMethod]
        public void Order_SaveAsDraft()
        {
            _repo.Queryable().FirstOrDefault();
        }

        [TestMethod]
        public void Order_SaveOrderItem()
        {

        }

        [TestMethod]
        public void Order_DeleteItem()
        {

        }

        [TestMethod]
        public void Order_Filter()
        {

        }


       
    }
}
