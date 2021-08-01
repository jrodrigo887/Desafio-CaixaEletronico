using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Domain.Models
{
    public abstract class BaseEntity
    {
        public virtual long Id { get; set; }
        public bool? isActive { get; set; }
    }
}
