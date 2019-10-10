using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Synyi.CaseCode.Configuration
{
    public class DbConfigurationContextExtension
    {
        public DbConfigurationContextExtension(string schema)
        {
            this.Schema = schema;
        }

        public string Schema { get; set; }

   
    }

    
}
