using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.net_core_API.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() {  }
        public int Id { get; private set; }
    }
}
