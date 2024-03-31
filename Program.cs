using System; //เรียกใช้System
using System.Threading; //เรียกใช้Threading

namespace XO_Game_II
{
    class Program
    {
        //กำหนดแอตทริบิวต์ที่ใช้
        static char[] point = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; //ตำแหน่ง x o ในกระดาน
        static int player = 1; //ระบุผู้เล่น
        static int number = 0/*รับตำแหน่ง x o ในกระดาน*/, n = 0; //ระบุตำแหน่งชื่อผู้เล่น
        static int selectplayer, exit = 1;
        static string[] playername = { "1", "2" }; //ชื่อผู้เล่น 
        static int flag = 0; //หาผู้ชนะ

        static void Main(string[] args) //เมธอดMain
        {
            do
            {
                do
                {
                    Console.Clear(); //เคลียจอ
                    Console.WriteLine("\n"); //เว้นบันทัด
                    Console.WriteLine("***********************************************"); //ข้อความที่แสดงบนจอ
                    Console.WriteLine("\n                     XO Game\n"); //ข้อความที่แสดงบนจอ
                    Console.WriteLine("***********************************************\n"); //ข้อความที่แสดงบนจอ
                    Console.Write("        Single player enter number 1\n        Two player enter number 2\n\n        Enter number : "); //ข้อความที่แสดงบนจอ
                    try
                    {
                        selectplayer = int.Parse(Console.ReadLine()); //รับชื่อผู้เล่น
                    }
                    catch
                    {
                        Console.Clear(); //เคลียจอ
                        Console.WriteLine("\n\n          Sorry please enter number 1 or 2\n"); //ข้อความที่แสดงบนจอ
                        Console.WriteLine("          Please wait 3 second board is loading again....."); //ข้อความที่แสดงบนจอ
                        Thread.Sleep(3000); //หยุดการทำงาน3วิ
                    }
                    

                    if (selectplayer == 1) //ตรวจสอบว่าเล่นคนเดียว
                    {
                        imputname1(); //เรียกใช้เมธอด imputnmae1
                        break; //ออกจากลูบ
                    }
                    else if (selectplayer == 2)//ตรวจสอบว่าเล่นสองคน
                    {
                        imputname2(); //เรียกใช้เมธอด imputnmae2
                        break; //ออกจากลูบ
                    }
                    else
                    {
                        Console.Clear(); //เคลียจอ
                        Console.WriteLine("\n\n          Sorry please enter number 1 or 2\n"); //ข้อความที่แสดงบนจอ
                        Console.WriteLine("          Please wait 3 second board is loading again....."); //ข้อความที่แสดงบนจอ
                        Thread.Sleep(3000); //หยุดการทำงาน3วิ
                    }
                } while (true);

                do //ลูบการทำงานของเกม
                {
                    if (selectplayer == 1) //ตรวจสอบจำนวนผู้เล่น
                    {
                        workingcom(); //เรียกใช้เมธอด workingcom
                    }
                    else 
                    {
                        working(); //เรียกใช้เมธอด working
                    }
                    try //ตรวจจับ erorr
                    {                       
                        if (point[number] != 'X' && point[number] != 'O') //ตรวจสอบว่าผู้เล่นไม่ได้เลือกตำแหน่งซ้ำ
                        {
                            if (player % 2 == 0) //ตรวจสอบว่าผู้เล่นคนใหน
                            {
                                point[number] = 'O'; //กำหนดให้ point ตำแหน่งที่ number เท่ากับ O
                                player++; //เพิ่มค่า player 1ค่า
                            }
                            else
                            {
                                point[number] = 'X'; //กำหนดให้ point ตำแหน่งที่ number เท่ากับ X
                                player++; //เพิ่มค่า player 1ค่า
                            }
                        }
                        else //ผู้เล่นเลือกตำแหน่งซ้ำ
                        {
                            Console.Clear(); //เคลียจอ
                            Console.WriteLine("\n\n          Sorry the row {0} is already marked with {1}\n", number, point[number]); //ข้อความที่แสดงบนจอ
                            Console.WriteLine("          Please wait 3 second board is loading again....."); //ข้อความที่แสดงบนจอ
                            Thread.Sleep(3000); //หยุดการทำงาน3วิ
                        }
                    }
                    catch //พบ erorr
                    {
                        Console.Clear(); //เคลียจอ
                        Console.WriteLine("\n\n          Sorry the XO Game can receive only one number please enter number\n"); //ข้อความที่แสดงบนจอ
                        Console.WriteLine("          Please wait 3 second board is loading again....."); //ข้อความที่แสดงบนจอ
                        Thread.Sleep(3000); //หยุดการทำงาน3วิ
                    }

                    flag = CheckWin(); //นำค่าที่ได้จากเมธอด CheckWin ไปเก็บไว้ใน flag
                   
                } while (flag != 1 && flag != -1); //ตรวจสอบว่ายังไม่พบผู้ชนะ

                Console.Clear(); //เคลียจอ
                if (flag == 1) //ตรวจสอบว่าใครชนะ
                {
                    Console.WriteLine("\n***********************************************\n");//ข้อความที่แสดงบนจอ
                    Console.WriteLine("               {0} you win", playername[player % 2/*ชื่อผู้ชนะ*/]); //ข้อความที่แสดงบนจอ
                }
                else //เสมอ
                {
                    Console.WriteLine("          Draw"); //ข้อความที่แสดงบนจอ
                }
                Board(); //รียกใช้เมธอดBoard
                Console.Write("          Replay enter number \n          or Exit enter 0 ");
                try //ตรวจจับ erorr
                {
                    claerboard(); //เรียกใช้เมธอด claerboard
                    exit = int.Parse(Console.ReadLine()); //หยุดรอรับค่า
                }
                catch //ถ้า erorr
                {
                }
                if (exit == 0) //ออกจากโปรแกรม
                {
                    break; //ออกจากลูบ
                }
            } while (true);
            
        }

