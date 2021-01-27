using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using Monday.Client.Extensions;
using Monday.Client.Models;
using Monday.Client.Mutations;
using Monday.Client.Responses;

namespace Monday.Client
{
    /// <summary>
    ///     Creates client for accessing Monday's endpoints.
    /// </summary>
    public class MondayClient
    {
        /// <summary>
        ///     Creates client for accessing Monday's endpoints.
        /// </summary>
        /// <param name="apiKey">The version 2 key.</param>
        public MondayClient(string apiKey)
        {
            _graphQlHttpClient = new GraphQLHttpClient("https://api.monday.com/v2/");
            _graphQlHttpClient.HttpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(apiKey);
        }

        private GraphQLHttpClient _graphQlHttpClient { get; }

        /// <summary>
        ///     Helper method for throwing all errors reported from the response.
        /// </summary>
        /// <param name="graphQlErrors"></param>
        private void ThrowResponseErrors(GraphQLError[] graphQlErrors)
        {
            if (graphQlErrors == null)
            {
                return;
            }

            foreach (var error in graphQlErrors)
            {
                throw new Exception(error.Message);
            }
        }

        /// <summary>
        ///     Get all users.
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetUsers()
        {
            var request = new GraphQLRequest
            {
                Query = @"query { users { id name email url photo_original title birthday country_code location time_zone_identifier phone mobile_phone is_guest is_pending enabled created_at }}"
            };

            var result = await _graphQlHttpClient.SendQueryAsync<GetUsersResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Users;
        }

        /// <summary>
        ///     Get all users filtered by user access type [user kind].
        /// </summary>
        /// <param name="userAccessType">The user access type.</param>
        /// <returns></returns>
        public async Task<List<User>> GetUsers(UserAccessTypes userAccessType)
        {
            var request = new GraphQLRequest
            {
                Query = @"query request($userKind:UserKind) { users(kind:$userKind) { id name email url photo_original title birthday country_code location time_zone_identifier phone mobile_phone is_guest is_pending enabled created_at }}",
                Variables = new
                {
                    userKind = userAccessType.GetVariableUserAccessType()
                }
            };

            var result = await _graphQlHttpClient.SendQueryAsync<GetUsersResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Users;
        }

        /// <summary>
        ///     Return a specific user.
        /// </summary>
        /// <param name="userId">The user’s unique identifier.</param>
        /// <returns></returns>
        public async Task<User> GetUser(int userId)
        {
            var request = new GraphQLRequest
            {
                Query = @"query request($id:Int) { users(ids:[$id]) { id name email url photo_original title birthday country_code location time_zone_identifier phone mobile_phone is_guest is_pending enabled created_at }}",
                Variables = new
                {
                    id = userId
                }
            };

            var result = await _graphQlHttpClient.SendQueryAsync<GetUsersResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Users.FirstOrDefault();
        }

        /// <summary>
        ///     Get all (up to 100,000) boards [excluding columns] with a simplified user.
        /// </summary>
        /// <remarks>
        ///     Groups, items, subscribers, tags and updates can be loaded with their functions to further reduce complexity
        /// </remarks>
        /// <returns></returns>
        public async Task<List<Board>> GetBoards()
        {
            var request = new GraphQLRequest
            {
                Query = @"query { boards(limit: 100000) { id name description board_kind state board_folder_id permissions owner { id name email }}}"
            };

            var result = await _graphQlHttpClient.SendQueryAsync<GetBoardsResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Boards;
        }

        /// <summary>
        ///     Return a specific board with it's columns.
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <returns></returns>
        public async Task<Board> GetBoard(int boardId)
        {
            var request = new GraphQLRequest
            {
                Query = @"query request($id:Int) { boards(ids:[$id]) { id name description board_kind state board_folder_id permissions owner { id name email url photo_original title birthday country_code location time_zone_identifier phone mobile_phone is_guest is_pending enabled created_at } columns { id, title, type, archived settings_str } } }",
                Variables = new
                {
                    id = boardId
                }
            };

            var result = await _graphQlHttpClient.SendQueryAsync<GetBoardsResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Boards.FirstOrDefault();
        }

