using System;
using System.Collections.Generic;
using ConsoleCommander.Structures;
namespace ConsoleCommander.Commands {
    class HelpCommand : Command, ICommand<String> {
        
        
        private ConsoleCommander.Structures.LinkedList<Command> _cmds;
        private String[] _names;
        public HelpCommand(){
            this._cmds = new ConsoleCommander.Structures.LinkedList<Command>();
            _names = new String[1];
        }
        
        public HelpCommand(ICollection<Command> col){
            this._cmds = col as ConsoleCommander.Structures.LinkedList<Command>;
            _names = new String[col.Count];
            Int32 i = 0;
            if(_cmds == null){
                _cmds = new ConsoleCommander.Structures.LinkedList<Command>();
                foreach(Command c in col){
                    _cmds.Add(c);
                    _names[i] = c.GetName();
                    i++;
                }
            }
            else{
                foreach(Command c in col){
                    _names[i] = c.GetName();
                    i++;
                }
            }
        }
        
        public override void Execute(ConsoleCommander.Structures.LinkedList<String> args){
            if(args == null || args.Count == 0){//help was typed.
                for(Int32 i = 1; i <= _cmds.Count; i++){
                    Console.WriteLine("{0}: {1} {2}",_names[i-1],_cmds[i].Description(),i);
                }
                Console.WriteLine(base.GetName()+": "+base.Description());//overrite Description()
            }
            else if(args.Count == 1){
                String c = args[1];
                Int32 ii = 0;
                if(c == "help"){
                    Console.WriteLine(base.GetName()+": "+base.Description());//overrite Description()
                    return;
                }
                
                while(ii < _names.Length){
                    if(_names[ii].ToLower().IndexOf(c) != -1)
                        break;
                    ii++;
                }
                
                if(ii < _names.Length){
                    Command dc = _cmds[ii + 1];
                    Console.WriteLine(dc.GetName()+": "+dc.Description());
                }
                else{
                    Console.WriteLine("command not found");
                }
            }
            else{
                Console.WriteLine("SYNTAX ERROR");
            }
        }
    }
}