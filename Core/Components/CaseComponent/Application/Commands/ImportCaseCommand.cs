using System;
using System.Collections.Generic;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands
{
    public class ImportCaseCommand : Command
    {
        #region Setup

        public readonly Guid ImportId;
        public readonly string ImportIdentifier;
        public readonly List<(Guid importItemId, string description)> ImportItems;

        public ImportCaseCommand(Guid commandId, Guid importId, string importIdentifier, List<(Guid importItemId, string description)> importItems, Guid? originFromCommandId = null) : base(commandId, originFromCommandId)
        {
            ImportId = importId;
            ImportIdentifier = importIdentifier;
            ImportItems = importItems;
        }

        #endregion Setup
    }
}