        /// <summary>
        ///     Gets all groups on a board.
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <returns></returns>
        public async Task<List<Group>> GetGroups(int boardId)
        {
            var request = new GraphQLRequest
            {
                Query = @"query request($id:Int!) { boards(ids: [$id]) { groups { id title color archived deleted }}}",
                Variables = new
                {
                    id = boardId
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<GetGroupsResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Boards.FirstOrDefault()?.Groups;
        }

        /// <summary>
        ///     Get all (up to 100,000) items [excluding columns and subscribers] with simplified boards, groups, and users.
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <returns></returns>
        public async Task<List<Item>> GetItems(int boardId)
        {
            var request = new GraphQLRequest
            {
                Query = @"query request($id:Int) { boards(ids:[$id]) { items(limit: 100000) { id name board { id name description board_kind } group { id title archived deleted } creator_id created_at updated_at creator { id name email } } } } ",
                Variables = new
                {
                    id = boardId
                }
            };

            var result = await _graphQlHttpClient.SendQueryAsync<GetBoardItemsResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Boards.FirstOrDefault()?.Items;
        }

        /// <summary>
        ///     Return a specific item with it's board, group, columns, subscribers, updates, replies and user.
        /// </summary>
        /// <param name="itemId">The item’s unique identifier.</param>
        /// <returns></returns>
        public async Task<Item> GetItem(int itemId)
        {
            var request = new GraphQLRequest
            {
                Query = @"query request($id:Int) { items(ids: [$id]) { id name board { id name description board_kind state board_folder_id } group { id title color archived deleted } column_values { id text title type value additional_info } subscribers { id name email } updates(limit: 100000) { id body text_body replies { id body text_body creator_id creator { id name email } created_at updated_at } creator_id creator { id name email } created_at updated_at } creator_id created_at updated_at creator { id name email } } } ",
                Variables = new
                {
                    id = itemId
                }
            };

            var result = await _graphQlHttpClient.SendQueryAsync<GetItemsResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Items.FirstOrDefault();
        }

        /// <summary>
        ///     Gets all tags on a board.
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <returns></returns>
        public async Task<List<Tag>> GetTags(int boardId)
        {
            var request = new GraphQLRequest
            {
                Query = @"query request($id:Int!) { boards(ids: [$id]) { tags { id name color } } } ",
                Variables = new
                {
                    id = boardId
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<GetBoardTagsResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Boards.FirstOrDefault()?.Tags;
        }

        /// <summary>
        ///     Returns a specific tag.
        /// </summary>
        /// <param name="tagId">The tag’s unique identifier.</param>
        /// <returns></returns>
        public async Task<Tag> GetTag(int tagId)
        {
            var request = new GraphQLRequest
            {
                Query = @"query request($id:Int!) { tags(ids: [$id]) { id name color } }",
                Variables = new
                {
                    id = tagId
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<GetTagsResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Tags.FirstOrDefault();
        }

        /// <summary>
        ///     Gets all teams with simplified users.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Team>> GetTeams()
        {
            var request = new GraphQLRequest
            {
                Query = @"query request { teams { id name picture_url users { id name email } } }"
            };

            var result = await _graphQlHttpClient.SendMutationAsync<GetTeamsResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Teams;
        }

        /// <summary>
        ///     Returns a specific team with simplified users.
        /// </summary>
        /// <returns></returns>
        public async Task<Team> GetTeam(int teamId)
        {
            var request = new GraphQLRequest
            {
                Query = @"query request($id:Int!) { teams(ids: [$id]) { id name picture_url users { id name email } } }",
                Variables = new
                {
                    id = teamId
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<GetTeamsResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Teams.FirstOrDefault();
        }

        /// <summary>
        ///     Returns the api rate limit (how much of your 1 minute cap is left)
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetRateLimit()
        {
            var request = new GraphQLRequest
            {
                Query = @"query request { complexity { after } }"
            };

            var result = await _graphQlHttpClient.SendMutationAsync<GetComplexityResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Complexity.After;
        }

        /// <summary>
        ///     Get the complexity data of your queries.
        /// </summary>
        /// <param name="query">The request query.</param>
        /// <returns></returns>
        public async Task<Complexity> GetComplexity(string query)
        {
            var requestQuery = @"query request { complexity { before after query }";
            var complexityQuery = $"{requestQuery} \n {query}}}";

            var request = new GraphQLRequest
            {
                Query = complexityQuery
            };

            var result = await _graphQlHttpClient.SendMutationAsync<GetComplexityResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Complexity;
        }

        /// <summary>
        ///     Creates a board.
        /// </summary>
        /// <param name="createBoard">The mutation model.</param>
        /// <returns></returns>
        public async Task<int> CreateBoard(CreateBoard createBoard)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation request($name:String! $boardKind:BoardKind!) { create_board (board_name: $name, board_kind: $boardKind) { id }}",
                Variables = new
                {
                    name = createBoard.Name,
                    boardKind = createBoard.BoardAccessType.GetVariableBoardAccessType()
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<CreateBoardResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Board.Id;
        }

        /// <summary>
        ///     Archives a board.
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <returns></returns>
        public async Task<bool> ArchiveBoard(int boardId)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation request($id:Int!) { archive_board (board_id: $id) { id }}",
                Variables = new
                {
                    id = boardId
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<dynamic>(request);

            ThrowResponseErrors(result.Errors);

            return result.Errors == null;
        }

        /// <summary>
        ///     Create a new column in board.
        /// </summary>
        /// <param name="createColumn">The mutation model.</param>
        /// <returns></returns>
        public async Task<string> CreateColumn(CreateColumn createColumn)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation request($boardId:Int! $name:String! $columnType:ColumnType $defaults:JSON) { create_column (board_id: $boardId, title: $name, column_type: $columnType, defaults: $defaults) { id }}",
                Variables = new
                {
                    boardId = createColumn.BoardId,
                    name = createColumn.Name,
                    columnType = createColumn.ColumnType.GetVariableColumnType(),
                    defaults = createColumn.Defaults
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<CreateColumnResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Column.Id;
        }

        /// <summary>
        ///     Update the value of a column for a specific item.
        /// </summary>
        /// <param name="updateColumn">The mutation model.</param>
        /// <returns></returns>
        public async Task<bool> UpdateColumn(UpdateColumn updateColumn)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation request($boardId:Int! $itemId:Int $columnId: String! $value:JSON!) { change_column_value (board_id: $boardId, item_id: $itemId, column_id: $columnId, value: $value) { id }}",
                Variables = new
                {
                    boardId = updateColumn.BoardId,
                    itemId = updateColumn.ItemId,
                    columnId = updateColumn.ColumnId,
                    value = updateColumn.Value
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<dynamic>(request);

            ThrowResponseErrors(result.Errors);

            return result.Errors == null;
        }

        /// <summary>
        ///     Creates a new group in a specific board.
        /// </summary>
        /// <param name="createGroup">The mutation model.</param>
        /// <returns></returns>
        public async Task<string> CreateGroup(CreateGroup createGroup)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation request($boardId:Int! $name:String!) { create_group (board_id: $boardId, group_name: $name) { id } }",
                Variables = new
                {
                    boardId = createGroup.BoardId,
                    name = createGroup.Name
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<CreateGroupResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Group.Id;
        }

        /// <summary>
        ///     Archives a group in a specific board.
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <returns></returns>
        public async Task<bool> ArchiveGroup(int boardId, string groupId)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation request($boardId:Int! $groupId:String!) { archive_group (board_id: $boardId, group_id: $groupId) { id }}",
                Variables = new
                {
                    boardId,
                    groupId
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<dynamic>(request);

            ThrowResponseErrors(result.Errors);

            return result.Errors == null;
        }

        /// <summary>
        ///     Deletes a group in a specific board.
        /// </summary>
        /// <param name="boardId">The board’s unique identifier.</param>
        /// <param name="groupId">THe group's unique identifier</param>
        /// <returns></returns>
        public async Task<bool> DeleteGroup(int boardId, string groupId)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation request($boardId:Int! $groupId:String!) { delete_group (board_id: $boardId, group_id: $groupId) { id }}",
                Variables = new
                {
                    boardId,
                    groupId
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<dynamic>(request);

            ThrowResponseErrors(result.Errors);

            return result.Errors == null;
        }

        /// <summary>
        ///     Create a new item.
        /// </summary>
        /// <param name="createItem">The mutation model.</param>
        /// <returns></returns>
        public async Task<int> CreateItem(CreateItem createItem)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation request($boardId:Int! $groupId:String $name:String $columnValues:JSON) { create_item (board_id: $boardId, group_id: $groupId, item_name: $name, column_values: $columnValues) { id } }",
                Variables = new
                {
                    boardId = createItem.BoardId,
                    groupId = createItem.GroupId,
                    name = createItem.Name,
                    columnValues = createItem.ColumnValues
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<CreateItemResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Item.Id;
        }

        /// <summary>
        ///     Clear an item's updates.
        /// </summary>
        /// <param name="itemId">The item’s unique identifier.</param>
        /// <returns></returns>
        public async Task<bool> ClearItemUpdates(int itemId)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation request($id:Int!) { clear_item_updates (item_id: $id) {id}}",
                Variables = new
                {
                    id = itemId
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<dynamic>(request);

            ThrowResponseErrors(result.Errors);

            return result.Errors == null;
        }

        /// <summary>
        ///     Move an item to a different group.
        /// </summary>
        /// <param name="itemId">The item’s unique identifier.</param>
        /// <param name="groupId">The group’s unique identifier</param>
        /// <returns></returns>
        public async Task<bool> UpdateItemGroup(int itemId, string groupId)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation request($itemId:Int! $groupId:String!) { move_item_to_group (item_id: $itemId, group_id: $groupId) {id}}",
                Variables = new
                {
                    itemId,
                    groupId
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<dynamic>(request);

            ThrowResponseErrors(result.Errors);

            return result.Errors == null;
        }

        /// <summary>
        ///     Archive an item.
        /// </summary>
        /// <param name="itemId">The item’s unique identifier.</param>
        /// <returns></returns>
        public async Task<bool> ArchiveItem(int itemId)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation request($id:Int!) { archive_item (item_id: $id) {id}}",
                Variables = new
                {
                    id = itemId
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<dynamic>(request);

            ThrowResponseErrors(result.Errors);

            return result.Errors == null;
        }

        /// <summary>
        ///     Delete an item.
        /// </summary>
        /// <param name="itemId">The item’s unique identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteItem(int itemId)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation request($id:Int!) { delete_item (item_id: $id) {id}}",
                Variables = new
                {
                    id = itemId
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<dynamic>(request);

            ThrowResponseErrors(result.Errors);

            return result.Errors == null;
        }

        /// <summary>
        ///     Create a new update.
        /// </summary>
        /// <param name="createUpdate">The mutation model.</param>
        /// <returns></returns>
        public async Task<int> CreateUpdate(CreateUpdate createUpdate)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation request($itemId:Int $body:String!) { create_update (item_id: $itemId, body: $body) {id}}",
                Variables = new
                {
                    itemId = createUpdate.ItemId,
                    body = createUpdate.Body
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<CreateUpdateResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Update.Id;
        }

        /// <summary>
        ///     Create a new tag or get it if it already exists.
        /// </summary>
        /// <param name="createTag">The mutation model.</param>
        /// <returns></returns>
        public async Task<int> CreateTag(CreateTag createTag)
        {
            var request = new GraphQLRequest
            {
                Query = @"mutation request($boardId:Int $name:String) { create_or_get_tag  (board_id: $boardId, tag_name: $name) {id}}",
                Variables = new
                {
                    boardId = createTag.BoardId,
                    name = createTag.Name
                }
            };

            var result = await _graphQlHttpClient.SendMutationAsync<CreateTagResponse>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data.Tag.Id;
        }

        /// <summary>
        ///     Leverage a custom query or mutation using the available responses/models
        /// </summary>
        /// <typeparam name="T">Generic object return</typeparam>
        /// <param name="queryOrMutation">A custom query or mutation</param>
        /// <returns></returns>
        public async Task<T> CustomQueryOrMutation<T>(string queryOrMutation)
        {
            return await CustomQueryOrMutation<T>(queryOrMutation, null);
        }

        /// <summary>
        ///     Leverage a custom query or mutation using the available responses/models
        /// </summary>
        /// <typeparam name="T">Generic object return</typeparam>
        /// <param name="queryOrMutation">A custom query or mutation</param>
        /// <param name="variables">Anonymous object with variables and values</param>
        /// <returns></returns>
        public async Task<T> CustomQueryOrMutation<T>(string queryOrMutation, object variables)
        {
            var request = new GraphQLRequest
            {
                Query = queryOrMutation
            };

            if (variables != null)
            {
                request.Variables = variables;
            }

            var result = await _graphQlHttpClient.SendMutationAsync<T>(request);

            ThrowResponseErrors(result.Errors);

            return result.Data;
        }
    }
}