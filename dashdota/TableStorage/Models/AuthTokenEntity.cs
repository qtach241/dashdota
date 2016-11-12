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

        public AuthTokenEntity(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
