﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ChoiceDto
    {
        public int id { get; init; }
        public string? Title { get; init; }
    }
}