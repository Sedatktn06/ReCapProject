using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            foreach (var cars in result)
            {
                if (cars.ReturnDate == null)
                {
                    return new ErrorResult(Messages.InvalidSale);
                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult CheckDate(Rental rental)
        {
            var result = _rentalDal.GetAll();
            if (result.Where(x => x.CarId == rental.CarId && (rental.RentDate.Ticks <= Convert.ToDateTime(x.ReturnDate).Ticks && rental.RentDate.Ticks >= x.RentDate.Ticks) || (Convert.ToDateTime(rental.ReturnDate).Ticks <= Convert.ToDateTime(x.ReturnDate).Ticks && Convert.ToDateTime(rental.ReturnDate).Ticks >= x.RentDate.Ticks) || (rental.RentDate.Ticks <= x.RentDate.Ticks && Convert.ToDateTime(rental.ReturnDate).Ticks >= Convert.ToDateTime(x.ReturnDate).Ticks)).Any())
            {
                return new ErrorResult(Messages.RentalFailedAdded);
            }
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id==rentalId));
        }
       
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(c=>c.CarId==carId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public bool IsCarAvailable(int carId)
        {
            var result = _rentalDal.GetAll(c => c.CarId == carId && c.ReturnDate == null);

            if (result.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}
