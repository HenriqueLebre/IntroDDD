﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaArchMVC.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int ID { get; protected set; }
    }
}
