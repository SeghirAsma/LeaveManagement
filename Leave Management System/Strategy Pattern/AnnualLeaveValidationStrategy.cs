using Leave_Management_System.Entities;

namespace Leave_Management_System.Strategy_Pattern
{
    public class AnnualLeaveValidationStrategy : ILeaveValidationStrategy
    {
        public bool IsValid(LeaveRequests request, out string errorMessage)
        {
            var currentYear = DateTime.Now.Year;
            if (request.EndDate < request.StartDate)
            {
                errorMessage = "La date de fin doit être après la date de début.";
                return false;
            }
            if (request.StartDate.Year != currentYear || request.EndDate.Year != currentYear)
            {
                errorMessage = "Le congé annuel doit être pris dans l'année en cours.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}


/*
Cette classe implémente la stratégie de validation pour les congés annuels (`AnnualLeaveValidationStrategy`),
dans le cadre du **Strategy Pattern**. Elle définit des règles spécifiques, telles que :
- La date de fin doit être postérieure à la date de début.
- Les congés doivent être pris dans l'année civile en cours.
*/
