﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUM.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void RollBack();
    }
}
