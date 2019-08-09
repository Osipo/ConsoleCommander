using System;
namespace ConsoleCommander.Structures {
    class TypedNode<T> : Node {
        public T data;
        public TypedNode(T data) : this(data,null) {}
        
        public TypedNode(T data, Node next) : base(next){
            this.data = data;
        }
        public override String ToString(){
            return data.ToString()+" "+((_next != null) ? _next.ToString() : String.Empty);
        }
    }
}