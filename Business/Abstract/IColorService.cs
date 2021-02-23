using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        //IDataResult<List<Color>> GetCarsByBrandId(int id);
        //IDataResult<List<Color>> GetCarsByColorId(int id);
        //IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<Color> GetById(int colorId);
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
    }
}
