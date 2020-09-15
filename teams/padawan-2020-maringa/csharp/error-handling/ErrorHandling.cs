using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new Exception("Exception");
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        return int.TryParse(input, out int result) ? result : (int?)null;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        return int.TryParse(input, out result);
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        try
        {
            throw new Exception("Exception");
        }
        finally
        {
            disposableObject.Dispose();
        }
    }
}
