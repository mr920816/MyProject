using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    #region 泛型接口

    /// <summary>
    ///  泛型接口
    /// </summary>
    public class GenericList<T> : IEnumerable<T>

    {
        protected Node head;
        protected Node current = null;
        protected class Node
        {
            public Node next;
            private T data;
            public Node(T t)
            {
                next = null;
                data = t;
            }
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }


        public GenericList() // 构造函数 
        {
            head = null;
        }
        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }
        // 迭代器的实现
        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
    public class SortedList<T> : GenericList<T> where T : System.IComparable<T>
    {
        public void BubbleSort()
        {
            if(null == head || null == head.Next)
            {
                return;
            }
            bool swapped;
            do
            {
                Node previous = null;
                Node current = head;
                swapped = false;
                while (current.next != null)
                {
                    if (current.Data.CompareTo(current.next.Data) > 0)
                    {
                        Node tmp = current.next;
                        current.next = current.next.next;
                        tmp.next = current;

                        if (previous == null)
                        {
                            head = tmp;
                        }
                        else
                        {
                            previous.next = tmp;
                        }
                        previous = tmp;
                        swapped = true;
                    }
                    else
                    {
                        previous = current;
                        current = current.next;
                    }
                }
            } while (swapped);
        }

    }
    #endregion





    public class Employee
    {
        public Employee(string s, int i) => (Name, ID) = (s, i);
        public string Name { get; set; }
        public int ID { get; set; }
    }

    public class GenericList<T> where T : Employee
    {

        private class Node
        {

        }

    }


}
