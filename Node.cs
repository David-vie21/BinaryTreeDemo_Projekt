using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeDemo_Projekt
{
    public class Node<T> where T : IComparable
    {
        private T _value;
        public T value
        {
            get => _value;
            //set => _value = value; 
        }
        private Node<T> _left;
        private Node<T> _right;
        List<T> Nodes = new List<T>();

        public Node(T value)
        {
            _left = _right = null;
            //this._value = value;
            Add2(value);
            Console.WriteLine("THIS NODE =>>>");
            Console.WriteLine("Value: " + value);
            Console.WriteLine("Right: " + _right);
            Console.WriteLine("Left: " + _left);

        }

        public void Add2(T value)
        {
            if (value == null)
            { }
            else
            {
                Nodes.Add(value);
            }
        }

        public void Add(T value)
        {
            if (value != null)
            {
                Nodes.Add(value);
                if (this.value == null)
                { this._value = value; }
                else if (value.CompareTo(this.value) > 0)      //this.value < value
                {
                    this._right = new Node<T>(value);
                }
                else if (value.CompareTo(this.value) < 0)      //this.value < value
                {
                    this._left = new Node<T>(value);
                }
            }
        }


        

        public List<T> ToOrderedList()
        {
            return TraverseTree(Nodes);
        }

        public List<T> TraverseTree(List<T> list)
        {
            //list.Sort();
            //return list;

            return SortListEigen(list);
        }

        public List<T> SortListEigen(List<T> list)
        {
            List<T> newList = list;
         
            //Bubble Sort
            int n = newList.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if(newList[j].CompareTo(newList[j+1]) > 0) //list[j] > list[j + 1]
                    {
                        T temp = newList[j];
                        newList[j] = newList[j + 1];
                        newList[j + 1] = temp;
                    }
                }
            }
            return newList;
        }

        public bool Exists(T value)
        {
            if (Nodes.Contains(value))
            { return true; }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Node<T> other = obj as Node<T>;
            if (other == null) return false;
            else return Equals(other);
        }



        public int CompareTo(Node<T> other)
        {
            return this.value.CompareTo(other.value);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return "Value: " + value + " / Right: " + _right + " / Left: " + _left;
        }
    }
}
