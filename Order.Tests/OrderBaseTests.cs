using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Domain.Entities;
using Order.Repository.Repository;
using Order.Repository.UnitOfWork;

namespace Order.Tests
{
    [TestClass]
    public abstract class OrderBaseTests
    {
        private IUnitOfWork unitOfWork;
        public readonly IRepository<Users> _repo;

        protected OrderBaseTests(IUnitOfWork unitOfWork,IRepository<Users> repo)
        {
            this.unitOfWork = unitOfWork;
            _repo = repo;
        }

        [TestInitialize]
        public void Setup()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
            unitOfWork.Dispose();
        }

    }
}
