using BadgesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class MenuItem_RepoTests
    {
        [TestClass]
        public class Badge_RepoTests
        {
            [TestMethod]
            public void AddToRepo_ShouldGetCorrectBool()//Create
            {
                //Arrange
                Badge badge = new Badge(01);
                Badge_Repo repo = new Badge_Repo();

                //Act
                bool addResult = repo.AddBadge(badge);

                //Assert
                Assert.IsTrue(addResult);
            }

            [TestMethod]
            public void GetBadges_ShouldReturnCorrectCollection() //Read
            {

                //Arrange
                Badge badge = new Badge(1738);
                Badge_Repo repo = new Badge_Repo();
                repo.AddBadge(badge);

                //Act
                Dictionary<int, List<string>> badges = repo.GetAllBadges();
                //Might need converting come back to later
                bool hasBadges = badges.ContainsKey(badge.BadgeID);

                //Assert
                Assert.IsTrue(hasBadges);

            }

            [TestMethod]
            public void GetBadgeByID_ShouldReturnCorrectBadge() //Read
            {
                //Arrange
                Badge badge = new Badge(1738, new List<string> { "B3" });
                Badge_Repo repo = new Badge_Repo();
                repo.AddBadge(badge);
                int badgeID = 1738;
                //Act
                Badge searchResult = repo.GetABadgeByID(badgeID);

                //Assert
                Assert.AreEqual(searchResult.BadgeID, badgeID);
            }

            [TestMethod]
            public void UpdateExistingBadge_ShouldReturnTrue() //Update
            {
                //Arrange
                Badge oldBadge = new Badge(1738, new List<string> { "B3" });
                Badge newBadge = new Badge(1738, new List<string> { "B3" });
                Badge_Repo repo = new Badge_Repo();
                repo.AddBadge(oldBadge);

                //Act
                bool updateResult = repo.UpdateExistingBadge(oldBadge.BadgeID, newBadge);

                //Assert
                Assert.IsTrue(updateResult);
            }

            [TestMethod]
            public void DeleteBadge_ShouldReturnTrue() //Delete
            {
                //Arrange
                Badge badge = new Badge(1738, new List<string> { "B3", "B3" });
                Badge_Repo repo = new Badge_Repo();
                repo.AddBadge(badge);
                int badgeID = 1738;
                //Act
                Badge oldBadge = repo.GetABadgeByID(badgeID);
                bool removeResult = repo.DeleteBadge(oldBadge);

                //Assert
                Assert.IsTrue(removeResult);

            }
        }
    }
}