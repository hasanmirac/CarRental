using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,RentACarContext>,ICustomerDal
    {
        public List<CustomerInfoDto> GetCustumerInfo()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from customer in context.Customers
                    join user in context.Users on customer.UserId equals user.Id
                    select new CustomerInfoDto
                    {
                        CustomerId = customer.CustomerId,
                        CustomerName = user.FirstName,
                        CustomerLastName = user.LastName,
                        Email = user.Email
                    };
                return result.ToList();
            }
        }
    }
}
