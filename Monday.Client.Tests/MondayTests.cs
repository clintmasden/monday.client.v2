using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monday.Client.Models;
using Monday.Client.Mutations;
using Monday.Client.Responses;

namespace Monday.Client.Tests
{
    [TestClass]
    public class MondayTests
    {
        private static MondayClient _mondayClient;

        [ClassInitialize]
        public static void SetupClient(TestContext con)
        {
            var key = File.ReadAllText(@"../../../../.key");
            _mondayClient = new MondayClient(key);
        }

        [TestMethod]
        public void GetUsers_Pass()
        {
            var result = _mondayClient.GetUsers().Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetUsers_UserAccessTypes_Pass()
        {
            var result = _mondayClient.GetUsers(UserAccessTypes.All).Result;
            Assert.IsNotNull(result);

            result = _mondayClient.GetUsers(UserAccessTypes.Guests).Result;
            Assert.IsNotNull(result);

            result = _mondayClient.GetUsers(UserAccessTypes.NonGuests).Result;
            Assert.IsNotNull(result);

            result = _mondayClient.GetUsers(UserAccessTypes.NonPending).Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetUser_Pass()
        {
            var result = _mondayClient.GetUser("67443917").Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBoards_Pass()
        {
            var result = _mondayClient.GetBoards().Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBoard_Pass()
        {
            var result = _mondayClient.GetBoard("7649483939").Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetGroups_Pass()
        {
            var result = _mondayClient.GetGroups("7649483939").Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetItems_Pass()
        {
            var result = _mondayClient.GetItems("7649483939").Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetItem_Pass()
        {
            var result = _mondayClient.GetItem("7649484088").Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTags_Pass()
        {
            var result = _mondayClient.GetTags("7650159316").Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTag_Pass()
        {
            var result = _mondayClient.GetTag("24324128").Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTeams_Pass()
        {
            var result = _mondayClient.GetTeams().Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTeam_Pass()
        {
            var result = _mondayClient.GetTeam("73722").Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetRateLimit_Pass()
        {
            var result = _mondayClient.GetRateLimit().Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetComplexity_Pass()
        {
            var result = _mondayClient.GetComplexity("users(kind: non_guests) { id name }").Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateBoard_Pass()
        {
            var result = _mondayClient.CreateBoard(new CreateBoard
            {
                Name = "Unit Test Name",
                BoardAccessType = BoardAccessTypes.Public
            }).Result;

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void ArchiveBoard_Pass()
        {
            var result = _mondayClient.ArchiveBoard("7650223627").Result;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateColumn_Pass()
        {
            var result = _mondayClient.CreateColumn(new CreateColumn
            {
                BoardId = "7650159316",
                Name = "Unit Test Name",
                ColumnType = ColumnTypes.Status
            }).Result;

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void UpdateColumn_Pass()
        {
            var result = _mondayClient.UpdateColumn(new UpdateColumn
            {
                BoardId = "7650159316",
                ItemId = "7650159466",
                ColumnId = "status",
                Value = "{\"index\": 1}"
            }).Result;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateGroup_Pass()
        {
            var result = _mondayClient.CreateGroup(new CreateGroup
            {
                BoardId = "7650159316",
                Name = "Unit Test Name"
            }).Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ArchiveGroup_Pass()
        {
            var result = _mondayClient.ArchiveGroup("7650159316", "unit_test_name__1").Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteGroup_Pass()
        {
            var result = _mondayClient.DeleteGroup("7650159316", "unit_test_name23081__1").Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateItem_Pass()
        {
            var result = _mondayClient.CreateItem(new CreateItem
            {
                BoardId = "7650159316",
                GroupId = "topics",
                Name = "Unit Test Name"
            }).Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ClearItemUpdates_Pass()
        {
            var result = _mondayClient.ClearItemUpdates("7650159466").Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UpdateItemGroup_Pass()
        {
            var result = _mondayClient.UpdateItemGroup("7650159466", "group_title").Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ArchiveItem_Pass()
        {
            var result = _mondayClient.ArchiveItem("7650159466").Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteItem_Pass()
        {
            var result = _mondayClient.DeleteItem("7650159466").Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateUpdate_Pass()
        {
            var result = _mondayClient.CreateUpdate(new CreateUpdate
            {
                ItemId = "7650159466",
                Body = "Unit Test Body"
            }).Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateTag_Pass()
        {
            var result = _mondayClient.CreateTag(new CreateTag
            {
                BoardId = "7650159316",
                Name = "Unit Test Tag"
            }).Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CustomQueryOrMutation_Pass()
        {
            var result = _mondayClient.CustomQueryOrMutation<GetItemsResponse>("{ items(ids: [7650159466]) { column_values { id text type value }}}").Result;

            Assert.IsNotNull(result);
        }
    }
}