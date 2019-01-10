using System;

namespace Umc.VigiFlow.Core.SharedKernel.Models
{
    public abstract class Entity
    {
        #region Properties

        public Guid Id { get; private set; }

        #endregion Properties

        #region Setup

        protected Entity(Guid id)
        {
            Id = id;
        }

        #endregion Setup
    }
}
