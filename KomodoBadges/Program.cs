using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (!keepRunning)
            {
                Console.WriteLine("Select\n" +
                    "1. Add a badge \n" +
                    "2. Edit a badge \n" +
                    "3. List all badges \n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                        case "2":
                        EditBadge();
                        break ;
                        case "3":
                        ListAllBadges();
                        break ;
                    case "4":
                        Exit();
                        break ;
                    default: Console.WriteLine("Input not valid");

                        break;
                        Console.ReadLine();
                }
            }
        }

        private void Exit()
        {
            throw new NotImplementedException();
        }

        private void ListAllBadges()
        {
            throw new NotImplementedException();
        }

        private void EditBadge()
        {
            throw new NotImplementedException();
        }

        private void AddBadge()
        {
            throw new NotImplementedException();
        }

    }
}
