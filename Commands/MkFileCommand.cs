using System;
using System.IO;
using ConsoleCommander.Structures;
namespace ConsoleCommander.Commands {
    class MkFileCommand : Command, ICommand<String> {
        private CurrentDirectory _d;
        public MkFileCommand(CurrentDirectory dir){
            this._d = dir;
        }
        
        
        public override void Execute(LinkedList<String> args){
            if(args.Count > 0){
                String f = args[1];//.ToString();
                FileInfo file = new FileInfo(Path.Combine(_d.CPath,f));
                FileStream fs = file.Create();
                fs.Close();
            }
            else{
                Console.WriteLine("ERROR. Type filename!");
            }
        }
    }
}