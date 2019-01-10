using System;

namespace Umc.VigiFlow.Core.SharedKernel.Models
{
    public class AuditTrail<TEntity> where TEntity : BaseEntity
    {
        #region Properties

        public TEntity Entity { get; private set; }

        public Guid CommandId { get; private set; }

        public DateTime TimeStamp { get; private set; }

        #endregion Properties

        #region Setup

        public AuditTrail(Guid commandId, TEntity entity)
        {
            CommandId = commandId;
            Entity = entity;
            TimeStamp = DateTime.Now;
        }

        #endregion Setup
    }
}
