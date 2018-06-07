using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    #region 泛型接口
    public class GenericListtt<T> : IEnumerable<T>

    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


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
                    //  C3 b2 a1

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

    public class Person : System.IComparable<Person>
    {
        string name;
        int age;

        public Person(string s, int i)
        {
            name = s;
            age = i;
        }

        // This will cause list elements to be sorted on age values.
        public int CompareTo(Person p)
        {
            return age - p.age;  // 这边是减
        }

        public override string ToString()
        {
            return name + ":" + age;
        }

        // Must implement Equals.
        public bool Equals(Person p)
        {
            return (this.age == p.age);
        }
    }

    #endregion





    public class Employee
    {
        public Employee(string s, int i) => (Name, ID) = (s, i);
        public string Name { get; set; }
        public int ID { get; set; }
    }

    //public class GenericList<T> where T : Employee
    //{

    //    private class Node
    //    {

    //    }

    //}


}
