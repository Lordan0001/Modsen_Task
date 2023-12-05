﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class ErrorDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = String.Empty;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}
