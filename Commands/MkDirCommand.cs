using System;
using System.IO;
using ConsoleCommander.Structures;
namespace ConsoleCommander.Commands {
    class MkDirCommand : Command, ICommand<String> {
        private CurrentDirectory _d;
        public MkDirCommand(CurrentDirectory dir){
            this._d = dir;
        }
        
        
        public override void Execute(LinkedList<String> args){
            if(args.Count > 0){//HANDLE PARAMS
                String f = args[1];//.ToString();
                DirectoryInfo dir = new DirectoryInfo(Path.Combine(_d.CPath,f));
                dir.Create();
            }
            else{
                Console.WriteLine("ERROR. Type filename!");
            }
        }
    }
}