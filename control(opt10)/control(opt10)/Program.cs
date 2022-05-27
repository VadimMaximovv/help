using System;

namespace control_opt10_
{
    abstract class Transport
    {
        public string stamp;
        public string city_1;
        public string city_2;
        abstract public string Going();
    }

    class Car : Transport
    {
        public Car(string stamp, string city_1, string city_2)
        {
            this.city_1 = city_1;
            this.city_2 = city_2;
            this.stamp = stamp;
        }
        public override string Going()
        {
            return "Машина марки " + stamp + " едет из города " + city_1 + " в город " + city_2;
        }
    }

    class Train : Transport
    {
        public Train(string stamp, string city_1, string city_2)
        {
            this.city_1 = city_1;
            this.city_2 = city_2;
            this.stamp = stamp;
        }
        public override string Going()
        {
            return "Поезд №" + stamp + " едет из города " + city_1 + " в город " + city_2;
        }
    }

    class Express : Train
    {
        public delegate void Enter(string messange);
        public event Enter Notify;
        public Express(string stamp, string city_1, string city_2) : base(stamp, city_1, city_2)
        {
            this.city_1 = city_1;
            this.city_2 = city_2;
            this.stamp = stamp;
        }
        public new void Going()
        {
            Console.WriteLine($"Поезд экспрес № {stamp} едет из города {city_1} в город {city_2}");
            Notify?.Invoke("Поезд прибыл");
        }
    }
    class Program
    {
        static void Messange(string messange) => Console.WriteLine(messange);
        static void Main(string[] args)
        {
            Car c1 = new Car("Жигуль", "A", "B");
            Console.WriteLine(c1.Going());
            Train t1 = new Train("810", "C", "D");
            Console.WriteLine(t1.Going());
            Express ex1 = new Express("809", "X", "Y");
            ex1.Notify += Messange;
            ex1.Going();
        }
    }
}
