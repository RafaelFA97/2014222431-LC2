﻿using _2014140065_ENT;
using _2014140065_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140065_PER.Repositories
{
    public class TipoLugarRepository : Repository<TipoLugar>, ITipoLugarRepository
    {
        private readonly TransporteDbContext _Context;

        private TipoLugarRepository()
        {

        }

        public TipoLugarRepository(TransporteDbContext context)
        {
            _Context = context;
        }
    }
}
