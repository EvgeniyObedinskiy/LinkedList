using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Model.LinkedList<int>();
            list.Add(2);
            list.Add(4);
            list.Add(6);
            list.Add(8);
            list.Add(200);

            foreach (var item in list) 
            {
                Console.WriteLine(item);
            }
            list.Delete(2);
            list.InsertAfter(4, 88);
            list.AppendHead(900);
            list.Add(50);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            list.Clear();
        }
    }
}
