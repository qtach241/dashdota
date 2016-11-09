using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableStorage
{
    /// <summary>
    /// List of all storage table names in use by app.
    /// </summary>
    public static class TableStorageNamespace
    {
        public const string GameStateTable = "GameStateTable";
        public const string TeamTable = "TeamTable";
        public const string Exceptions = "Exceptions";
        public const string Latency = "Latency";
    }
}
