﻿using System;
using CoreDataStore.Data.Infrastructure;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Domain.Entities;

namespace CoreDataStore.Data.Postgre.Repositories
{
    public class LpcLamppostRepository : EntityBaseRepository<LpcLamppost>, ILpcLamppostRepository
    {
        public LpcLamppostRepository(NycLandmarkContext context)
            : base(context)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