        private static void Board()//เมธอดBoard
        {
            Console.WriteLine("\n***********************************************\n\n"); //ข้อความที่แสดงบนจอ
            Console.WriteLine("                    |     |      "); //ข้อความที่แสดงบนจอ
            Console.WriteLine("                 {0}  |  {1}  |  {2}", point[7], point[8], point[9]); //ข้อความที่แสดงบนจอ
            Console.WriteLine("               _____|_____|_____ "); //ข้อความที่แสดงบนจอ
            Console.WriteLine("                    |     |      "); //ข้อความที่แสดงบนจอ
            Console.WriteLine("                 {0}  |  {1}  |  {2}", point[4], point[5], point[6]); //ข้อความที่แสดงบนจอ
            Console.WriteLine("               _____|_____|_____ "); //ข้อความที่แสดงบนจอ
            Console.WriteLine("                    |     |      "); //ข้อความที่แสดงบนจอ
            Console.WriteLine("                 {0}  |  {1}  |  {2}", point[1], point[2], point[3]); //ข้อความที่แสดงบนจอ
            Console.WriteLine("                    |     |      "); //ข้อความที่แสดงบนจอ
            Console.WriteLine("\n\n***********************************************\n"); //ข้อความที่แสดงบนจอ
        }

        private static int working() //เมธอดเล่นสองคน
        {
            do //ลูบการระบุตำแหน่ง x o
            {
                Console.Clear();//เคลียจอ
                Console.WriteLine("\n***********************************************\n"); //ข้อความที่แสดงบนจอ
                Console.WriteLine("\n                     XO Game\n"); //ข้อความที่แสดงบนจอ
                Console.WriteLine("          {0} :: X\n                       VS\n          {1} :: O\n", playername[0], playername[1]); //ข้อความที่แสดงบนจอ

                Board(); //รียกใช้เมธอดBoard

                if (player % 2 == 0) //ตรวจสอบว่าผู้เล่นคนใหน
                {
                    Console.Write("          {0} please Enter number: ", playername[1] /*ผู้เล่นคนที่2*/); //ข้อความที่แสดงบนจอ
                }
                else
                {
                    Console.Write("          {0} please Enter number: ", playername[0] /*ผู้เล่นคนที่1*/); //ข้อความที่แสดงบนจอ
                }

                try //ตรวจจับ erorr
                {
                    number = int.Parse(Console.ReadLine()); //รับตำแหน่ง x o ในกระดาน
                    if (number == 0)
                    {
                        Console.Clear(); //เคลียจอ
                        Console.WriteLine("\n\n          Sorry the XO Game not input number 0 please enter number\n"); //ข้อความที่แสดงบนจอ
                        Console.WriteLine("          Please wait 3 second board is loading again....."); //ข้อความที่แสดงบนจอ
                        Thread.Sleep(3000); //หยุดการทำงาน3วิ
                    }
                }
                catch //พบ erorr
                {
                    Console.Clear(); //เคลียจอ
                    Console.WriteLine("\n\n          Sorry the XO Game not input text please enter number\n"); //ข้อความที่แสดงบนจอ
                    Console.WriteLine("          Please wait 3 second board is loading again....."); //ข้อความที่แสดงบนจอ
                    Thread.Sleep(3000); //หยุดการทำงาน3วิ
                }

            } while (number == 0); //ตรวจสอบว่า number เท่ากับ 0
            return number; //ส่งค่า number ออกไป
        }

