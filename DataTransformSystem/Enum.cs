namespace DataTransformSystem
{
    public enum EType
    {
        Unknown = 0,
        Trading = 1,
        RRSP = 2,
        RESP = 3,
        FUND = 4,
        Max = 5
    }

    public enum ECurrency
    {
        Unknown = 0,
        CAD = 1,
        USD,
    }

    public enum FileType
    {
        AccountFormat1 = 0,
        AccountFormat2 = 1
    }

}