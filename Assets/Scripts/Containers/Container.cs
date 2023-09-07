using UnityEngine;

public static class Container
{
    private static ObjectContainer s_environment;
    public static ObjectContainer Environment
    {
        get
        {
            if(s_environment == null)
            {
                s_environment = Resources.Load<ObjectContainer>("Containers/container_environment");
            }
            return s_environment;
        }
    }
}
