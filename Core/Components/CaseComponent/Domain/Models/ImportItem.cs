using System;
using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models
{
    public class ImportItem : Entity
    {
        #region Properties

        public string Description { get; private set; }
        
        #endregion Properties

        #region Setup

        public ImportItem(Guid id, string description) : base(id)
        {
            Description = description;
        }

        #endregion Setup
    }
}
