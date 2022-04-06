using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    class GameProcess
    {
        // установка всех кораблей заданного игрока
        public static void SetAllShips(Player Player)
        {
            while (Player.SingleDeckShipCount < 4 || Player.DoubleDeckShipCount < 3 || Player.ThreeDeckShipCount < 2 || Player.FourDeckShipCount < 1)
            {
                Console.WriteLine("Выберите, какие из кораблей вы хотите установить:");
                if (Player.SingleDeckShipCount < 4)
                {
                    Console.WriteLine("1 - однопалубные");
                }
                if (Player.DoubleDeckShipCount < 3)
                {
                    Console.WriteLine("2 - двупалубные");
                }
                if (Player.ThreeDeckShipCount < 2)
                {
                    Console.WriteLine("3 - трехпалубные");
                }
                if (Player.FourDeckShipCount < 1)
                {
                    Console.WriteLine("4 - четырехпалубный");
                }
                Console.WriteLine("0 - чтоб установить корабли автоматически");
                string number = Console.ReadLine();
                int SetShip = 0;
                try
                {
                    SetShip = Convert.ToInt32(number);
                }
                catch (Exception)
                {
                    Console.WriteLine("Попробуйте еще раз, введите цифру от 0 до 4");
                }
                if (SetShip >= 0 && SetShip < 5)
                {
                    switch (SetShip)
                    {
                        case 0:
                            Player.AutomaticShipInstallation();
                            break;
                        case 1:
                            Player.SetSingleDeckShip();
                            break;
                        case 2:
                            Player.SetDoubleDeckShip();
                            break;
                        case 3:
                            Player.SetThreeDeckShip();
                            break;
                        case 4:
                            Player.SetFourDeckShip();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Попробуйте еще раз, введите цифру от 0 до 4");
                }
            }
        }

        // процесс атаки одного из игроков при игре вдвоем
        public static void AttackPlayer(Player AttackPlayer, Player DefensePlayer)
        {
            bool missed = false;
            while (missed == false)
            {
                Console.Clear();
                Console.WriteLine("Атакуйте поле соперника.");
                GeneralMethods.ShowField(AttackPlayer.MyField, AttackPlayer.Name);
                GeneralMethods.ShowField(AttackPlayer.EnemyField, AttackPlayer.Name);
                Console.Write("Введите координаты:");
                string coordinates = Console.ReadLine();
                Console.WriteLine();
                coordinates = coordinates.ToUpper();
                int x = GeneralMethods.GetX(coordinates);
                int y = GeneralMethods.GetY(coordinates);
                if (x >= 0 && y >= 0 && DefensePlayer.MyField[y, x] != 'O')
                {
                    if (DefensePlayer.MyField[y, x] == 'H')
                    {
                        AttackPlayer.EnemyField[y, x] = 'x';
                        DefensePlayer.MyField[y, x] = 'x';
                    }
                    else if (DefensePlayer.MyField[y, x] == '~')
                    {
                        AttackPlayer.EnemyField[y, x] = 'O';
                        DefensePlayer.MyField[y, x] = 'O';
                        missed = true;
                    }
                }
                else
                {
                    Console.WriteLine("Координаты не корректны!\nНажмите любую клавишу чтоб повторить попытку.");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (GeneralMethods.CheckWholeField(DefensePlayer.MyField))
                {
                    for (int i = 0; i < DefensePlayer.MyField.GetLength(0); i++)
                    {
                        for (int j = 0; j < DefensePlayer.MyField.GetLength(1); j++)
                        {
                            if (DefensePlayer.MyField[i, j] == 'x' && GeneralMethods.CheckNearbyDecks(j, i, DefensePlayer.MyField))
                            {
                                DefensePlayer.MyField[i, j] = 'X';
                                AttackPlayer.EnemyField[i, j] = 'X';
                                GeneralMethods.EmptyCell(j, i, DefensePlayer.MyField, AttackPlayer.EnemyField);
                            }
                        }
                    }
                }
                if (GeneralMethods.ShipAvailabilityCheck(AttackPlayer.MyField) || GeneralMethods.ShipAvailabilityCheck(DefensePlayer.MyField))
                {
                    break;
                }
            }
        }
    }
}
