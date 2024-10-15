namespace Example2
{
    class Array<T> where T:IComparable
    {
        T[] elements;
        public Array(params T[] args)
        {
            elements = new T[args.Length];
            args.CopyTo(elements, 0);
        }
        public T this[int index]
        {
            set
            {
                if (index < 0 || index >= elements.Length)
                    throw new Exception("Індекс ел. виходить за межі масиву.");
                elements[index] = value;
            }
            get
            {
                if (index < 0 || index >= elements.Length)
                    throw new Exception("Індекс ел. виходить за межі масиву.");
                return elements[index];
            }
        }
        public int countGreaterThan(T elem)
        {
            int count = 0;
            foreach (T e in elements)
                if (e.CompareTo(elem) > 0)
                    count++;
            return count;
        }
        public int Length
        {
            get { return elements.Length; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int count1, count2;
            Array<int> a1 = new Array<int>(1, 2, 3, 4, 5);
            Array<double> a2 = new Array<double>(1.1, 2.2, 3.0, 3.5, 4.0, 5.0);

            Console.WriteLine("Int:");
            for (int i = 0; i < a1.Length; i++)
            {
                Console.WriteLine(a1[i]);
            }

            Console.WriteLine("Double:");
            for (int i = 0; i < a2.Length; i++)
            {
                Console.WriteLine(a2[i]);
            }

            count1 = a1.countGreaterThan(3);
            Console.WriteLine($"К-ть чисел в а1, які більші за 3: {count1}");
            count2 = a2.countGreaterThan(3);
            Console.WriteLine($"К-ть чисел в а2, які більші за 3.0: {count2}");
        }
    }
}
