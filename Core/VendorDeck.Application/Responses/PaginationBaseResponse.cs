﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.Responses
{
    public class PaginationBaseResponse<T>
    {
        public long TotalCount { get; set; }
        public List<T> Items { get; set; }
    }
}
