using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public List<Brand> GetAll()
        {
            //İş Kodları
            return _brandDal.GetAll();
        }

        // Select * from Brand where BrandId = 2 
        public Brand GetById(int brandid)
        {
            return _brandDal.Get(b => b.BrandId == brandid);
        }
    }
}
