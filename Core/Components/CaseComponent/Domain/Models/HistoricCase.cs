using System;
using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models
{
    public class HistoricCase : Entity
    {
        #region Setup

        public Case Case { get; private set; }

        public HistoricCase(Guid id, Case @case) : base(id)
        {
            Case = @case;
        }

        #endregion Setup
    }
}
