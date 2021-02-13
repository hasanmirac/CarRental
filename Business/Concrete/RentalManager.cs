using Business.Abstract;
using Business.Constans;
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

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            var lastRental = result.LastOrDefault();

            if(lastRental.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalAddFailed);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult UpdateReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId);
            var rentalToUpdate = result.LastOrDefault();

            if (rentalToUpdate.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalUpdateFailed);
            }

            rentalToUpdate.ReturnDate = DateTime.Now;
            _rentalDal.Update(rentalToUpdate);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
