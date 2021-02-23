using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ProjectContext context=new ProjectContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             select new RentalDetailDto
                             {
                                 CarId=car.Id,
                                 CustomerId=customer.Id,
                                 CompanyName=customer.CompanyName,
                                 RentalId=rental.Id,
                                 RentDate=rental.RentDate,
                                 ReturnDate=rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
