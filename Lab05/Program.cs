namespace Example1
{
    class Square
    {
        public double Number { get; set; }
        public Square(double num)
        {
            Number = num;
        }

        public double Sq()
        {
            return Number * Number;
        }
    }
    class Array<T>
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

            Array<int> a1 = new Array<int>(1,2,3,4,5);
            Array<double> a2 = new Array<double>(1.0, 2.0, 3.0, 4.0, 5.0);
            Array<Square> a3 = new Array<Square>(new Square(1), new Square(2));

            Console.WriteLine("Int:");
            for (int i = 0; i < a1.Length ; i++)
            {
                Console.WriteLine(a1[i]);
            }

            Console.WriteLine("Double:");
            for (int i = 0; i < a2.Length; i++)
            {
                Console.WriteLine(a2[i]);
            }

            Console.WriteLine("Square:");
            for (int i = 0; i < a3.Length; i++)
            {
                Console.WriteLine("Число: {0}; В квадраті: {1}", a3[i].Number, a3[i].Sq());
            }
        }
    }
}
