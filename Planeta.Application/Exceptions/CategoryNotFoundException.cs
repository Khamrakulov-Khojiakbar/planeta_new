namespace Planeta.Application.Exceptions;

public class CategoryNotFoundException : Exception
{
    public CategoryNotFoundException(int id) : base($"Category with id {id} not found")
    {

    }

    public CategoryNotFoundException(string name) : base($"Category with name {name} not found")
    {
        
    }
}