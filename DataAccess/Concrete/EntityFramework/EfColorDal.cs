﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfColorDal : EfEntityRepositoryBase<Color, SqlContext>, IColorDal
    {
        public List<Color> GetColorList(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