        private static int workingcom() //เมธออดเล่นคนเดียว
        {
            do //ลูบการระบุตำแหน่ง x o
            {
                Console.Clear();//เคลียจอ
                Console.WriteLine("\n***********************************************\n"); //ข้อความที่แสดงบนจอ
                Console.WriteLine("\n                     XO Game\n"); //ข้อความที่แสดงบนจอ
                Console.WriteLine("          {0} :: X\n                       VS\n          {1} :: O\n", playername[0], playername[1]); //ข้อความที่แสดงบนจอ

                Board(); //รียกใช้เมธอดBoard

                if (player % 2 == 0) //ตรวจสอบว่าผู้เล่นคนใหน
                {
                    ai(); //รียกใช้เมธอด AI
                }
                else
                {
                    Console.Write("          {0} please Enter number: ", playername[0] /*ผู้เล่นคนที่1*/); //ข้อความที่แสดงบนจอ
                    try //ตรวจจับ erorr
                    {
                        number = int.Parse(Console.ReadLine()); //รับตำแหน่ง x o ในกระดาน
                        if (number == 0)
                        {
                            Console.Clear(); //เคลียจอ
                            Console.WriteLine("\n\n          Sorry the XO Game not input number 0 please enter number\n"); //ข้อความที่แสดงบนจอ
                            Console.WriteLine("          Please wait 3 second board is loading again....."); //ข้อความที่แสดงบนจอ
                            Thread.Sleep(3000); //หยุดการทำงาน3วิ
                        }
                    }
                    catch //พบ erorr
                    {
                        Console.Clear(); //เคลียจอ
                        Console.WriteLine("\n\n          Sorry the XO Game not input text please enter number\n"); //ข้อความที่แสดงบนจอ
                        Console.WriteLine("          Please wait 3 second board is loading again....."); //ข้อความที่แสดงบนจอ
                        Thread.Sleep(3000); //หยุดการทำงาน3วิ
                    }
                }
            } while (number == 0); //ตรวจสอบว่า number เท่ากับ 0
            return number; //ส่งค่า number ออกไป
        }

