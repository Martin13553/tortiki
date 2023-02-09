namespace тортики2snl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                menu1();
                Console.WriteLine("Сделать еще один заказ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                menu();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    menu1();
                }
                Console.CursorVisible = false;
            }
            Console.Clear();
        }
        static void menu()
        {
            Console.WriteLine("Заказ тортов");
            Console.WriteLine("Выберите параметры торта");
            Console.WriteLine("  Форма");
            Console.WriteLine("  Размер");
            Console.WriteLine("  Вкус");
            Console.WriteLine("  Конец заказа");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Цена: ");
            Console.WriteLine("Ваш торт: ");
        }
        static void menu1()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            int position = 2;
            int cena = 0;
            List<string> names = new List<string>();
            while (true)
            {
                Console.Clear();
                menu();
                position = Pos(key, position);
                if (position < 3)
                {
                    position = 2;
                }
                if (position > 5)
                {
                    position = 5;
                }
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                if (key.Key == ConsoleKey.Enter && position == 5)
                {
                    Console.Clear();

                    break;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    var a = Menu2(key, position);
                    Console.Clear();
                    menu();
                    cena = cena + a.Item1;
                    names.Add(a.Item2);
                }
                Console.SetCursorPosition(7, 11);
                Console.WriteLine(cena);
                Console.SetCursorPosition(11, 12);
                foreach (string i in names)
                {
                    Console.Write(i);
                    Console.Write(", ");
                }
                ConsoleKeyInfo keyA = Console.ReadKey();
                key = keyA;
                Console.Clear();
            }
            Console.Clear();
/*            zakaZA_NASHIH.full(cena, names);*/
        }
        static int Pos(ConsoleKeyInfo key2, int pos2)
        {
            if (key2.Key == ConsoleKey.DownArrow)
            {
                pos2++;
            }
            if (key2.Key == ConsoleKey.UpArrow)
            {
                pos2--;
            }
            return pos2;
        }
        static zakaZA_NASHIH Menu(int posin)
        {
            zakaZA_NASHIH one = new zakaZA_NASHIH();
            one.name[0] = "Круглый";
            one.name[1] = "квадратный";
            one.name[2] = "Треугольный";
            one.name[3] = "Особая";

            one.cost[0] = 500;
            one.cost[1] = 500;
            one.cost[2] = 500;
            one.cost[3] = 800;


            zakaZA_NASHIH two = new zakaZA_NASHIH();
            two.name[0] = "Маленький";
            two.name[1] = "Cредний";
            two.name[2] = "Большой";
            two.name[3] = "На заказ";
           
            two.cost[0] = 1000;
            two.cost[1] = 1500;
            two.cost[2] = 2000;
            two.cost[3] = 3000;


            zakaZA_NASHIH three = new zakaZA_NASHIH();
            three.name[0] = "Ваниль";
            three.name[1] = "Шоколад";
            three.name[2] = "Карамель";
            three.name[3] = "Ягода";

            three.cost[0] = 100;
            three.cost[1] = 150;
            three.cost[2] = 300;
            three.cost[3] = 350;


            zakaZA_NASHIH[] zakaz = new zakaZA_NASHIH[] { one, two, three};
            zakaZA_NASHIH part_of_menu = zakaz[posin];
            return part_of_menu;
        }
        static Tuple<int, string> Menu2(ConsoleKeyInfo key1, int pos1)
        {
            string elements = "";
            int summ = 0;
            int posA = 0;
            string str = "";
            int integer = 0;
            while (true)
            {
                int posout = pos1 - 2;
                zakaZA_NASHIH menushka = Menu(posout);
                for (int i = 0; i < 5; i++)
                {
                    str = menushka.name[i];
                    integer = menushka.cost[i];
                    Console.Write("  ");
                    Console.Write(str);
                    Console.Write(" - ");
                    Console.WriteLine(integer);
                }

                posA = Pos(key1, posA);
                if (posA < 0)
                {
                    posA = 0;
                }
                if (posA > 4)
                {
                    posA = 4;
                }
                Console.SetCursorPosition(0, posA);
                Console.WriteLine("->");
                ConsoleKeyInfo keyA = Console.ReadKey();
                key1 = keyA;
                Console.Clear();
                if (keyA.Key == ConsoleKey.Enter)
                {
                    summ = menushka.cost[posA];
                    elements = menushka.name[posA];
                    break;
                }
            }
            return Tuple.Create(summ, elements);
        }
        public static void full(int sumin, List<string> cake)
        {
            string a = string.Join(", ", cake);
            string path = "C:\\Рабочий стол\\cake\\Заказ_торта.txt";
            File.AppendAllText(path, "Заказ от: " + DateTime.Today + "\n");
            File.AppendAllText(path, "Ваш торт: " + a + "\n");
            File.AppendAllText(path, "Сумма заказа: " + sumin + "\n" + "\n");
        }
    }
} 