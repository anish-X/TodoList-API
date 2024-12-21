namespace TodoList_API.Exceptions
{
    public class RepositoryException: Exception
    {
        public RepositoryException(string message): base(message) { }
    }
}
