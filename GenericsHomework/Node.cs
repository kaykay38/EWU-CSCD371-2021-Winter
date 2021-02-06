using System;

namespace GenericsHomework
{
    public class Node<T>
    {
        private Node<T>? _next;
        private T? _data;

        public Node<T> Next
        {
            get 
            {
                return _next!; 
            }

            private set
            {
                value._next = this._next;
                _next = value??throw new ArgumentNullException();
            }
        }

        public Node(T t)
        {
            _next = this;
            _data = t;
        }

        public T? Data 
        { 
            get 
            {
                return _data!;
            }
        }

        public override string? ToString()
        {

            if(_data is null)
            {
                throw new ArgumentNullException(nameof(_data));
            }

            return _data.ToString();
        }

        public Node<T> Insert(T t){
            Node<T> newNode = new (t);
            this.Next = newNode;

            return newNode;
        }
        
        // Must deference all removed nodes by setting them to null to allow for garbage collection
        public void Clear()
        {
            //Node<T>? curTemp = this;
            Node<T>? prev = this;
            Node<T>? cur = this.Next;
            while (prev != cur?.Next && cur != this )
            {
                prev = cur?.Next;
                cur = null;
                cur = prev;
                prev = prev?.Next;
            }
            prev = null;
            this.Next = this;
        }
    }
}
