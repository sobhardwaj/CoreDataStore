﻿using CoreDataStore.Service.Models;
using FluentValidation;

namespace CoreDataStore.Service.ValidationRules
{
    public class LPCReportRule : AbstractValidator<LpcReportModel>
    {
        public LPCReportRule()
        {
            RuleFor(m => m.Name).Length(4, 200);
        }
    }
}
