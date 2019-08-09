using System;
namespace ConsoleCommander.Handlers
{
    class StringHandler : IHandler<String,String[]> {
        public String[] Handle(String input){
            return input.Split(new Char[]{'-',' ','='},StringSplitOptions.RemoveEmptyEntries);
        }
    }
}