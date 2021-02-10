﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemory : ICarDal
    {

        List<Car> _cars;

        public InMemory()
        {
            _cars = new List<Car> 
            {
                new Car{CarId=1,BrandId=2,ColorId=1,DailyPrice=10,ModelYear=2012,Description="2013 iki takla"},
                new Car{CarId=2,BrandId=1,ColorId=3,DailyPrice=16,ModelYear=2020,Description="Hasarsız"},
                new Car{CarId=3,BrandId=1,ColorId=1,DailyPrice=25,ModelYear=2018,Description="Hasar var ama tramer kaydına geçmemiş"},
                new Car{CarId=4,BrandId=2,ColorId=2,DailyPrice=34,ModelYear=2019,Description="2020 üç takla"},
                new Car{CarId=5,BrandId=1,ColorId=3,DailyPrice=48,ModelYear=2015,Description="Hafif hasar"}
                
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }


        public void Delete(Car car)
        {
            var carDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }
        List<Car> GetById(int id)
        {
            return _cars.Where(c => c.CarId == id).ToList();
        }


        public void Update(Car car)
        {
            var carUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carUpdate.BrandId = car.BrandId;
            carUpdate.ColorId = car.ColorId;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.Description = car.Description;
            carUpdate.ModelYear = car.ModelYear;
        }

        List<Car> ICarDal.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}