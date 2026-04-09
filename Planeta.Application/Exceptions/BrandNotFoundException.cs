namespace Planeta.Application.Exceptions;

public class BrandNotFoundException : Exception
{
    public BrandNotFoundException(string message) : base($"Brand Not Found: {message}")
    {
        
    }

    public BrandNotFoundException(int id) : base($"Brand with {id}  not found")
    {
        
    }
}