using Leave_Management_System.Entities;

namespace Leave_Management_System.Strategy_Pattern
{
    public class LeaveValidationStrategyFactory
    {
        public static ILeaveValidationStrategy GetStrategy(LeaveType leaveType)
        {
            return leaveType switch
            {
                LeaveType.Sick => new SickLeaveValidationStrategy(),
                LeaveType.Annual => new AnnualLeaveValidationStrategy(),
                _ => new DefaultLeaveValidationStrategy()
            };
        }
    }

    public class DefaultLeaveValidationStrategy : ILeaveValidationStrategy
    {
        public bool IsValid(LeaveRequests request, out string errorMessage)
        {
            errorMessage = string.Empty;
            return true;
        }
    }
}

/*
La classe `LeaveValidationStrategyFactory` applique le **Strategy Pattern** en fournissant 
la stratégie de validation appropriée selon le type de congé (`LeaveType`). 
Grâce à cette fabrique, le contrôleur reste indépendant de la logique de validation spécifique, 
ce qui permet d'ajouter facilement de nouveaux types de validation sans toucher au code existant. 
Si aucun type n'est reconnu, une stratégie par défaut est utilisée pour éviter les erreurs.
*/