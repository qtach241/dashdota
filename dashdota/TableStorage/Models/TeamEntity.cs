using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;
using ModelsLibrary;

namespace TableStorage.Models
{
    public class TeamEntity : TableEntity
    {
        public TeamEntity()
        {
        }

        // Currently, TeamEntity only stores Key Value pairs in the form
        // Primary Key and Row Key. Thus, it requires no additional properties
        // besides those inherited from TableEntity.
    }
}
