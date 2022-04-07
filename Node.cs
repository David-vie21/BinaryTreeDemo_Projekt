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
            return SortListEigen(list);
            //return SortListEigen(list);
        }

        public List<T> SortListEigen(List<T> list) //Bubble Sort
        {
            List<T> newList = list;
         
            
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

        //Insertion Sort =>> dont work!
        //public List<T> SortListEigenInsertionSort(List<T> list) 
        //{
        //    List<T> newList = new List<T>();
        //    int i = 0;
        //    int i2 = 0;
        //    foreach (T t in list)
        //    {
        //        int merker = -1;
        //        T mT = t;
        //        if (newList.Count == 0)
        //        { newList.Add(t); }
        //        else
        //        {
        //            bool isset = false;
        //            i2 = 0;
        //            foreach (T t1 in newList.ToList())
        //            {
        //                if (t.CompareTo(t1) < 0)
        //                {
        //                    newList.Insert(i2, t);
        //                    isset = true;
        //                    // Console.WriteLine("Kleiner Insert:  " + i2 + " --  " + t);
        //                    break;
        //                }
        //                else if (t.CompareTo(t1) == 0)
        //                {
        //                    if (i2 == 0)
        //                    {
        //                        newList.Insert(i2, t);
        //                        isset = true;
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        newList.Insert(i2 - 1, t);
        //                        isset = true;
        //                        break;
        //                    }
        //                }
        //                else if (t.CompareTo(t1) > 0)
        //                {

        //                    merker = i2;
        //                    mT = t;

        //                }
        //                i2++;
        //            }
        //            if (merker != -1 && isset != true)
        //            {
        //                if (newList.Count - 1 == merker)
        //                { newList.Add(mT); }
        //                else
        //                {
        //                    if (!newList[merker].Equals(newList[merker + 1]))
        //                    {
        //                        newList.Insert(merker + 1, mT);
        //                    }
        //                }
        //            }
        //        }
        //        //ausgabe List
        //        //Console.WriteLine("Sort List: " + i);
        //        //foreach (T t1 in newList)
        //        //{
        //        //    Console.WriteLine(t1);
        //        //}
        //        i++;
        //    }
        //    return newList;
        //}

        public bool exists2(T value)//not performant
        {
            if (getListFromValues().Contains(value))
            { return true; }
            return false;
        }
        
        public bool? exists(T valueS) 
        {
            if (this.value.Equals(valueS))
            {
                return true;
            }
            else 
            {
                if (this.value.CompareTo(valueS) <= 0)
                {
                    if (_right is not null)
                        return _right.exists(valueS);
                }
                if (this.value.CompareTo(valueS) >= 0)
                {
                    if(_left is not null)
                    return _left.exists(valueS);
                }
            }
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

       
        public override string ToString()
        {
            return "Value: " + value + " / Right: " + _right + " / Left: " + _left;
        }

        



    }
}
