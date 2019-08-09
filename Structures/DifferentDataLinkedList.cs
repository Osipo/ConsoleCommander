using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
namespace ConsoleCommander.Structures {
    class DifferentDataLinkedList {
        private Node _head;
        private Node _tail;
        private Int32 _count;
        public DifferentDataLinkedList(){
            _head = new Node();
        }
        
        //0 pointer to the _head. So pos must be [1..count]
        public void Insert<T>(Int32 p,T item){
            if(p <= 0 || p > _count + 1){
                Console.WriteLine("This position isn't existed in the list");
                return;
            }
            if(_count == 0){
                _tail = new TypedNode<T>(item);
                _head._next = _tail;
                _count += 1;
                return;
            }
            //Append.
            else if(p == _count + 1){
                _tail._next = new TypedNode<T>(item);
                _tail = _tail._next;
                _count+=1;
                return;
            }
            
            Int32 q = 1;
            TypedNode<T> elem = new TypedNode<T>(item);
            Node temp = _head;//_head pos = 0.
            while(q < p){//move to p.
                temp = temp._next;
                q+=1;
            }
            Node pp = temp;//pointer to p_cell
            temp = temp._next;//temp = p.next or p_cell 
            pp._next = elem;//p.next.element = x
            elem._next = temp;//p.next.next = temp
            this._count += 1;
        }
        
        public void Add<T>(T item){
            Insert<T>(_count+1,item);//to the end.
        }
        
        public dynamic this[Int32 i]{
            get{
                return (TypedNode<dynamic>)_head._next;
            }
        }
        
        public Int32 Count{
            get{
                return _count;
            }
        }
        public bool IsReadOnly{
            get{
                return false;
            }
        }
        
        
    }
}