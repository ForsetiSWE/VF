using System;
using System.Collections.Generic;
using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models
{
    public class Import : Entity
    {
        #region Properties

        public string ImportIdentifier { get; private set; }
        
        public List<ImportItem> ImportItems { get; private set; }
        #endregion Properties

        #region Setup

        public Import(Guid id, string importIdentifier, List<ImportItem> importItems) : base(id)
        {
            ImportIdentifier = importIdentifier;
            ImportItems = importItems;
        }

        #endregion Setup
    }
}
