using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult UpdateReturnDate(int carId);
        IResult CheckReturnDate(int carId);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
