using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Conditions
    {
        // проверка линейности установки кораблей
        private protected bool LineDeck (int x1, int x2, int y1, int y2)
        {
            bool result = false;
            if (((x1 - x2) == 1) || ((x1 - x2) == -1) || ((y1 - y2) == 1) || ((y1 - y2) == -1))
            {
                result = true;
            }
            return result;
        }
        private protected bool LineDeck(int x1, int x2, int x3, int y1, int y2, int y3)
        {
            bool result = false;
            if ((((x1 - x2) == 1) && ((x1 - x3) == 2)) || (((x1 - x2) == -1) && ((x1 - x3) == -2)) || (((y1 - y2) == 1) && ((y1 - y3) == 2)) || (((y1 - y2) == -1) && ((y1 - y3) == -2)))
            {
                result = true;
            }
            return result;
        }
        private protected bool LineDeck(int x1, int x2, int x3, int x4, int y1, int y2, int y3, int y4)
        {
            bool result = false;
            if ((((x1 - x2) == 1) && ((x1 - x3) == 2) && ((x1 - x4) == 3)) || (((x1 - x2) == -1) && ((x1 - x3) == -2) && ((x1 - x4) == -3)) || (((y1 - y2) == 1) && ((y1 - y3) == 2) && ((y1 - y4) == 3)) || (((y1 - y2) == -1) && ((y1 - y3) == -2) && ((y1 - y4) == -3)))
            {
                result = true;
            }
            return result;
        }

        // проверка условий для однопалубного или первой клетки иного корабля
        private protected bool SetShipsConditions(int x, int y, char [,] MyField)
        {
            bool result = false;
            bool result1;
            bool result2;
            bool result3;
            bool result4;
            bool result5;
            bool result6;
            bool result7;
            bool result8;
            bool result9;
            try
            {
                result1 = MyField[y - 1, x + 1] != 'H';
            }
            catch (IndexOutOfRangeException)
            {
                result1 = true;
            }
            try
            {
                result2 = MyField[y - 1, x] != 'H';
            }
            catch (IndexOutOfRangeException)
            {
                result2 = true;
            }
            try
            {
                result3 = MyField[y - 1, x - 1] != 'H';
            }
            catch (IndexOutOfRangeException)
            {
                result3 = true;
            }
            try
            {
                result4 = MyField[y, x + 1] != 'H';
            }
            catch (IndexOutOfRangeException)
            {
                result4 = true;
            }
            try
            {
                result5 = MyField[y, x] != 'H';
            }
            catch (IndexOutOfRangeException)
            {
                result5 = false;
            }
            try
            {
                result6 = MyField[y, x - 1] != 'H';
            }
            catch (IndexOutOfRangeException)
            {
                result6 = true;
            }
            try
            {
                result7 = MyField[y + 1, x + 1] != 'H';
            }
            catch (IndexOutOfRangeException)
            {
                result7 = true;
            }
            try
            {
                result8 = MyField[y + 1, x] != 'H';
            }
            catch (IndexOutOfRangeException)
            {
                result8 = true;
            }
            try
            {
                result9 = MyField[y + 1, x - 1] != 'H';
            }
            catch (IndexOutOfRangeException)
            {
                result9 = true;
            }
            if (result1 && result2 && result3 && result4 && result5 && result6 && result7 && result8 && result9)
            {
                result = true;
            }
            return result;
        }

    }
}
