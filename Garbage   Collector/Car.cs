using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGC
{
    public class Car
    {
        private int speed;
        private string name;
        public Car()
        {

        }
        public Car(string name, int speed)
        {
            this.name = name;
            this.speed = speed;
        }
        public override string ToString()
        {
            return $"{name} is going at a speed of {speed}";
        }
    }
}
