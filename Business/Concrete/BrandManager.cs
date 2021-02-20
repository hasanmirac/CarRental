using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            //İş Kodları
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);            
        }

        // Select * from Brand where BrandId = 2 
        public IDataResult<Brand> GetById(int brandid)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandid));
        }
        public IResult Add(Brand brand)
        {
            var context = new ValidationContext<Brand>(brand);
            BrandValidator brandValidator = new BrandValidator();
            var result = brandValidator.Validate(brand);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);

        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
        public IResult Update(Brand brand)
        {           
                _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);           
        }
    }
}
