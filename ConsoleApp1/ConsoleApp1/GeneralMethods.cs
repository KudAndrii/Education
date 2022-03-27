using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class GeneralMethods
    {
        // выводит необходимое поле на консоль
        public static void ShowField(char[,] field, string Name)
        {
            Console.WriteLine($"Поле игрока: {Name}");
            Console.WriteLine("   А Б В Г Д Е Ж З И К");
            for (int y = 0; y < field.GetLength(0); y++)
            {
                if (y < 9)
                {
                    Console.Write((y + 1) + " ");
                    for (int x = 0; x < field.GetLength(1); x++)
                    {
                        Console.Write(" " + field[y, x]);
                    }
                }
                else
                {
                    Console.Write(y + 1);
                    for (int x = 0; x < field.GetLength(1); x++)
                    {
                        Console.Write(" " + field[y, x]);
                    }
                }
                Console.WriteLine();
            }
        }

        // определяет координату Х
        public static int GetX(string point)
        {
            if (point.Length >= 4)
            {
                return -1;
            }
            int x = -1;
            int index = 0;
            for (int i = 0; i < point.Length; i++)
            {
                switch (point[i])
                {
                    case 'А':
                        x = 0;
                        index++;
                        break;
                    case 'Б':
                        x = 1;
                        index++;
                        break;
                    case 'В':
                        x = 2;
                        index++;
                        break;
                    case 'Г':
                        x = 3;
                        index++;
                        break;
                    case 'Д':
                        x = 4;
                        index++;
                        break;
                    case 'Е':
                        x = 5;
                        index++;
                        break;
                    case 'Ж':
                        x = 6;
                        index++;
                        break;
                    case 'З':
                        x = 7;
                        index++;
                        break;
                    case 'И':
                        x = 8;
                        index++;
                        break;
                    case 'К':
                        x = 9;
                        index++;
                        break;
                }
            }
            if (index > 1)
            {
                x = -1;
            }
            return x;
        }

        // определяет координату Y
        public static int GetY(string point)
        {
            if (point.Length >= 4)
            {
                return -1;
            }
            int y = -1;
            if (point.Contains("10"))
            {
                y = 9;
            }
            else if (point.Contains("1"))
            {
                y = 0;
            }
            else if (point.Contains("2"))
            {
                y = 1;
            }
            else if (point.Contains("3"))
            {
                y = 2;
            }
            else if (point.Contains("4"))
            {
                y = 3;
            }
            else if (point.Contains("5"))
            {
                y = 4;
            }
            else if (point.Contains("6"))
            {
                y = 5;
            }
            else if (point.Contains("7"))
            {
                y = 6;
            }
            else if (point.Contains("8"))
            {
                y = 7;
            }
            else if (point.Contains("9"))
            {
                y = 8;
            }
            return y;
        }

        // проверка наличия кораблей в поле
        public static bool ShipAvailabilityCheck(char[,] Field)
        {
            bool Empty = true;
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if (Field[i, j] == 'H')
                    {
                        Empty = false;
                        return Empty;
                    }
                }
            }
            return Empty;
        }

        // проверка соседних палуб
        public static bool CheckNearbyDecks(int x, int y, char[,] DefensePlayerMyField)
        {
            bool result = false;


            bool result2;
            bool result4;
            bool result6;
            bool result8;
            try
            {
                result2 = DefensePlayerMyField[y - 1, x] != 'H';
            }
            catch (IndexOutOfRangeException)
            {
                result2 = true;
            }
            try
            {
                result4 = DefensePlayerMyField[y, x + 1] != 'H';
            }
            catch (IndexOutOfRangeException)
            {
                result4 = true;
            }
            try
            {
                result6 = DefensePlayerMyField[y, x - 1] != 'H';
            }
            catch (IndexOutOfRangeException)
            {
                result6 = true;
            }
            try
            {
                result8 = DefensePlayerMyField[y + 1, x] != 'H';
            }
            catch (IndexOutOfRangeException)
            {
                result8 = true;
            }
            if (result2 && result4 && result6 && result8)
            {
                result = true;
            }

            return result;
        }

        // проверка всего поля на наличие добитых кораблей
        public static bool CheckWholeField(char[,] DefensePlayerMyField)
        {
            bool result = true;
            int index = 0;

            for (int i = 0; i < DefensePlayerMyField.GetLength(0); i++)
            {
                for (int j = 0; j < DefensePlayerMyField.GetLength(1); j++)
                {
                    if (DefensePlayerMyField[i, j] == 'x' && CheckNearbyDecks(j, i, DefensePlayerMyField) == false)
                    {
                        index++;
                    }
                }
            }
            if (index > 0)
            {
                result = false;
            }
            return result;
        }

        // определение заведомо пустых ячеек
        public static void EmptyCell(int x, int y, char[,] DefensePlayerMyField, char[,] AttackPlayerEnemyField)
        {
            try
            {
                if (DefensePlayerMyField[y - 1, x - 1] == '~')
                {
                    DefensePlayerMyField[y - 1, x - 1] = 'O';
                    AttackPlayerEnemyField[y - 1, x - 1] = 'O';
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (DefensePlayerMyField[y - 1, x] == '~')
                {
                    DefensePlayerMyField[y - 1, x] = 'O';
                    AttackPlayerEnemyField[y - 1, x] = 'O';
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (DefensePlayerMyField[y - 1, x + 1] == '~')
                {
                    DefensePlayerMyField[y - 1, x + 1] = 'O';
                    AttackPlayerEnemyField[y - 1, x + 1] = 'O';
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (DefensePlayerMyField[y, x - 1] == '~')
                {
                    DefensePlayerMyField[y, x - 1] = 'O';
                    AttackPlayerEnemyField[y, x - 1] = 'O';
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (DefensePlayerMyField[y, x + 1] == '~')
                {
                    DefensePlayerMyField[y, x + 1] = 'O';
                    AttackPlayerEnemyField[y, x + 1] = 'O';
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (DefensePlayerMyField[y + 1, x - 1] == '~')
                {
                    DefensePlayerMyField[y + 1, x - 1] = 'O';
                    AttackPlayerEnemyField[y + 1, x - 1] = 'O';
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (DefensePlayerMyField[y + 1, x] == '~')
                {
                    DefensePlayerMyField[y + 1, x] = 'O';
                    AttackPlayerEnemyField[y + 1, x] = 'O';
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (DefensePlayerMyField[y + 1, x + 1] == '~')
                {
                    DefensePlayerMyField[y + 1, x + 1] = 'O';
                    AttackPlayerEnemyField[y + 1, x + 1] = 'O';
                }
            }
            catch (IndexOutOfRangeException) { }
        }
    }
}
