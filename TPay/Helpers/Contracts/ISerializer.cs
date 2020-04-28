using System;
using System.Collections.Generic;
using System.Text;

namespace TPay.Helpers.Contracts
{
    public interface ISerializer
    {
        string Serialize(object obj);
    }
}
