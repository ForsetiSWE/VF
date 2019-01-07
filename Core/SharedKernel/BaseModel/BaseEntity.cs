using System;

namespace Umc.VigiFlow.Core.SharedKernel.BaseModel
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public int Revision { get; protected set; }

        public void NextRevision()
        {
            Revision++;
        }
    }
}
