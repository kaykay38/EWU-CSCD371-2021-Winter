using System;

namespace GenericsHomework
{
    public class Node<T>
    {
        private Node<T> next;
        private T data;

        public Node<T> Next
        {
            get 
            {
                return next!; 
            }
            
            private set
            {
                value.next = this.next;
                next = value??throw new ArgumentNullException();
                
            }
        }

        public Node(T t){
            next = this;
            data = t;
        }

        public override string ToString(){

            return data.ToString();
        }
        public Node<T> Insert(T t){
            Node<T> nn = new Node<T>(t);
            this.Next = nn;

            return nn;
        }

    }
}
