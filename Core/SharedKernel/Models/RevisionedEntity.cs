using System;

namespace Umc.VigiFlow.Core.SharedKernel.Models
{
    public abstract class RevisionedEntity : Entity
    {
        #region Properties

        public int Revision { get; private set; }

        #endregion Properties

        #region Setup

        protected RevisionedEntity(Guid id, int revision) : base(id)
        {
            Revision = revision;
        }

        #endregion Setup

        public void NextRevision()
        {
            Revision++;
        }
    }
}
