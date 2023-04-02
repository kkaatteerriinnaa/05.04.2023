using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30._03._23_HW
{
    class Program
    {
        public abstract class Mediator
        {
            public abstract void SendMess(string sms, Dispatch dispatcher);
        }
        public abstract class Dispatch
        {
            private Mediator mediator { set; get; }
            public Dispatch(Mediator m) => mediator = m;
            public abstract void Message(string temp);

        }
        public class Airplane : Dispatch
        {

            public Airplane(Mediator mediator) : base(mediator) { }
            public override void Message(string temp) => Console.WriteLine($"Сообщение для самолета:{temp}");
        }
        public class Helicopter : Dispatch
        {
            public Helicopter(Mediator mediator) : base(mediator) { }
            public override void Message(string temp) => Console.WriteLine($"Сообщение для вертолета :{temp}");
        }
        public class Rocket : Dispatch
        {
            public Rocket(Mediator mediator) : base(mediator) { }
            public override void Message(string temp) => Console.WriteLine($"Сообщение для ракеты:{temp}");
        }
        public class Dispatcher : Mediator
        {
            public Dispatch airplane { set; get; }
            public Dispatch rocket { set; get; }
            public Dispatch helicopter { set; get; }
            public Dispatcher() { }
            public override void SendMess(string message, Dispatch dispatcher)
            {
                if (airplane == dispatcher)
                    airplane.Message(message);
                else if (rocket == dispatcher)
                    rocket.Message(message);
                else if (helicopter == dispatcher)
                    helicopter.Message(message);
            }
        }
        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();
            Dispatch airplane = new Airplane(dispatcher);
            Dispatch helicopter = new Helicopter(dispatcher);
            Dispatch rocket = new Rocket(dispatcher);
        }
    }
}