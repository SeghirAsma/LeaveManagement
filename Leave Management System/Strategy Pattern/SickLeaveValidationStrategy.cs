using Leave_Management_System.Entities;

namespace Leave_Management_System.Strategy_Pattern
{
    public class SickLeaveValidationStrategy : ILeaveValidationStrategy
    {
        public bool IsValid(LeaveRequests request, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(request.Reason))
            {
                errorMessage = "Sick leave requires a non-empty reason.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}

/*
Cette classe applique la stratégie de validation pour les congés maladie (`SickLeaveValidationStrategy`),
dans le cadre du **Strategy Pattern**. Elle impose une règle métier simple : 
- Le champ "reason"  ne doit pas être vide.
Ce comportement permet de garantir qu'un employé justifie son congé maladie.
*/
