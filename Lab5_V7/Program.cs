namespace Lab5_V7
{
    internal class TCircle<T>
    {
        T radius;
        static double kut;
        public T Radius 
        {
            get { return radius; }
            set { radius = value; }
        }
        public TCircle()
        {
            radius = default(T);
        }
        public TCircle(T r)
        {
            radius = r;
        }
        public TCircle(TCircle<T> circle)
        {
            radius = circle.radius;
        }
        public static void InputKut()
        {
            Console.WriteLine("Введіть кут сектора в градусах:");
            kut = Convert.ToDouble(Console.ReadLine());
        }
        public void Input()
        {
            Console.WriteLine("Введіть радіус кола:");
            radius = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

        }
        public void Output()
        {
            Console.WriteLine($"\nРадіус кола: {radius}\n" +
                              $"Довжина кола: {LengthCircle()}\n" +
                              $"Площа круга: {Sq()}\n" +
                              $"Площа сектора (при куті {kut}): {Sector(kut)}");
        }
        public double Sq()
        {
            double r = Convert.ToDouble(radius);
            return Math.Round(Math.PI * r * r, 3);
        }
        public double Sector(double kut)
        {
            double r = Convert.ToDouble(radius);
            return Math.Round((Math.PI * r * r * kut) / 360, 3);
        }
        public double LengthCircle()
        {
            double r = Convert.ToDouble(radius);
            return Math.Round(2 * Math.PI * r, 3);
        }
        public void Porivn(TCircle<T> other)
        {
            double r1 = Convert.ToDouble(radius);
            double r2 = Convert.ToDouble(other.radius);

            if (r1 == r2)
            {
                Console.WriteLine("Кола рівні");
            }
            else if (r1 >= r2)
            {
                Console.WriteLine($"Коло з радіусом {r1} більше кола з радіусом {r2}.");
            }
            else
            {
                Console.WriteLine($"Коло з радіусом {r2} більше кола з радіусом {r1}.");
            }
        }
        public static TCircle<T> operator +(TCircle<T> c1, TCircle<T> c2)
        {
            double plus = Convert.ToDouble(c1.radius) + Convert.ToDouble(c2.radius);
            return new TCircle<T>((T)Convert.ChangeType(plus, typeof(T)));
        }

        public static TCircle<T> operator -(TCircle<T> c1, TCircle<T> c2)
        {
            double minus = Convert.ToDouble(c1.radius) - Convert.ToDouble(c2.radius);
            return new TCircle<T>((T)Convert.ChangeType(minus, typeof(T)));
        }

        public static TCircle<T> operator *(TCircle<T> c, double value)
        {
            double mnogennya = Convert.ToDouble(c.radius) * value;
            return new TCircle<T>((T)Convert.ChangeType(mnogennya, typeof(T)));
        }
    }
internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            TCircle<double> circle1 = new TCircle<double>(5);
            TCircle<double> circle2 = new TCircle<double>();

            circle1.Input();
            circle2.Input();

            TCircle<double>.InputKut();

            circle1.Output();
            circle2.Output();

            circle1.Porivn(circle2);

            Console.WriteLine("\nДодавання радіусів:");
            TCircle<double> circle3 = circle1 + circle2;
            circle3.Output();

            Console.WriteLine("\nВіднімання радіусів:");
            double R4 = Math.Max(circle1.Radius, circle2.Radius) - Math.Min(circle1.Radius, circle2.Radius);
            TCircle<double> circle4 = new TCircle<double>(R4);
            circle4.Output();

            Console.WriteLine("\nМноження радіус кола1 на число. Введіть число:");
            double number = Convert.ToDouble(Console.ReadLine());
            TCircle<double> circle5 = circle1 * number;
            circle5.Output();
        }
    }
}
