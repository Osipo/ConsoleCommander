using System;
using ConsoleCommander.Commands;
using ConsoleCommander.Structures;
using ConsoleCommander.Handlers;
namespace ConsoleCommander
{
    class Program
    {
        private static LinkedList<T> GetArgs<T>(T[] arr){
            LinkedList<T> cargs = new LinkedList<T>();//INDEX FROM 1..N
            Int32 i = 1;
            while(i < arr.Length){
                cargs.Add(arr[i]);//omit 0 index because it is commandName (arr[0])
                i++;
            }
            return cargs;
        }
        
        static System.Collections.Generic.ICollection<Command> GetCmds(System.Collections.Generic.ICollection<ICommand> vl){
            LinkedList<Command> r = new LinkedList<Command>();
            foreach(ICommand c in vl){
                Command cs = c as Command;
                r.Add(cs);
            }
            return r;
        }
        
        static void Main(string[] args)
        {
            LinkedDictionary<String, ICommand> cmds = new LinkedDictionary<String, ICommand>();
            IHandler<String,String[]> handler = new StringHandler();
            
            CurrentDirectory dir = new CurrentDirectory(){
                CPath = System.IO.Directory.GetCurrentDirectory()
            };
            
            cmds.Add("change",new ChangeCommand(dir));
            cmds.Add("mkfile",new MkFileCommand(dir));
            cmds.Add("show",new ShowCommand(dir));
            cmds.Add("mkdir",new MkDirCommand(dir));
            cmds.Add("copy",new CopyCommand(dir));
            cmds.Add("s",new ShowCommand(dir));
            cmds.Add("help",new HelpCommand(GetCmds(cmds.Values)));
            
            
            Console.WriteLine("===Welcome to the ConsoleCommander===\nTo see available commands type help\n");
            while(true){
                
                String c = Console.ReadLine();
            
                String[] A = handler.Handle(c);//c.Split(new Char[]{'-',' ','='},StringSplitOptions.RemoveEmptyEntries);
                ICommand cmd = cmds[A[0]];
                if(A[0] == "change"){
                    cmd.Execute(GetArgs<String>(A));
                    
                }
                else if(A[0] == "mkfile"){
                    cmd.Execute(GetArgs<String>(A));
                }
                else if(A[0] == "mkdir"){
                    cmd.Execute(GetArgs<String>(A));
                }
                else if(A[0] == "show" || A[0] == "s"){
                    cmd.Execute(null);
                }
                else if(A[0] == "copy"){
                    cmd.Execute(GetArgs<String>(A));
                }
                else if(A[0] == "help"){
                    cmd.Execute(GetArgs<String>(A));
                }
                else{
                    break;
                }
            }
        }
    }
}
