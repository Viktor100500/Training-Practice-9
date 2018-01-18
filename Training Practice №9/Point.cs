using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Practice__9
{
    class Point
    {
        public int data; //информационное поле
        public Point next;//адресное поле

        public Point()//конструктор без параметров
        {
            data = 0;
            next = null;
        }
        public Point(int d)//конструктор с параметрами
        {
            data = d;
            next = null;
        }
        public override string ToString()
        {
            return data + "  ";
        }
    }
}
