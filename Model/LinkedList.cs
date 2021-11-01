using System;
using System.Collections;


namespace LinkedList.Model
{
    /// <summary>
    /// Односвязный список.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : IEnumerable
    {
        /// <summary>
        /// Первый элемент списка.
        /// </summary>
        public Item<T> Head { get; private set; }
        /// <summary>
        /// Последний элемент списка.
        /// </summary>
        public Item<T> Tail { get; private set; }
        /// <summary>
        /// Количество элементов в списке.
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Конструктор пустого списка.
        /// </summary>
        public LinkedList() 
        {
            Clear();
        }
        /// <summary>
        /// Конструктор списка с начальным элементом.
        /// </summary>
        /// <param name="data"></param>
        public LinkedList(T data) 
        {
            
            SetHeadAndTail(data);
        }
        /// <summary>
        /// Добавить элемент в конец списка.
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data) 
        {
            var item = new Item<T>(data);
            if (Tail != null)
            {
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else 
            {
                SetHeadAndTail(data);
            }
        }
        /// <summary>
        /// Удалить первое вхождение данных в список.
        /// А потом все по воли Garbage Collect-ора
        /// </summary>
        /// <param name="data"></param>
        public void Delete(T data) 
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }

                var current = Head;
                var previous = Head;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
            }
            else 
            {
                SetHeadAndTail(data);
            }

        }
        /// <summary>
        /// Добавление в начало.
        /// </summary>
        /// <param name="data"></param>
        public void AppendHead(T data) 
        {
            var item = new Item<T>(data) 
            { Next = Head };
            Head = item;
            Count++;
        }
        /// <summary>
        /// Добавление элемента после указанного элемна, можно добавить только в середину.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        public void InsertAfter(T target, T data) 
        {
            if (Head != null)
            {
                
                var current = Head;
                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        var item = new Item<T>(data);
                        item.Next = current.Next;
                        current.Next = item;
                        Count++;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }

            }
            else
            {
                // Если список пуст то...
            }
        }

        /// <summary>
        /// Очистить Список.
        /// </summary>
        public void Clear() 
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        private void SetHeadAndTail(T data) 
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        /// <summary>
        /// Перечисление всех элементов.
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null) 
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public override string ToString()
        {
            return "Linked list: " + Count + "element";
        }
    }
}
