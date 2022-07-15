﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> Get(int id);
        IDataResult<User> GetMail(string mail);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
    }
}
