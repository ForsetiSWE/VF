using System;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models
{
    public class Case
    {
        #region Properties

        public Guid Id { get; }

        public string Description { get; }
        public DateTime InitialDate { get; }
        public DateTime DateOfMostRecentInformation { get; }

        #endregion Properties

        #region Setup

        public Case(Guid id, string description, DateTime initialDate) : this(id, description, initialDate, initialDate) { }

        public Case(Guid id, string description, DateTime initialDate, DateTime dateOfMostRecentInformation)
        {
            Id = id;
            Description = description;
            InitialDate = initialDate;
            DateOfMostRecentInformation = dateOfMostRecentInformation;
        }

        #endregion Setup
    }
}
