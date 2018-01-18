using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Practice__9
{
    class Program
    {
        static Point MakeList(ref int Count) // Создание циклического списка 
        {
            Console.Clear();
            bool ok;

            Console.WriteLine("Тип информационного поля int");
            do
            {
                Console.WriteLine("Введите количество объектов списка: ");
                ok = int.TryParse(Console.ReadLine(), out Count);
                if (!ok || Count <= 0) { Console.WriteLine("Некорректный ввод. Пожалуйста, введите натуральное число"); ok = false; }
            } while (!ok);

            int info = 1;
            Console.WriteLine("Элемент {0} добавлен", info);
            Point beg = MakePoint(info);//первый элемент
            Point r = beg;//переменная хранит адрес начала списка
            info++;
            for (int i = 1; i < Count; i++)
            {
                Console.WriteLine("Элемент {0} добавлен", info);
                //создаем элемент и добавляем в конец списка
                Point p = MakePoint(info);
                r.next = p;
                r = p;
                info++;
            }
            r.next = beg;
            Console.WriteLine();
            return beg;
        }

        static Point MakePoint(int d) // Создание элемента циклического списка списка 
        {
            Point p = new Point(d);
            return p;
        }

        static void ShowList(Point beg, int Size) // Вывод циклического списка списка 
        {
            //проверка наличия элементов в списке
            if (Size == 0)
            {
                Console.WriteLine("Cписок пуст");
                return;
            }
            Point p = beg;
            for (int i = 0; i < Size; i++)
            {
                Console.Write(p);
                p = p.next;//переход к следующему элементу
                Console.Write("=> ");
            }
            Console.CursorLeft = Console.CursorLeft - 4;
            Console.Write("    ");
            Console.WriteLine();
        }

        static Point DelElement(Point beg, ref int Size) // Поиск и Удаление объектов из циклического списка 
        {
            bool ok = false;
            int Curr;
            do
            {
                Console.WriteLine("Найти и удалить элемент: ");
                ok = int.TryParse(Console.ReadLine(), out Curr);
                if (!ok || Curr <= 0) { Console.WriteLine("Некорректный ввод. Пожалуйста, введите натуральное число"); ok = false; }
            } while (!ok);

            ok = false;
            if (beg.data != Curr) // Проверка, стоит ли элемент в "начале" списка
            {
                for (int i = 0; i < Size; i++) // Ищем нужный элемент в списке
                {
                    if (beg.data == Curr)
                    {
                        Curr = i; // Запоминаем номер
                        ok = true;
                        break;
                    }
                    beg = beg.next; // Переходим на начало
                }
                for (int i = 0; i < Curr - 1; i++) // Находим элемент идущий перед искомым 
                {
                    beg = beg.next;
                }
                beg.next = beg.next.next; // Пропускаем или "удаляем" нужный элемент
            }
            else // Если элемент первый
            {
                ok = true;
                for (int i = 0; i < Size - 1; i++) // Идем в "конец" списка
                {
                    beg = beg.next;                    
                }
                beg.next = beg.next.next; // Пропускаем первый элемент
                beg = beg.next;
            }
            if (ok == true) // Если элемент есть в списке и был удален, уменьшаем размер списка
            {
                Size--;
            }
            else // Иначе выводим сообщение о том что он не найден
            { Console.WriteLine("Элемент не найден"); }
            return beg;
        }

        static void Main(string[] args) // Основной листнинг программы 
        {
            Console.Clear();
            Console.WriteLine("Учебная практика №9, Власов Виктор");
            Console.WriteLine("Вариант: 14");
            Console.WriteLine("Рекурсивный метод создания циклического списка");
            int Count = 0;
            Point A = MakeList(ref Count);
            ShowList(A, Count);
            while (Count != 0)
            {
                A = DelElement(A, ref Count);
                ShowList(A, Count);
            }
            Console.ReadLine();
        }
    }
}
