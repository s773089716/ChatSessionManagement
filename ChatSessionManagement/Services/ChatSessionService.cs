using ChatSessionManagement.Core.Repositories;
using ChatSessionManagement.Core.Services;
using ChatSessionManagement.DTOs;
using ChatSessionManagement.Models;
using ChatSessionManagement.Repositories.InMemoryRepositories;
using System.Collections.Concurrent;

namespace ChatSessionManagement.Services
{
    public class ChatSessionService : IChatSessionService
    {
        #region Private Variables -----------------------------------------------------------------
        IChatSessionRepository _chatSessionRepository;
        ITeamRepository _teamRepository;

        //private static BlockingCollection<ChatSession> bCollection = new BlockingCollection<ChatSession>();
        //private static ConcurrentDictionary<string, BlockingCollection<ChatSession>> _teams = new ConcurrentDictionary<string, BlockingCollection<ChatSession>>();
        #endregion

        //public ConcurrentDictionary<string, BlockingCollection<ChatSession>> Teams
        //{
        //    get
        //    {
        //        _teamRepository.Teams;
        //    }
        //}


        #region Constructors ----------------------------------------------------------------------
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="droneRepository"></param>
        public ChatSessionService(IChatSessionRepository chatSessionRepository, ITeamRepository teamRepository)
        {
            _chatSessionRepository = chatSessionRepository;
            _teamRepository = teamRepository;
        }
        #endregion

        public async Task<ChatSession> CreateChatSession()
        {
            bool isSuccess = false;
            string message = string.Empty;
            ChatSession chatSession = await _chatSessionRepository.CreateNewChatSession();
            string normalTeamName = _teamRepository.GetAvailableNormalTeamName();            

            Team? team = null;

            if (!String.IsNullOrEmpty(normalTeamName))
            {
                _teamRepository.Teams?.TryGetValue(normalTeamName, out team);

                if (team != null && team.ChatSessions != null)
                {
                    isSuccess = team.ChatSessions.TryAdd(chatSession);
                    if (!isSuccess)
                    {
                        team = null;

                        string overflowTeamName = _teamRepository.GetAvailableNormalTeamName();

                        if (!String.IsNullOrEmpty(overflowTeamName))
                        {
                            _teamRepository.Teams?.TryGetValue(overflowTeamName, out team);

                            if (team != null && team.ChatSessions != null)
                            {
                                isSuccess = team.ChatSessions.TryAdd(chatSession);

                                if (!isSuccess)
                                    message = "Both normal team and overflow teams are full!";

                            }
                        }
                        else
                            message = "Normal team is full!";
                    }
                }
                else
                    message = "Allocated team not found!";
            }
            else
                message = "Allocated team name not found!";

            if (!isSuccess)
            {
                chatSession.Token = null;

                if (String.IsNullOrEmpty(message))
                    message = "Session is not successfull due to some problem!";
            }

            return chatSession;
        }

        public async Task<ChatSession> CheckChatSession(string token)
        {
            return await _chatSessionRepository.CheckChatSessionStatus(token);
        }
    }
}
