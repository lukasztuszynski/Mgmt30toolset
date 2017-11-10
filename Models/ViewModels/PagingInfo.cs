﻿using System;

namespace Mgmt30toolset.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
    }
}
