﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeardenDenFileStorage.Services;
using Microsoft.Extensions.Configuration;

namespace BeardenDenFileStorage.Services
{
    public class ConfigurationMessageService : IMessageService
    {
        private IConfiguration _configuration;
        public ConfigurationMessageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetMessage()
        {
            return _configuration["Message"];
        }
    }
}