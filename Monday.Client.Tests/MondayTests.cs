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
            var result = _mondayClient.GetUser(5412166).Result;
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
            var result = _mondayClient.GetBoard(494930491).Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetGroups_Pass()
        {
            var result = _mondayClient.GetGroups(494930491).Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetItems_Pass()
        {
            var result = _mondayClient.GetItems(494930491).Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetItem_Pass()
        {
            var result = _mondayClient.GetItem(234543614).Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTags_Pass()
        {
            var result = _mondayClient.GetTags(406315816).Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTag_Pass()
        {
            var result = _mondayClient.GetTag(784541).Result;
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
            var result = _mondayClient.GetTeam(73722).Result;
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

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void ArchiveBoard_Pass()
        {
            var result = _mondayClient.ArchiveBoard(494930491).Result;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateColumn_Pass()
        {
            var result = _mondayClient.CreateColumn(new CreateColumn
            {
                BoardId = 494930491,
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
                BoardId = 494930491,
                ItemId = 494930500,
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
                BoardId = 494930491,
                Name = "Unit Test Name"
            }).Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ArchiveGroup_Pass()
        {
            var result = _mondayClient.ArchiveGroup(494930491, "group_title").Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteGroup_Pass()
        {
            var result = _mondayClient.DeleteGroup(494930491, "group_title").Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateItem_Pass()
        {
            var result = _mondayClient.CreateItem(new CreateItem
            {
                BoardId = 494930491,
                GroupId = "unit_test_name",
                Name = "Unit Test Name"
            }).Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ClearItemUpdates_Pass()
        {
            var result = _mondayClient.ClearItemUpdates(494930492).Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UpdateItemGroup_Pass()
        {
            var result = _mondayClient.UpdateItemGroup(494930492, "unit_test_name").Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ArchiveItem_Pass()
        {
            var result = _mondayClient.ArchiveItem(494930492).Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteItem_Pass()
        {
            var result = _mondayClient.DeleteItem(494930492).Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateUpdate_Pass()
        {
            var result = _mondayClient.CreateUpdate(new CreateUpdate
            {
                ItemId = 494930492,
                Body = "Unit Test Body"
            }).Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateTag_Pass()
        {
            var result = _mondayClient.CreateTag(new CreateTag
            {
                BoardId = 494930491,
                Name = "Unit Test Tag"
            }).Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CustomQueryOrMutation_Pass()
        {
            var result = _mondayClient.CustomQueryOrMutation<GetItemsResponse>("{ items(ids: [494930492]) { column_values { id text title type value additional_info }}}").Result;

            Assert.IsNotNull(result);
        }
    }
}