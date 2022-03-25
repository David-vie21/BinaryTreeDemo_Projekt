using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeDemo_Projekt
    //@ David Ankenbrand Spengergasse 3BHIF POS1 Fun-Exercise
{
    public class Node<T> where T : IComparable
    {
        private T _value;
        public T value
        {
            get => _value;
            //set => _value = value; 
        }
        //auf public gesetzt damit man die Werte in der Unit Test Klasse überprüft werdem können
        public Node<T> _left; 
        public Node<T> _right;

        public Node(T value)
        {
            _left = _right = null;
            //this._value = value;
            Add(value);
            Console.WriteLine("THIS NODE =>>>");
            Console.WriteLine("Value: " + value);
            Console.WriteLine("Right: " + _right);
            Console.WriteLine("Left: " + _left);

        }



        public void Add(T value)
        {
            //Console.WriteLine("New ADD");
            //Console.WriteLine("Before ADD  "+ this.ToString());
            //if (value != null)
            //{
            //Nodes.Add(value);
            if (this.value is null || this.value.Equals(0))
            { this._value = value; }
            else if (value.CompareTo(this.value) > 0 || value.Equals(this.value))      //this.value < value
            {
                if (_right == null)
                {
                    //Console.WriteLine(value + " in Right geschrieben");
                    _right = new Node<T>(value);
                    //this._right.Add2(value);
                    Console.WriteLine("After in Right geschriebn:" + this._right.value);
                }
                else if (_right is not null)
                {
                    _right.Add(value);
                }
            }
            else if (value.CompareTo(this.value) < 0)      //this.value < value
            {
                if (_left == null)
                {
                    //Console.WriteLine(value + " in Left geschrieben");
                    this._left = new Node<T>(value);
                    Console.WriteLine("After in Left geschriebn:" + this._left.value);
                }
                else if (_left is not null)
                {
                    _left.Add(value);
                }
                else { throw new Exception("Somethink is wrong"); }
            }
            //}
            //Console.WriteLine("After ADD  "+this.ToString());
        }




        public List<T> ToOrderedList()
        {
            return TraverseTree(getListFromValues());
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
            if (getListFromValues().Contains(value))
            { return true; }
            return false;
        }

        public List<T> getListFromValues() //get all values / not sortet
        {
            List<T> list = new List<T>();
            if (this._right is not null)
            {
                list.AddRange(_right.getListFromValues());
            }
            if (this._left is not null)
            {
                list.AddRange(_left.getListFromValues());
            }
            if (value is not null)
            {
                list.Add(value);
            }
            return list;
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
