namespace Dal;
using DalApi;

public static class Factory
{
    public static IDal Get() => DalImplementation.Instance;
}
