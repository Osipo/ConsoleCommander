using System;
using ConsoleCommander.Structures;
namespace ConsoleCommander.Commands {
    class Command : ICommand {
        public virtual void Execute(LinkedList<String> args){
            
        }
        
        public virtual String Description(){
            return "Base";
        }
        
        public String GetName(){//MAY BE VIRTUAL
            return this.GetType().Name;
        }
    }
}