﻿namespace TodoList_API.Exceptions
{
    public class CustomException: Exception
    {
        public CustomException(string message): base(message) {}
    }
}
