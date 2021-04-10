using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ProjectContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context=new ProjectContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }

        public UserDetailDto GetUserDetailById(int id)
        {
            using (var context = new ProjectContext())
            {
                var result = from users in context.Users
                             join customers in context.Customers
                             on users.Id equals customers.UserId
                             where users.Id == id
                             select new UserDetailDto
                             {
                                 UserID = users.Id,
                                 CustomerID = customers.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 CustomerName = customers.CompanyName
                             };
                return result.SingleOrDefault();
            }
        }

        public List<UserDetailDto> GetUserDetails()
        {
            using (var context = new ProjectContext())
            {
                var result = from users in context.Users
                             join customers in context.Customers
                             on users.Id equals customers.UserId
                             select new UserDetailDto
                             {
                                 UserID = users.Id,
                                 CustomerID = customers.Id,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email,
                                 CustomerName = customers.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
