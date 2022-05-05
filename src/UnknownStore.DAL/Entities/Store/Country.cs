﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnknownStore.DAL.Entities.Store
{
    public class Country:BaseEntity
    {
        public string Title { get; set; }
        public virtual IEnumerable<Factory> Factories { get; set; }

    }
}
