using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.LIB
{
    public interface IConnexion : IDisposable
    {
        void Connect();
        int iud(string sql, Dictionary<string, object> parameters);
        IDataReader select(string sql, Dictionary<string, object> parameters);
    }
}
