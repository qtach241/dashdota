using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TableStorage.Models;

namespace TableStorage
{
    public class ExceptionTable : TableStorageClient<ExceptionEntity>
    {
        public static ExceptionTable Instance { get; } = new ExceptionTable();

        public ExceptionTable() : base(TableStorageNamespace.Exceptions)
        {
        }

        private static string GetPartitionKey()
        {
            return "Exception";
        }

        public static async Task AddEntityAsync(Exception e)
        {
            try
            {
                await Instance.AddEntityAsync(new ExceptionEntity(e)
                {
                    PartitionKey = GetPartitionKey(),
                    RowKey = (DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks).ToString(),
                });
            }
            catch (Exception)
            {
                // Got an exception when trying to log an exception.
                // Nothing much we can do here.
            }
        }
    }
}
