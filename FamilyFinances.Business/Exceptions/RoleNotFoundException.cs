namespace FamilyFinances.Business.Exceptions;

public class RoleNotFoundException : Exception
{
    public RoleNotFoundException(string name)
        :base($"El Rol {name} fue no existe")
    { 
    }

    public RoleNotFoundException(int roleId)
       : base($"El Rol {roleId} fue no existe")
    {
    }

}
