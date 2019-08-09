using System;
using System.IO;
using ConsoleCommander.Structures;
namespace ConsoleCommander.Commands {
    class ChangeCommand : Command, ICommand<String> {
        private CurrentDirectory _d;
        public ChangeCommand(CurrentDirectory dir){
            this._d = dir;
        }
        
        public override void Execute(LinkedList<String> args){
            String v1 = args[1];
            String v2 = args[2];
            if(v1 == "d" && args.Count > 1){
                Directory.SetCurrentDirectory(Path.Combine(_d.CPath,v2));
                _d.CPath = Directory.GetCurrentDirectory();
                Console.WriteLine(Directory.GetCurrentDirectory());
                Console.WriteLine("");
            }
            else if(v1 == "r"){
                Directory.SetCurrentDirectory("C:\\");
                _d.CPath = Directory.GetCurrentDirectory();
                Console.WriteLine(Directory.GetCurrentDirectory());
                Console.WriteLine("");
            }
            else if(v1 == "p" || v1 == ".."){
                Directory.SetCurrentDirectory(_d.CPath.Substring(0,_d.CPath.LastIndexOf(Path.DirectorySeparatorChar)));
                 _d.CPath = Directory.GetCurrentDirectory();
                Console.WriteLine(Directory.GetCurrentDirectory());
                Console.WriteLine("");
            }
            else{
                Console.WriteLine("ERROR. Type -d=dirName | -p | -r");
                Console.WriteLine("");
            }
        }
    }
}