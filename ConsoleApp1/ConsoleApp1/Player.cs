using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    class Player : Conditions
    {
        public string Name; // имя игрока

        public int SingleDeckShipCount;
        public int DoubleDeckShipCount;
        public int ThreeDeckShipCount;
        public int FourDeckShipCount;

        // поле защиты
        public char[,] MyField =
        {
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' }
        };

        // поле атаки
        public char[,] EnemyField =
        {
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' },
            {'~', '~', '~', '~', '~', '~', '~', '~', '~', '~' }
        };

        // установка однопалубных кораблей
        public void SetSingleDeckShip()
        {
            Console.Clear();
            while (SingleDeckShipCount < 4)
            {
                GeneralMethods.ShowField(MyField, Name);
                Console.WriteLine("Задайте координаты однопалубного корабля:\nИли напишите -назад- чтоб выбрать другие корабли");
                string coordinates = Console.ReadLine();
                coordinates = coordinates.ToUpper();
                if (coordinates.Contains("НАЗАД"))
                {
                    break;
                }
                int x = GeneralMethods.GetX(coordinates);
                int y = GeneralMethods.GetY(coordinates);
                if (coordinates.Length < 4 && x >= 0 && y >= 0 && SetShipsConditions(x, y, MyField))
                {
                    MyField[y, x] = 'H';
                    SingleDeckShipCount++;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Координаты не корректны!\nНажмите любую клавишу чтоб повторить попытку.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        // установка двупалубных кораблей
        public void SetDoubleDeckShip()
        {
            Console.Clear();
            while (DoubleDeckShipCount < 3)
            {
                GeneralMethods.ShowField(MyField, Name);
                Console.WriteLine("Задайте координаты построения двупалубного корабля:\nИли напишите -назад- чтоб выбрать другие корабли");
                string coordinates1 = Console.ReadLine();
                coordinates1 = coordinates1.ToUpper();
                if (coordinates1.Contains("НАЗАД"))
                {
                    break;
                }
                string coordinates2 = Console.ReadLine();
                coordinates2 = coordinates2.ToUpper();
                if (coordinates2.Contains("НАЗАД"))
                {
                    break;
                }
                int x1 = GeneralMethods.GetX(coordinates1);
                int y1 = GeneralMethods.GetY(coordinates1);
                int x2 = GeneralMethods.GetX(coordinates2);
                int y2 = GeneralMethods.GetY(coordinates2);

                if (x1 >= 0 && y1 >= 0 && x2 >= 0 && y2 >= 0 && SetShipsConditions(x1, y1, MyField) && SetShipsConditions(x2, y2, MyField) && LineDeck(x1, x2, y1, y2))
                {
                    MyField[y1, x1] = 'H';
                    MyField[y2, x2] = 'H';
                    DoubleDeckShipCount++;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Координаты не корректны!\nНажмите любую клавишу чтоб повторить попытку.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        // установка трехпалубных кораблей
        public void SetThreeDeckShip()
        {
            Console.Clear();
            while (ThreeDeckShipCount < 2)
            {
                GeneralMethods.ShowField(MyField, Name);
                Console.WriteLine("Задайте координаты построения трехпалубного корабля:\nИли напишите -назад- чтоб выбрать другие корабли");
                string coordinates1 = Console.ReadLine();
                coordinates1 = coordinates1.ToUpper();
                if (coordinates1.Contains("НАЗАД"))
                {
                    break;
                }
                string coordinates2 = Console.ReadLine();
                coordinates2 = coordinates2.ToUpper();
                if (coordinates2.Contains("НАЗАД"))
                {
                    break;
                }
                string coordinates3 = Console.ReadLine();
                coordinates3 = coordinates3.ToUpper();
                if (coordinates3.Contains("НАЗАД"))
                {
                    break;
                }
                int x1 = GeneralMethods.GetX(coordinates1);
                int y1 = GeneralMethods.GetY(coordinates1);
                int x2 = GeneralMethods.GetX(coordinates2);
                int y2 = GeneralMethods.GetY(coordinates2);
                int x3 = GeneralMethods.GetX(coordinates3);
                int y3 = GeneralMethods.GetY(coordinates3);

                if (x1 >= 0 && y1 >= 0 && x2 >= 0 && y2 >= 0 && x3 >= 0 && y3 >= 0 && SetShipsConditions(x1, y1, MyField) && SetShipsConditions(x2, y2, MyField) && SetShipsConditions(x3, y3, MyField) && LineDeck(x1, x2, x3, y1, y2, y3))
                {
                    MyField[y1, x1] = 'H';
                    MyField[y2, x2] = 'H';
                    MyField[y3, x3] = 'H';
                    ThreeDeckShipCount++;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Координаты не корректны!\nНажмите любую клавишу чтоб повторить попытку.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        // установка четырехпалубного корабля
        public void SetFourDeckShip()
        {
            Console.Clear();
            while (FourDeckShipCount < 1)
            {
                GeneralMethods.ShowField(MyField, Name);
                Console.WriteLine("Задайте координаты построения четырехпалубного корабля:\nИли напишите -назад- чтоб выбрать другие корабли");
                string coordinates1 = Console.ReadLine();
                coordinates1 = coordinates1.ToUpper();
                if (coordinates1.Contains("НАЗАД"))
                {
                    break;
                }
                string coordinates2 = Console.ReadLine();
                coordinates2 = coordinates2.ToUpper();
                if (coordinates2.Contains("НАЗАД"))
                {
                    break;
                }
                string coordinates3 = Console.ReadLine();
                coordinates3 = coordinates3.ToUpper();
                if (coordinates3.Contains("НАЗАД"))
                {
                    break;
                }
                string coordinates4 = Console.ReadLine();
                coordinates4 = coordinates4.ToUpper();
                if (coordinates4.Contains("НАЗАД"))
                {
                    break;
                }
                int x1 = GeneralMethods.GetX(coordinates1);
                int y1 = GeneralMethods.GetY(coordinates1);
                int x2 = GeneralMethods.GetX(coordinates2);
                int y2 = GeneralMethods.GetY(coordinates2);
                int x3 = GeneralMethods.GetX(coordinates3);
                int y3 = GeneralMethods.GetY(coordinates3);
                int x4 = GeneralMethods.GetX(coordinates4);
                int y4 = GeneralMethods.GetY(coordinates4);

                if (x1 >= 0 && y1 >= 0 && x2 >= 0 && y2 >= 0 && x3 >= 0 && y3 >= 0 && x4 >= 0 && y4 >= 0 && SetShipsConditions(x1, y1, MyField) && SetShipsConditions(x2, y2, MyField) && SetShipsConditions(x3, y3, MyField) && SetShipsConditions(x4, y4, MyField) && LineDeck(x1, x2, x3, x4, y1, y2, y3, y4))
                {
                    MyField[y1, x1] = 'H';
                    MyField[y2, x2] = 'H';
                    MyField[y3, x3] = 'H';
                    MyField[y4, x4] = 'H';
                    FourDeckShipCount++;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Координаты не корректны!\nНажмите любую клавишу чтоб повторить попытку.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        // автоматическая установка всех кораблей
        public void AutomaticShipInstallation()
        {
            Random random = new Random();
            int x = random.Next(0, 7);
            int y = random.Next(0, 7);
            bool direction = true;

            // установка четырехпалубного корабля
            while (FourDeckShipCount < 1)
            {
                switch (random.Next(0, 2))
                {
                    case 1:
                        direction = false;
                        break;
                }
                if (direction)
                {
                    MyField[y, x] = 'H';
                    MyField[y + 1, x] = 'H';
                    MyField[y + 2, x] = 'H';
                    MyField[y + 3, x] = 'H';
                    FourDeckShipCount++;
                }
                else
                {
                    MyField[y, x] = 'H';
                    MyField[y, x + 1] = 'H';
                    MyField[y, x + 2] = 'H';
                    MyField[y, x + 3] = 'H';
                    FourDeckShipCount++;
                }
            }

            // установка трехпалубных кораблей
            while (ThreeDeckShipCount < 2)
            {
                x = random.Next(0, 8);
                y = random.Next(0, 8);
                direction = true;
                switch (random.Next(0, 2))
                {
                    case 1:
                        direction = false;
                        break;
                }
                if (direction && SetShipsConditions(x, y, MyField) && SetShipsConditions(x, y + 1, MyField) && SetShipsConditions(x, y + 2, MyField))
                {
                    MyField[y, x] = 'H';
                    MyField[y + 1, x] = 'H';
                    MyField[y + 2, x] = 'H';
                    ThreeDeckShipCount++;
                }
                else if (direction == false && SetShipsConditions(x, y, MyField) && SetShipsConditions(x + 1, y, MyField) && SetShipsConditions(x + 2, y, MyField))
                {
                    MyField[y, x] = 'H';
                    MyField[y, x + 1] = 'H';
                    MyField[y, x + 2] = 'H';
                    ThreeDeckShipCount++;
                }
            }
            // установка двухпалубных кораблей
            while (DoubleDeckShipCount < 3)
            {
                x = random.Next(0, 9);
                y = random.Next(0, 9);
                direction = true;
                switch (random.Next(0, 2))
                {
                    case 1:
                        direction = false;
                        break;
                }
                if (direction && SetShipsConditions(x, y, MyField) && SetShipsConditions(x, y + 1, MyField))
                {
                    MyField[y, x] = 'H';
                    MyField[y + 1, x] = 'H';
                    DoubleDeckShipCount++;
                }
                else if (direction == false && SetShipsConditions(x, y, MyField) && SetShipsConditions(x + 1, y, MyField))
                {
                    MyField[y, x] = 'H';
                    MyField[y, x + 1] = 'H';
                    DoubleDeckShipCount++;
                }
            }
            // установка однопалубных кораблей
            while (SingleDeckShipCount < 4)
            {
                x = random.Next(0, 9);
                y = random.Next(0, 9);
                direction = true;
                switch (random.Next(0, 2))
                {
                    case 1:
                        direction = false;
                        break;
                }
                if (direction && SetShipsConditions(x, y, MyField))
                {
                    MyField[y, x] = 'H';
                    SingleDeckShipCount++;
                }
                else if (direction == false && SetShipsConditions(x, y, MyField))
                {
                    MyField[y, x] = 'H';
                    SingleDeckShipCount++;
                }
            }
        }
    }
}