        private static void imputname2() //เมธอดรับชื่อคนเดียว
        {
            while (n < 2) //ลูบการใส่ชื่อผู้เล่น
            {
                Console.Clear(); //เคลียจอ
                Console.WriteLine("\n"); //เว้นบันทัด
                Console.WriteLine("***********************************************"); //ข้อความที่แสดงบนจอ
                Console.WriteLine("\n                     XO Game\n"); //ข้อความที่แสดงบนจอ
                Console.WriteLine("***********************************************\n"); //ข้อความที่แสดงบนจอ
                Console.Write("        Player {0} please enter name: ", n + 1); //ข้อความที่แสดงบนจอ
                playername[n] = Console.ReadLine(); //รับชื่อผู้เล่น

                if (playername[n] == "") //ตรวจสอบว่าผู้เล่นได้ใส่ชื่อหรือไม่
                {   //ผู้เล่นไม่ได้ใส่ชื่อ
                    Console.Clear(); //เคลียจอ
                    Console.WriteLine("\n\n          Sorry please enter name Player{0}\n", n + 1); //ข้อความที่แสดงบนจอ
                    Console.WriteLine("          Please wait 3 second enter name is loading again....."); //ข้อความที่แสดงบนจอ
                    n--; //ลดค่า n 1ค่า
                    Thread.Sleep(3000); //หยุดการทำงาน3วิ
                }
                n++; //เพิ่มค่า n 1ค่า
            }
        }

        private static void imputname1() //เมธอดรับชื่อสองคน
        {
            while (n < 1) //ลูบการใส่ชื่อผู้เล่น
            {
                Console.Clear(); //เคลียจอ
                Console.WriteLine("\n"); //เว้นบันทัด
                Console.WriteLine("***********************************************"); //ข้อความที่แสดงบนจอ
                Console.WriteLine("\n                     XO Game\n"); //ข้อความที่แสดงบนจอ
                Console.WriteLine("***********************************************\n"); //ข้อความที่แสดงบนจอ
                Console.Write("        Player {0} please enter name: ", n + 1); //ข้อความที่แสดงบนจอ
                playername[n] = Console.ReadLine(); //รับชื่อผู้เล่น

                if (playername[n] == "") //ตรวจสอบว่าผู้เล่นได้ใส่ชื่อหรือไม่
                {   //ผู้เล่นไม่ได้ใส่ชื่อ
                    Console.Clear(); //เคลียจอ
                    Console.WriteLine("\n\n          Sorry please enter name Player{0}\n", n + 1); //ข้อความที่แสดงบนจอ
                    Console.WriteLine("          Please wait 3 second enter name is loading again....."); //ข้อความที่แสดงบนจอ
                    n--; //ลดค่า n 1ค่า
                    Thread.Sleep(3000); //หยุดการทำงาน3วิ
                }
                n++; //เพิ่มค่า n 1ค่า
            }

            playername[1] = "COM"; //กำหนดชื่อ
        }

        private static int CheckWin() //เมธอดCheckWin
        {
            //เงื่อนไขการชนะในแนวนอน     
            if (point[1] == point[2] && point[2] == point[3])
            {
                return 1; //ส่งค่า 1 กลับไป
            }
            else if (point[4] == point[5] && point[5] == point[6])
            {
                return 1; //ส่งค่า 1 กลับไป
            }
            else if (point[7] == point[8] && point[8] == point[9])
            {
                return 1; //ส่งค่า 1 กลับไป
            }

            //เงื่อนไขการชนะในแนวตั้ง   
            else if (point[1] == point[4] && point[4] == point[7])
            {
                return 1; //ส่งค่า 1 กลับไป
            }
            else if (point[2] == point[5] && point[5] == point[8])
            {
                return 1; //ส่งค่า 1 กลับไป
            }
            else if (point[3] == point[6] && point[6] == point[9])
            {
                return 1; //ส่งค่า 1 กลับไป
            }

            //เงื่อนไขการชนะในมุมทแยง   
            else if (point[1] == point[5] && point[5] == point[9])
            {
                return 1; //ส่งค่า 1 กลับไป
            }
            else if (point[3] == point[5] && point[5] == point[7])
            {
                return 1; //ส่งค่า 1 กลับไป
            }

            //เงื่อนไขการเสมอ
            else if (point[1] != '1' && point[2] != '2' && point[3] != '3' && point[4] != '4' && point[5] != '5' && point[6] != '6' && point[7] != '7' && point[8] != '8' && point[9] != '9')
            {
                return -1; //ส่งค่า -1 กลับไป
            }

            //ยังไม่มีผู้ชนะ
            else
            {
                return 0; //ส่งค่า 0 กลับไป
            }
        }

