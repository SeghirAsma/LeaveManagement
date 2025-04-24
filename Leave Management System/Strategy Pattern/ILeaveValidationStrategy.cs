using Leave_Management_System.Entities;

namespace Leave_Management_System.Strategy_Pattern
{
    public interface ILeaveValidationStrategy
    {
        bool IsValid(LeaveRequests request, out string errorMessage);
    }
}

/*
Ce projet utilise le **Strategy Pattern** pour valider les demandes de congé selon leur type. 
Chaque type de congé (annuel, maladie, etc.) peut avoir des règles de validation différentes. 
L’interface `ILeaveValidationStrategy` définit une méthode `IsValid` que chaque stratégie implémente. 
Cela permet de rendre la logique de validation flexible, modulaire et facilement extensible 
sans modifier le contrôleur principal.
*/