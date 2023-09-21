using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp
{
    internal class Program
    {
        public static List<string> DataList = new List<string>();
        static void Main(string[] args)
        {
            double amount = 5000, deposit;
            double withdraw;
            int choice;

            while (true)
            {
                Console.WriteLine("WELCOME TO BELGIUM CAMPUS ATM\n");
                Console.WriteLine("1. Create Account\n");
                Console.WriteLine("2. Current Balance\n");
                Console.WriteLine("3. Withdraw \n");
                Console.WriteLine("4. Deposit \n");
                Console.WriteLine("5. Exit \n");
                Console.WriteLine("***************\n\n");
                Console.WriteLine("ENTER YOUR CHOICE : ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        string accNum, aaPIN, line;
                        double balance;
                        Console.Write("ENTER NEW ACCOUNT NUMBER: ");
                        accNum = Console.ReadLine();
                        Console.Write("ENTER PIN: ");
                        aaPIN = Console.ReadLine();
                        Console.Write("ENTER THE STARTING BALANCE: ");
                        balance = double.Parse(Console.ReadLine());
                        line = accNum + "," + aaPIN + "," + Convert.ToString(balance);
                        DataList.Add(line);
                        break;

                    case 2:
                        int index = accNumSearch(DataList);
                        if(index == -1)
                        {
                            Console.WriteLine("ACCOUNT DOES NOT EXIST");
                        }
                        else
                        {
                            bool passCorrect = PINSearch(DataList, index);
                            if(passCorrect == true)
                            {
                                string[] data = DataList[index].Split(',');
                                Console.WriteLine("\n YOUR CURRENT BALANCE IS RAND : {0} ", data[2]);
                            }
                            else
                            {
                                Console.WriteLine("INCORRECT PIN");
                            }
                        }
                        
                        break;

                    case 3:
                        index = accNumSearch(DataList);
                        if (index == -1)
                        {
                            Console.WriteLine("ACCOUNT DOES NOT EXIST");
                        }
                        else
                        {
                            bool passCorrect = PINSearch(DataList, index);
                            if (passCorrect == true)
                            {
                                string[] data = DataList[index].Split(',');
                                Console.WriteLine("\n ENTER THE WITHDRAW AMOUNT, MINIMUM R100: ");
                                withdraw = double.Parse(Console.ReadLine());

                                if (withdraw < 100 )
                                {
                                    Console.WriteLine("\n PLEASE ENTER A AMOUNT ABOVE R100");
                                }
                                else if (withdraw > (amount - 1000))
                                {
                                    Console.WriteLine("\n SORRY! INSUFFICENT BALANCE. MINIMUM BALANCE IS R1000");
                                }
                                else
                                {
                                    double bal = double.Parse(data[2]);
                                    bal = bal - withdraw;
                                    data[2] = Convert.ToString(bal);
                                    string newLine = data[0]+","+data[1]+","+data[2];
                                    DataList[index] = newLine;
                                    Console.WriteLine("\n\n PLEASE COLLECT YOUR CASH");
                                    Console.WriteLine("\n CURRENT BALANCE IS RAND : {0}", bal);
                                }
                            }
                            else
                            {
                                Console.WriteLine("INCORRECT PIN");
                            }
                        }
                       
                        break;

                    case 4:
                        index = accNumSearch(DataList);
                        if (index == -1)
                        {
                            Console.WriteLine("ACCOUNT DOES NOT EXIST");
                        }
                        else
                        {
                            bool passCorrect = PINSearch(DataList, index);
                            if (passCorrect == true)
                            {
                                string[] data = DataList[index].Split(',');
                                Console.WriteLine("\n ENTER THE DEPOSIT AMOUNT");
                                deposit = double.Parse(Console.ReadLine());
                                amount = double.Parse(data[2]);
                                amount = amount + deposit;
                                data[2] = Convert.ToString(amount);
                                string newLine = data[0] + "," + data[1] + "," + data[2];
                                DataList[index] = newLine;
                                Console.WriteLine("YOUR AMOUNT HAS SUCCESSFULLY BEEN DEPOSITED");
                                Console.WriteLine("YOUR TOTAL BALANCE IS RAND : {0}", amount);

                            }
                            else
                            {
                                Console.WriteLine("INCORRECT PIN");
                            }
                        }
                        
                        break;

                    case 5:
                        Console.WriteLine("THANK YOU FOR USING BELGIUM CAMPUS ATM. PRESS ANY KEY TO CLOSE");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }

            Console.WriteLine("\n\n THANKS FOR USING BELGIUM CAMPUS ATM SERVICE");

        }
        public static int accNumSearch(List<string> PassList)
        {
            string search;
            Console.Write("ENTER THE ACCOUNT NUMBER: ");
            search = Console.ReadLine();
            for (int i = 0; i < PassList.Count; i++)
            {
                string[] data = PassList[i].Split(',');
                if (search == data[0])
                {
                    Console.Write("\n");
                    return i;
                    break;
                }
            }
            return -1;

        }
        public static bool PINSearch(List<string> PassList, int listIndex)
        {
            string[] data = PassList[listIndex].Split(',');
            string search;
            Console.Write("ENTER YOUR PIN: ");
            search = Console.ReadLine();
            if (data[1] == search)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
 
