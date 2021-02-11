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
        public void Add(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Marka başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Lütfen marka ismini 2 karakterden fazla giriniz.");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Marka başarıyla silindi.");
        }
        public void Update(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Update(brand);
                Console.WriteLine("Marka başarıyla güncellendi.");
            }
            else
            {
                Console.WriteLine("Lütfen marka isminin uzunluğunu 1 karakterden fazla giriniz.");
            }
        }
    }
}
