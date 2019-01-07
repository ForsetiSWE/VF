﻿using System;
using Umc.VigiFlow.Core.SharedKernel.BaseModel;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models
{
    public class Case : BaseEntity
    {
        #region Properties

        public string Description { get; private set; }
        public DateTime InitialDate { get; private set; }
        public DateTime DateOfMostRecentInformation { get; private set; }

        #endregion Properties

        #region Setup

        public Case(Guid id, string description, DateTime initialDate) : this(id, 0, description, initialDate, initialDate) { }

        public Case(Guid id, int revision, string description, DateTime initialDate) : this(id, revision, description, initialDate, initialDate) { }

        public Case(Guid id, int revision, string description, DateTime initialDate, DateTime dateOfMostRecentInformation)
        {
            Id = id;
            Revision = revision;
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