        private static int ai() //เมธอด AI
        {
            Random rnd = new Random();
            do
            {   //ชนะแนวนอน
                if (point[1] == 'O' && point[2] == 'O' && point[3] != 'X')
                {
                    number = 3;
                }
                else if (point[3] == 'O' && point[1] == 'O' && point[2] != 'X')
                {
                    number = 2;
                }
                else if (point[3] == 'O' && point[2] == 'O' && point[1] != 'X')
                {
                    number = 1;
                }
                else if (point[4] == 'O' && point[5] == 'O' && point[6] != 'X')
                {
                    number = 6;
                }
                else if (point[4] == 'O' && point[6] == 'O' && point[5] != 'X')
                {
                    number = 5;
                }
                else if (point[6] == 'O' && point[5] == 'O' && point[4] != 'X')
                {
                    number = 4;
                }
                else if (point[7] == 'O' && point[8] == 'O' && point[9] != 'X')
                {
                    number = 9;
                }
                else if (point[7] == 'O' && point[9] == 'O' && point[8] != 'X')
                {
                    number = 8;
                }
                else if (point[8] == 'O' && point[9] == 'O' && point[7] != 'X')
                {
                    number = 7;
                }

                //ชนะแนวตั้ง
                else if (point[1] == 'O' && point[4] == 'O' && point[7] != 'X')
                {
                    number = 7;
                }
                else if (point[1] == 'O' && point[7] == 'O' && point[4] != 'X')
                {
                    number = 4;
                }
                else if (point[7] == 'O' && point[4] == 'O' && point[1] != 'X')
                {
                    number = 1;
                }
                else if (point[2] == 'O' && point[5] == 'O' && point[8] != 'X')
                {
                    number = 8;
                }
                else if (point[8] == 'O' && point[5] == 'O' && point[2] != 'X')
                {
                    number = 2;
                }
                else if (point[8] == 'O' && point[2] == 'O' && point[5] != 'X')
                {
                    number = 5;
                }
                else if (point[3] == 'O' && point[6] == 'O' && point[9] != 'X')
                {
                    number = 9;
                }
                else if (point[3] == 'O' && point[9] == 'O' && point[6] != 'X')
                {
                    number = 6;
                }
                else if (point[9] == 'O' && point[6] == 'O' && point[3] != 'X')
                {
                    number = 3;
                }

                //ชนะมุมทะแยง
                else if (point[1] == 'O' && point[5] == 'O' && point[9] != 'X')
                {
                    number = 9;
                }
                else if (point[9] == 'O' && point[5] == 'O' && point[1] != 'X')
                {
                    number = 1;
                }
                else if (point[1] == 'O' && point[9] == 'O' && point[5] != 'X')
                {
                    number = 5;
                }
                else if (point[3] == 'O' && point[5] == 'O' && point[7] != 'X')
                {
                    number = 7;
                }
                else if (point[3] == 'O' && point[7] == 'O' && point[5] != 'X')
                {
                    number = 5;
                }
                else if (point[7] == 'O' && point[5] == 'O' && point[3] != 'X')
                {
                    number = 3;
                }

                //การดักทางเมื่อกดปุ่ม
                else if (number == 1)
                {
                    if (point[5] != 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[3] == 'X' && point[2] != 'O')
                    {
                        number = 2;
                    }
                    else if (point[9] == 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[7] == 'X' && point[4] != 'O')
                    {
                        number = 4;
                    }
                    else if (point[2] == 'X' && point[3] != 'O')
                    {
                        number = 3;
                    }
                    else if (point[5] == 'X' && point[9] != 'O')
                    {
                        number = 9;
                    }
                    else if (point[4] == 'X' && point[5] != '7')
                    {
                        number = 7;
                    }
                    else
                    {
                        do
                        {
                            number = rnd.Next(1, 9);
                        } while (number != 4 && number != 2);
                    }
                }


                else if (number == 2)
                {
                    if (point[5] != 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[8] == 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[8] == 'X' && point[5] == 'O' && point[4] == 'X' && point[6] != 'O')
                    {
                        number = 6;
                    }
                    else if (point[8] == 'X' && point[5] == 'O' && point[6] == 'X' && point[4] != 'O')
                    {
                        number = 4;
                    }
                    else if (point[5] == 'X' && point[8] != 'O')
                    {
                        number = 8;
                    }
                    else if (point[1] == 'X' && point[3] != 'O')
                    {
                        number = 3;
                    }
                    else if (point[3] == 'X' && point[1] != 'O')
                    {
                        number = 1;
                    }
                    else
                    {
                        do
                        {
                            number = rnd.Next(1, 9);
                        } while (number != 1 && number != 3);
                    }
                }


                else if (number == 3)
                {
                    if (point[5] != 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[9] == 'X' && point[6] != 'O')
                    {
                        number = 6;
                    }
                    else if (point[1] == 'X' && point[2] != 'O')
                    {
                        number = 2;
                    }
                    else if (point[7] == 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[6] == 'X' && point[9] != 'O')
                    {
                        number = 9;
                    }
                    else if (point[5] == 'X' && point[7] != 'O')
                    {
                        number = 7;
                    }
                    else if (point[2] == 'X' && point[1] != 'O')
                    {
                        number = 1;
                    }
                    else
                    {
                        do
                        {
                            number = rnd.Next(1, 9);
                        } while (number != 2 && number != 6);
                    }
                }


                else if (number == 4)
                {
                    if (point[5] != 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[6] == 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[6] == 'X' && point[5] == 'O' && point[8] == 'X')
                    {
                        number = 2;
                    }
                    else if (point[6] == 'X' && point[5] == 'O' && point[2] == 'X')
                    {
                        number = 8;
                    }
                    else if (point[5] == 'X' && point[6] != 'O')
                    {
                        number = 6;
                    }
                    else if (point[1] == 'X' && point[7] != 'O')
                    {
                        number = 7;
                    }
                    else if (point[7] == 'X' && point[1] != 'O')
                    {
                        number = 1;
                    }
                    else
                    {
                        do
                        {
                            number = rnd.Next(1, 9);
                        } while (number != 1 && number != 7);
                    }
                }


                else if (number == 5)
                {
                    if (point[1] == 'X' && point[5] != 'O')
                    {
                        number = 9;
                    }
                    else if (point[2] == 'X' && point[8] != 'O')
                    {
                        number = 8;
                    }
                    else if (point[3] == 'X' && point[7] != 'O')
                    {
                        number = 7;
                    }
                    else if (point[4] == 'X' && point[6] != 'O')
                    {
                        number = 6;
                    }
                    else if (point[6] == 'X' && point[4] != 'O')
                    {
                        number = 4;
                    }
                    else if (point[7] == 'X' && point[3] != 'O')
                    {
                        number = 3;
                    }
                    else if (point[8] == 'X' && point[2] != 'O')
                    {
                        number = 2;
                    }
                    else if (point[9] == 'X' && point[1] != 'O')
                    {
                        number = 1;
                    }
                    else
                    {
                        do
                        {
                            number = rnd.Next(1, 9);
                        } while (number != 1 && number != 2 && number != 3 && number != 4 && number != 6 && number != 7 && number != 8 && number != 9);
                    }
                }


                else if (number == 6)
                {
                    if (point[5] != 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[5] == 'X' && point[4] != 'O')
                    {
                        number = 4;
                    }
                    else if (point[4] == 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[4] == 'X' && point[5] == 'O' && point[1] == 'X')
                    {
                        number = 8;
                    }
                    else if (point[4] == 'X' && point[5] == 'O' && point[7] == 'X')
                    {
                        number = 2;
                    }
                    else if (point[9] == 'X' && point[3] != 'O')
                    {
                        number = 3;
                    }
                    else if (point[3] == 'X' && point[9] != 'O')
                    {
                        number = 9;
                    }
                    else
                    {
                        do
                        {
                            number = rnd.Next(1, 9);
                        } while (number != 3 && number != 9);
                    }
                }


                else if (number == 7)
                {
                    if (point[5] != 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[9] == 'X' && point[8] != 'O')
                    {
                        number = 8;
                    }
                    else if (point[3] == 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[1] == 'X' && point[4] != 'O')
                    {
                        number = 4;
                    }
                    else if (point[4] == 'X' && point[1] != 'O')
                    {
                        number = 1;
                    }
                    else if (point[5] == 'X' && point[3] != 'O')
                    {
                        number = 3;
                    }
                    else if (point[8] == 'X' && point[9] != 'O')
                    {
                        number = 9;
                    }
                    else
                    {
                        do
                        {
                            number = rnd.Next(1, 9);
                        } while (number != 4 && number != 8);
                    }
                }


                else if (number == 8)
                {
                    if (point[5] != 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[2] == 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[2] == 'X' && point[5] == 'O' && point[4] == 'X')
                    {
                        number = 6;
                    }
                    else if (point[2] == 'X' && point[5] == 'O' && point[6] == 'X')
                    {
                        number = 4;
                    }
                    else if (point[5] == 'X' && point[2] != 'O')
                    {
                        number = 2;
                    }
                    else if (point[7] == 'X' && point[9] != 'O')
                    {
                        number = 9;
                    }
                    else if (point[7] == 'O')
                    {
                        number = 9;
                    }
                    else if (point[9] == 'X' && point[7] != 'O')
                    {
                        number = 7;
                    }
                    else
                    {
                        do
                        {
                            number = rnd.Next(1, 9);
                        } while (number != 7 && number != 9);
                    }
                }


                else if (number == 9)
                {
                    if (point[5] != 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[3] == 'X' && point[6] != 'O')
                    {
                        number = 6;
                    }
                    else if (point[1] == 'X' && point[5] != 'O')
                    {
                        number = 5;
                    }
                    else if (point[7] == 'X' && point[8] != 'O')
                    {
                        number = 8;
                    }
                    else if (point[8] == 'X' && point[7] != 'O')
                    {
                        number = 7;
                    }
                    else if (point[5] == 'X' && point[1] != 'O')
                    {
                        number = 1;
                    }
                    else if (point[6] == 'X' && point[3] != 'O')
                    {
                        number = 3;
                    }
                    else
                    {
                        do
                        {
                            number = rnd.Next(1, 9);
                        } while (number != 6 && number != 8);
                    }
                }

            } while (point[number] == 'O' || point[number] == 'X');
            return number;

        }

        private static void claerboard() //เมธอดล้างค่า
        {
            //กำหนดค่าแอคทิบิลใหม่
            point[0] = '0';
            point[1] = '1';
            point[2] = '2';
            point[3] = '3';
            point[4] = '4';
            point[5] = '5';
            point[6] = '6';
            point[7] = '7';
            point[8] = '8';
            point[9] = '9';
            player = 1;
            number = 0;
            n = 0;
            selectplayer = 0;
            exit = 1;
            playername[0] = "1";
            playername[1] = "2";
            flag = 0;

        }
    }
}
