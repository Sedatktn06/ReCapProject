using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        //IDataResult<List<Color>> GetCarsByBrandId(int id);
        //IDataResult<List<Color>> GetCarsByColorId(int id);
        //IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<Brand> GetById(int brandId);
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
    }
}
