using System;

namespace Umc.VigiFlow.Core.SharedKernel.Models
{
    public abstract class BaseEntity
    {
        #region Properties

        public Guid Id { get; private set; }
        public int Revision { get; private set; }

        #endregion Properties

        #region Setup

        protected BaseEntity(Guid id, int revision)
        {
            Id = id;
            Revision = revision;
        }

        #endregion Setup

        public void NextRevision()
        {
            Revision++;
        }
    }
}
