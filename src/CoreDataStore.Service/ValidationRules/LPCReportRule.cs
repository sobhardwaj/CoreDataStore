using CoreDataStore.Service.Models;
using FluentValidation;

namespace CoreDataStore.Service.ValidationRules
{
    public class LpcReportRule : AbstractValidator<LpcReportModel>
    {
        public LpcReportRule()
        {
            RuleFor(m => m.Name).Length(4, 200);
        }
    }
}
