using System;
namespace ConsoleCommander.Handlers
{
    interface IHandler<T,R> {
        R Handle(T input);
    }
}