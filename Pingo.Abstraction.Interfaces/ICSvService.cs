﻿using Pingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Abstraction.Interfaces
{
    public interface ICSvService
    {
        Task ExportClientsToCsvAsync(string filePath);
    }
}