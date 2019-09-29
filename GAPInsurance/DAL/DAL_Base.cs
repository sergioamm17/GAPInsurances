using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DAL_Base
    {
        public string _connectionString { get; set; }
        public DAL_Base()
        {
        }

        public DAL_Base(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
