using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {
        IFindeksDal _findeksDal;
        ICarService _carService;

        public FindeksManager(IFindeksDal findeksDal, ICarService carService)
        {
            _findeksDal = findeksDal;
            _carService = carService;
        }
        public IResult Add(Findeks findeks)
        {
            _findeksDal.Add(findeks);
            return new SuccessResult();
        }

        public IResult CalculateFindeks(int identityNumber, int carId)
        {
            var result = _carService.GetById(carId);
            var findeks = _findeksDal.Get(p => p.IdentityNumber == identityNumber);
            if (result.Data.FindeksScore > findeks.FindeksScore)
            {
                return new ErrorResult("Your findeks score not enough");
            }
            return new SuccessResult("Success");
        }

        public IResult Delete(Findeks findeks)
        {
            _findeksDal.Delete(findeks);
            return new SuccessResult();
        }

        public IDataResult<List<Findeks>> GetAll()
        {
            return new SuccessDataResult<List<Findeks>>(_findeksDal.GetAll());

        }

        public IDataResult<Findeks> GetByFindeksId(int id)
        {
            return new SuccessDataResult<Findeks>(_findeksDal.Get(p => p.Id == id));

        }

        public IResult Update(Findeks findeks)
        {
            _findeksDal.Update(findeks);
            return new SuccessResult();
        }
    }
}
