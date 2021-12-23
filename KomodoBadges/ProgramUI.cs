using BadgesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    public class ProgramUI
    {
        //Repo Field
        private Badge_Repo _repo = new Badge_Repo();

        public void Run()
        {
            SeedBadges();
            Menu();
        }


        public void SeedBadges()
        {
            Badge badge1 = new Badge(1738, new List<string> { "B3" });
            Badge badge2 = new Badge(6969, new List<string> { "C1", "D1", "X3", "B1" });
            Badge badge3 = new Badge(420, new List<string> { "D4", "F4" });
            _repo.AddBadge(badge1);
            _repo.AddBadge(badge2);
            _repo.AddBadge(badge3);
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
              
               
                Console.WriteLine("1 Add a New Badge");
                Console.WriteLine("2> Edit a Badge");
                Console.WriteLine("3> Delete all Doors from a Badge");
                Console.WriteLine("4> View all Badges");
                Console.WriteLine("5> Exit Badge Program");
                Console.WriteLine("Please enter a number to continue");
                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        DeleteAllDoorsOnBadge();
                        break;
                    case "4":
                        ViewAll();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default: Console.WriteLine("Input not valid");
                        break;
                }
            }
        }

        public void AddBadge()
        {

            Console.Clear();
            
           
            Console.WriteLine("Enter the number of the badge");
            int badgeNum = Convert.ToInt32(Console.ReadLine());
            if (_repo.GetABadgeByID(badgeNum) != null)
            {
                Console.WriteLine("Badge already exists");
                Console.WriteLine("Press any key to go back");
            }
            else
            {

                Badge newBadge = new Badge(badgeNum);
                bool looper = true;
                List<string> doors = new List<string>();
                while (looper)
                {
                    Console.WriteLine("Enter a door that Badge number" + badgeNum + " needs access to ");
                    doors.Add(Console.ReadLine());
                    Console.WriteLine("Would you like to add access to aditional doors (y/n)?");
                    string moreDoors = Console.ReadLine();
                    if (moreDoors.ToLower() == "n")
                    {
                        looper = false;
                    }
                }
                newBadge.Doors = doors;
                string doorResult = string.Join(",", doors);
                bool wasAdded = _repo.AddBadge(newBadge);
                if (wasAdded == true)
                {
                    Console.WriteLine($"Badge {newBadge.BadgeID} was added Successfully and has access to {doorResult}.");

                }
                else
                {
                    Console.WriteLine($"Failed try again");
                }
                Console.WriteLine("Press any key to go back");
            }
            Console.ReadKey();
        }

        public void EditBadge()
        {
            Console.Clear();
       
           
            Console.WriteLine("Enter number of badge to update");
            int badgeNum = Convert.ToInt32(Console.ReadLine());
            Badge badgeToUpdate = _repo.GetABadgeByID(badgeNum);
            List<string> doorsOnBadge = new List<string>();
            if (badgeToUpdate != null)
            {
                doorsOnBadge = badgeToUpdate.Doors;
                bool looper = true;
                while (looper)
                {

                    Console.Clear();
                    
                    
                    string doorsResult = string.Join(",", badgeToUpdate.Doors);
                    Console.WriteLine($"Badge {badgeToUpdate.BadgeID} has access to {doorsResult}.");
                    Console.WriteLine("Select command");
                    Console.WriteLine("     1> Delete a door");
                    Console.WriteLine("     2> Add new door");
                    Console.WriteLine("     3> Save changes");
                    string menuSelect = Console.ReadLine();
                    switch (menuSelect)
                    {
                        case "1":
                            Console.WriteLine("Which door would you like to delete?");
                            string doorToRemove = Console.ReadLine();
                            doorsOnBadge.Remove(doorToRemove);
                            badgeToUpdate.Doors = doorsOnBadge;
                            Console.WriteLine("Door successfully deleted");
                            doorsResult = string.Join(",", badgeToUpdate.Doors);
                            Console.WriteLine($"Badge {badgeToUpdate.BadgeID} has access to doors: {doorsResult}.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine("Which door would you like to add?");
                            string doorToAdd = Console.ReadLine();
                            doorsOnBadge.Add(doorToAdd);
                            badgeToUpdate.Doors = doorsOnBadge;
                            Console.WriteLine("Door Added succesfuly");
                            doorsResult = string.Join(",", badgeToUpdate.Doors);
                            Console.WriteLine($"Badge {badgeToUpdate.BadgeID} has access to doors: {doorsResult}.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case "3":
                            looper = false;
                            break;
                    }

                }
                bool wasUpdate = _repo.UpdateExistingBadge(badgeNum, badgeToUpdate);
                if (wasUpdate == true)
                {
                    Console.WriteLine("Badge updated successfully");
                }
                else
                {
                    Console.WriteLine("Failed try again later");
                }

            }
            else
            {
                Console.WriteLine("Couldn't find badge");

            }
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();

        }

        public void DeleteAllDoorsOnBadge()
        {
            Console.Clear();
           
            
            Console.WriteLine("What is the badge number to update");
            int badgeNum = Convert.ToInt32(Console.ReadLine());
            Badge badgeToUpdate = _repo.GetABadgeByID(badgeNum);
            List<string> doorsOnBadge = new List<string>();
            if (badgeToUpdate != null)
            {
                string doorsResult = string.Join(",", badgeToUpdate.Doors);
                Console.WriteLine($"Badge {badgeToUpdate.BadgeID} has access to doors: {doorsResult}.");
                Console.WriteLine($"Do you want to remove all existing  doors from Badge? {badgeToUpdate.BadgeID}? (y/n)");
                string deleteAll = Console.ReadLine();
                if (deleteAll.ToLower() == "y")
                {
                    badgeToUpdate.Doors.Clear();
                    bool wasUpdate = _repo.UpdateExistingBadge(badgeNum, badgeToUpdate);
                    if (wasUpdate == true)
                    {
                        Console.WriteLine($"All Doors succesfully deleted from Badge {badgeNum}");
                    }
                    else
                    {
                        Console.WriteLine("Failed try again later");
                    }

                }
                else
                {
                    Console.WriteLine("Canceled");
                }
            }
            else
            {
                Console.WriteLine("Badge ID not found");

            }
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
        }

        public void ViewAll()
        {
            Console.Clear();
           
           
            Console.WriteLine();
            Console.WriteLine("Badge#           Door Access:");
            Dictionary<int, List<string>> badges = _repo.GetAllBadges();
            foreach (KeyValuePair<int, List<string>> badge in badges)
            {
                string doorsResult = string.Join(",", badge.Value);
                Console.WriteLine($"{badge.Key}            {doorsResult}");

            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

       

        
    }
}


