namespace FamilyFinances.Business.Exceptions;

public class RoleAlreadyExistsException : Exception
{
    public RoleAlreadyExistsException(string name) 
        :base($"El Rol {name} fue registrado previamente")
    { 
    }
}
