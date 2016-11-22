using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;
using ModelsLibrary;

namespace TableStorage.Models
{
    public class AuthTokenEntity : TableEntity
    {
        public AuthTokenEntity()
        {
        }

        public AuthTokenEntity(bool isValid)
        {
            IsValid = isValid;
        }

        public bool IsValid { get; set; } = false;
    }
}
