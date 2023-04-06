using System;
using System.Collections.Generic;
using System.Text;
using WOSProjectNew.Entities;

namespace WOSProjectNew.Abstract
{
    public interface IDb
    {
        //string Conn(IEntities e);
        //int GetCount(string myData, IEntities );
        void SonucGetir(IEntities e);
        void Conn(IEntities e);
    }
}
