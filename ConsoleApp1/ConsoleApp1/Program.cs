using System;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            Player Player1 = new Player();
            Player Player2 = new Player();
            int players = 0;
            Console.WriteLine("Доброго времени суток, вас приветствует консольный морской бой от создателей calculator1 & calculator2.");
            /*
            // выбор количества игроков
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Выберите количество игроков (1 или 2)");
                try
                {
                    players = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (players != 1 && players != 2)
                    {
                        Console.WriteLine("На данном устройстве возможно играть либо вдвоем, либо в одиночку");
                        i--;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    i--;
                }
            }
            Console.Clear();

            if (players == 1)
            {
                Console.WriteLine("Введите имя игрока:");
                Player1.Name = Console.ReadLine();

                // размещение кораблей игрока №1 при игре в одиночку
                GameProcess.SetAllShips(Player1);
            }
            else
            {*/
                Console.WriteLine("Введите имя первого игрока:");
                Player1.Name = Console.ReadLine();
                Console.Clear();

                // размещение кораблей игрока №1 при игре вдвоем
                GameProcess.SetAllShips(Player1);

                Console.Clear();

                Console.WriteLine("Введите имя второго игрока:");
                Player2.Name = Console.ReadLine();

                // размещение кораблей игрока №2
                GameProcess.SetAllShips(Player2);

                // процесс игры (поочередная атака каждого из игроков)
                while (GeneralMethods.ShipAvailabilityCheck(Player1.MyField) == false && GeneralMethods.ShipAvailabilityCheck(Player2.MyField) == false)
                {
                    Console.Clear();
                    Console.WriteLine($"Нажмите любую клавишу, {Player1.Name}, чтоб приступить к атаке:");
                    Console.ReadKey();
                    GameProcess.AttackPlayer(Player1, Player2);
                if (GeneralMethods.ShipAvailabilityCheck(Player2.MyField))
                {
                    break;
                }
                    Console.Clear();
                    Console.WriteLine($"Нажмите любую клавишу, {Player2.Name}, чтоб приступить к атаке:");
                    Console.ReadKey();
                    GameProcess.AttackPlayer(Player2, Player1);
                if (GeneralMethods.ShipAvailabilityCheck(Player1.MyField))
                {
                    break;
                }
            }

                // результаты
                if (GeneralMethods.ShipAvailabilityCheck(Player1.MyField))
                {
                    Console.WriteLine($"Поздравляем, {Player2.Name}, вы победили!!!");
                }
                else if (GeneralMethods.ShipAvailabilityCheck(Player2.MyField))
                {
                    Console.WriteLine($"Поздравляем, {Player1.Name}, вы победили!!!");
                }
                else
                {
                    Console.WriteLine("ЧТо- то пошло не так =(");
                }
            //}
        }
    }
}
