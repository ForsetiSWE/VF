using System;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands
{
    public class RegisterCaseCommand : Command
    {
        #region Setup

        public readonly Guid CaseId;
        public readonly string Description;
        public readonly DateTime InitialDate;

        public RegisterCaseCommand(Guid commandId, Guid caseId, string description, DateTime initialDate) : base(commandId)
        {
            CaseId = caseId;
            Description = description;
            InitialDate = initialDate;
        }

        #endregion Setup
    }
}
