using System.Collections.Generic;

namespace Order.Domain.Entities
{
  
    public class Customer : Entity
    {
        public string Code { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Discriminator { get; set; }
        //length 200 
        public List<Order> Orders { get; set; }

    }
    public class Individual : Customer
    {
        public Individual()
        {
            Discriminator = "1";
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Company : Customer
    {
        public Company()
        {
            Discriminator = "2";
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyAddress { get; set; }
        public string ResponsibleFirstName { get; set; }
        public string ResponsibleLastName { get; set; }
        public string ResponsiblePhone { get; set; }
        public string ResponsibleEmail { get; set; }
    }
}
