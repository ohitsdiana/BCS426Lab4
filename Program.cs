/* Lab 4
* 
* Diana Guerrero
* Professor Aydin
* BCS 426 
* 3/11/21
* 
* Partner(s): Patrick Adams
* Resource(s): 
* 1. https://drive.google.com/drive/folders/1qoGbc6LT0whUGf5izfk8zuxK88LV8odX
* 2. https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.modeling.store.-ctor?view=visualstudiosdk-2019
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace BCS426Lab4
{

    // Given in LinkedListNode.cs File
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value) =>
            Value = value;

        public T Value 
        { 
            get; 
        }
        public LinkedListNode<T> Next 
        { 
            get; 
            internal set; 
        }
        public LinkedListNode<T> Prev 
        { 
            get; 
            internal set; 
        }
    }

    // Given in LinkedList.cs File
    // Create Class LinkedList
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedListNode<T> First
        {
            get;
            private set;
        }

        public LinkedListNode<T> Last
        {
            get;
            private set;
        }

        // AddFirst Method
        public LinkedListNode<T> AddFirst(T node)
        {
            var newNode = new LinkedListNode<T>(node);
            if (Last == null)
            {
                First = newNode;
                Last = First;
            }
            else
            {
                First.Prev = newNode;
                newNode.Next = First;
                First = newNode;
            }
            return newNode;
        }

        // AddLast Method
        public LinkedListNode<T> AddLast(T node)
        {
            var newNode = new LinkedListNode<T>(node);
            if (First == null)
            {
                First = newNode;
                Last = First;
            }
            else
            {
                newNode.Prev = Last;
                Last.Next = newNode;
                Last = newNode;
            }

            return newNode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); 
    }

    // Given in Person.cs File
    // Create Class Person
    public class Person
    {
        public string firstName
        {
            get;
            set;
        }

        public string lastName
        {
            get;
            set;
        }

        public Person(string fName = "none", string lName = "none")
        {
            firstName = fName;
            lastName = lName;
        }

        public override string ToString() => $"{firstName}{lastName}";
    }
    class Program
    {
        // Referenced Program.cs File
        // Main Program Creates LinkedList for Different types of Objects
        // Hint: when (int, string or Person) items are displayed on the screen, they should appear in the opposite order.
        static void Main(string[] args)
        {
            // One LinkedList for Int's Use AddFirst Method 
            LinkedList<int> intList = new LinkedList<int>();

            // Add Numbers 100, 200, 300 
            intList.AddFirst(100);
            intList.AddFirst(200);
            intList.AddFirst(300);

            // Display the List Items on Screen
            foreach (int i in intList)
            {
                Console.WriteLine(i);
            }

            // One LinkedList for String's Use AddFirst Method
            LinkedList<string> stringList = new LinkedList<string>();

            // Add Strings "one", "two", "three"
            stringList.AddFirst("one");
            stringList.AddFirst("two");
            stringList.AddFirst("three");

            Console.WriteLine("--------------");

            // Display the List Items on Screen
            foreach (string s in stringList)
            {
                Console.WriteLine(s);
            }

            // One LinkedList for Person's Use AddFirst Method
            LinkedList<Person> personList = new LinkedList<Person>();

            // Add Persons with Names
            personList.AddFirst(new Person("Alex"," Auburn"));
            personList.AddFirst(new Person("Bob", " Brown"));
            personList.AddFirst(new Person("Chuck", " Chimney"));

            Console.WriteLine("--------------");

            // Display the List Items on Screen
            foreach (Person p in personList)
            {
                Console.WriteLine(p);
            }
        }
    }
}