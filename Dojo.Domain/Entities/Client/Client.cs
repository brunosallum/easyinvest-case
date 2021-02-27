using System;
using System.Collections.Generic;
using System.Text;

namespace Dojo.Domain.Entities.Client
{
    public class Client : IBaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public decimal Balance { get; set; }

    }
}
