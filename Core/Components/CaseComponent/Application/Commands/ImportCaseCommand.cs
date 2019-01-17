using System;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands
{
    public class ImportCaseCommand : Command
    {
        #region Setup

        public readonly Guid CaseId;
        public readonly string Description;
        public readonly DateTime InitialDate;

        public ImportCaseCommand(Guid commandId, Guid caseId, string description, DateTime initialDate, Guid? originFromCommandId = null) : base(commandId, originFromCommandId)
        {
            CaseId = caseId;
            Description = description;
            InitialDate = initialDate;
        }

        #endregion Setup
    }
}
