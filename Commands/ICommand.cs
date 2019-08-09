using System;
using ConsoleCommander.Structures;
namespace ConsoleCommander.Commands {
    interface ICommand {
        void Execute(LinkedList<String> args);//BY DEFAULT 
    }
    interface ICommand<T> : ICommand {
        void Execute(LinkedList<T> args);
    }
}