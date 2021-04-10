using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Findeks:IEntity
    {
        public int Id { get; set; }
        public int IdentityNumber { get; set; }
        public int FindeksScore { get; set; }
    }
}
