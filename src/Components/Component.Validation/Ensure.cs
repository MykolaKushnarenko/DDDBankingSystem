namespace Components.Validation;

public static class Ensure
{
    public static T NotNull<T>(T value, string parameterName)
    {
        if (value is null)
        {
            throw new ArgumentNullException(parameterName);
        }

        return value;
    }
}