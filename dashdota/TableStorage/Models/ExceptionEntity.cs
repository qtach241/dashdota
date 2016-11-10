using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;
using ModelsLibrary;

namespace TableStorage.Models
{
    public class ExceptionEntity : TableEntity
    {
        public ExceptionEntity()
        {
        }

        public ExceptionEntity(Exception e)
        {
            ExceptionAsString = e?.ToString();
            Type = e?.GetType()?.ToString();
            Message = e?.Message;
            Source = e?.Source;
        }

        public string ExceptionAsString { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
    }
}
