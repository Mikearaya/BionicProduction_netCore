using System;
using System.Collections.Generic;

namespace BionicProduction.Migration.Database
{
    public partial class EfmigrationsHistory
    {
        public string MigrationId { get; set; }
        public string ProductVersion { get; set; }
    }
}
