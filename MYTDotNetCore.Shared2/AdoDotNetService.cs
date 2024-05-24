using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYTDotNetCore.Shared2
{
    internal class AdoDotNetService
    {
        private readonly string _connectionString;
        public AdoDotNetService(string connectionString) 
        {
            _connectionString = connectionString;
        }

        
    }
}
