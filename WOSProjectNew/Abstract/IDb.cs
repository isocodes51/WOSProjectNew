using System;
using System.Collections.Generic;
using System.Text;
using WOSProjectNew.Entities;

namespace WOSProjectNew.Abstract
{
    public interface IDb
    {
        void Conn(IEntities t);
      
    }
}
