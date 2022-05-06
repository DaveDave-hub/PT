using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    public interface IClient
    {
        public string FirstName { get; set; }    
        public string LastName { get; set; }
        public int Id { get; set; }
    }
}
