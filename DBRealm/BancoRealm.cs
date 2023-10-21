using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBRealm
{
    public class BancoRealm : IBancoDados
    {
        public void Init()
        {
            Mapper.CreateMapper();
        }
    }
}
