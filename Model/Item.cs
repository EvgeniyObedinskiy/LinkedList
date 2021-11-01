using System;
using System.Collections;

namespace LinkedList.Model
{
    ///ячейка сиска.
    public class Item<T> 
    {

        private T data = default(T); 
        /// <summary>
        /// Данные хранимые в ячейке.
        /// </summary>
        
        public T Data 
        {
            get { return data; }

            set 
            {
                data = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
        /// <summary>
        /// Следующая ячейка.
        /// </summary>
        public Item<T> Next { get; set; }

        public Item(T data) 
        {
            Data = data;
        }
        public override string ToString()
        {
            return Data.ToString();
        }


    }


}
