using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using ConsoleCommander.Structures;
namespace ConsoleCommander.Commands {
    class ShowCommand : Command, ICommand<String> {
        private CurrentDirectory _d;
        public ShowCommand(CurrentDirectory dir){
            this._d = dir;
        }
        
        private String __GenEStr(Int32 ind){
            Int32 i = 0;
            StringBuilder sb = new StringBuilder();
            while(i < ind){
                sb.Append(" ");
                i++;            
            }
            return sb.ToString();
        }
        
        public override void Execute(ConsoleCommander.Structures.LinkedList<String> args){
            List<String> l = new List<String>(Directory.EnumerateFileSystemEntries(_d.CPath));
            
            String cp = _d.CPath;
            Int32 ind = 1;
            String ce;
            
            LinkedStack<String> STACK = new LinkedStack<String>();
            LinkedStack<Int32> S2 = new LinkedStack<Int32>();
            foreach(String p in l){
                STACK.Push(p);
                S2.Push(1);
            }
            while(!STACK.IsEmpty()){
                ce = STACK.Top();
                STACK.Pop();
                ind = S2.Top();
                S2.Pop();
                String temp = $"{__GenEStr(ind)+ce.Substring(ce.LastIndexOf(Path.DirectorySeparatorChar) + 1)}";
                Console.WriteLine(temp);
                if(Directory.Exists(ce)){
                    List<String> _ne = new List<String>(Directory.EnumerateFileSystemEntries(Path.Combine(cp,ce)));
                    for(Int32 i = 0; i < _ne.Count; i++){
                        STACK.Push(_ne[i]);
                        S2.Push(ind + 4);
                    }
                }
            }
        }
    }
}