using System;
using System.Collections.Generic;
using System.IO;
using ConsoleCommander.Structures;
using System.Threading;
namespace ConsoleCommander.Commands {
    class CopyCommand : Command, ICommand<String> {
        private CurrentDirectory _d;
        public CopyCommand(CurrentDirectory dir){
            this._d = dir;
        }
        
        //Copy
        private void __CopyFiles(IEnumerable<String> files, String dest){
            
            foreach (String file in files)
            {
                String name = Path.GetFileName(file);
                String d = Path.Combine(dest, name);
                File.Copy(file, d);
            }
            
        }
        
        
        
        private void __CopyDirectory(String dest, String filter=""){
            
            
            List<String> fls = new List<String>(Directory.EnumerateFiles(Path.Combine(_d.CPath,filter)));
            List<String> dirs = new List<String>(Directory.EnumerateDirectories(Path.Combine(_d.CPath,filter)));
            dirs.Remove(Path.Combine(_d.CPath,dest)); //CHECK
            
            __CopyFiles(fls,dest);//copy files from sourceDir.
            LinkedStack<String> STACK = new LinkedStack<String>();
            foreach(String d in dirs){//subDirs.
                STACK.Push(d);
                //Console.WriteLine(d);
            }
            String src = Path.Combine(_d.CPath,filter);
            while(!STACK.IsEmpty()){
                String t1 = STACK.Top();
                String t2 = Path.Combine(_d.CPath,dest,t1.Substring(t1.LastIndexOf(src)+src.Length + 1));//Create path to subDir.
                STACK.Pop();
                DirectoryInfo sd = new DirectoryInfo(t2);
                sd.Create();//Create subDir in destDir.
                List<String> sfiles = new List<String>(Directory.EnumerateFiles(t1));
                __CopyFiles(sfiles,t2);//CopyFiles of subDir.
                
                List<String> sdirs = new List<String>(Directory.EnumerateDirectories(t1));
                foreach(String dd in sdirs){
                    STACK.Push(dd);
                }
            }
        }
        
        public override void Execute(ConsoleCommander.Structures.LinkedList<String> args){
            if(args.Count > 2){
                String inp = args[1];//files 
                String k = args[2];//key
                String dest = args[3];//destination directory.
                if(k != "d"){
                    Console.WriteLine("Syntax Error. Type destination directory like d=dirName");
                    return;
                }
                if(!Directory.Exists(dest))
                    Directory.CreateDirectory(dest);
                
                
                //IF IT IS A DIRECTORY COPY ITS CONTENT RECURSIVELY
                if(Directory.Exists(inp)){
                    __CopyDirectory(dest,inp);
                }
                
                List<String> files = new List<String>(Directory.EnumerateFiles(_d.CPath,inp));
                __CopyFiles(files,dest);
                
            }
            else if(args.Count == 2){
                String k = args[1];//key
                String dest = args[2];//destination directory.
                if(k != "d"){
                    Console.WriteLine("Syntax Error. Type destination directory like d=dirName");
                    return;
                }
                if(!Directory.Exists(dest))
                    Directory.CreateDirectory(dest);
                
                __CopyDirectory(dest);
            }
            else{
                Console.WriteLine("ERROR. Type filename and destination directory!");
            }
        }
    }
}