using System;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models
{
    public class Case
    {
        #region Properties

        public Guid Id { get; private set; }

        public string Description { get; private set; }
        public DateTime InitialDate { get; private set; }
        public DateTime DateOfMostRecentInformation { get; private set; }

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

        public void ChangeDescription(string description)
        {
            Description = description;
        }

        public void FollowUp(DateTime dateOfMostRecentInformation)
        {
            DateOfMostRecentInformation = dateOfMostRecentInformation;
        }
    }
}
