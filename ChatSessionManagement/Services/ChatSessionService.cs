using ChatSessionManagement.Core.Repositories;
using ChatSessionManagement.Core.Services;
using ChatSessionManagement.DTOs;
using ChatSessionManagement.Infrastructure.Configurations;
using ChatSessionManagement.Infrastructure.Enumerations;
using ChatSessionManagement.Models;
using ChatSessionManagement.Repositories.InMemoryRepositories;
using RoundRobin;
using System.Collections.Concurrent;

namespace ChatSessionManagement.Services
{
    public class ChatSessionService : IChatSessionService
    {
        #region Private Variables -----------------------------------------------------------------
        IChatSessionRepository _chatSessionRepository;
        ITeamRepository _teamRepository;

        //private static BlockingCollection<ChatSession> bCollection = new BlockingCollection<ChatSession>();
        private static ConcurrentDictionary<string, ChatSession> _chatSessionGlobalDictionary = new ConcurrentDictionary<string, ChatSession>();
        #endregion        

        private static string? _availableNormalTeamName_Previous = null;        

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

            if (chatSession == null || String.IsNullOrEmpty(chatSession.Token))
            {
                throw new Exception("Created session or token is invalid!");
            }
            string normalTeamName = _teamRepository.GetAvailableNormalTeamName();

            Team? team = null;

            if (!String.IsNullOrEmpty(normalTeamName))
            {
                _teamRepository.Teams?.TryGetValue(normalTeamName, out team);

                if (team != null && team.ChatSessions != null)
                {
                    isSuccess = team.ChatSessions.TryAdd(chatSession);

                    if (isSuccess)
                        _chatSessionGlobalDictionary.TryAdd(chatSession.Token, chatSession);

                    if (!isSuccess)
                    {
                        team = null;

                        string overflowTeamName = _teamRepository.GetAvailableOverflowTeamName();

                        if (!String.IsNullOrEmpty(overflowTeamName))
                        {
                            _teamRepository.Teams?.TryGetValue(overflowTeamName, out team);

                            if (team != null && team.ChatSessions != null)
                            {
                                isSuccess = team.ChatSessions.TryAdd(chatSession);
                                if (isSuccess)
                                    _chatSessionGlobalDictionary.TryAdd(chatSession.Token, chatSession);

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

        public async Task AssignChatSessionToAgent(CancellationToken stoppingToken)
        {
            ChatSession? chatSession = null;
            Team? team = null;
            while (!stoppingToken.IsCancellationRequested)
            {
                #region Previous Shift Queue ------------------------------------------------------
                string availableNormalTeamName = _teamRepository.GetAvailableNormalTeamName();

                if (!String.IsNullOrEmpty(_availableNormalTeamName_Previous) && !_availableNormalTeamName_Previous.Equals(availableNormalTeamName))
                {                    
                    _teamRepository.Teams?.TryGetValue(_availableNormalTeamName_Previous, out team);
                    if (team != null && team.ChatSessions != null && team.ChatSessions.Count > 0)
                    {
                        chatSession = null;
                        team.ChatSessions.TryTake(out chatSession);

                        if (chatSession != null && !chatSession.IsActive)
                            continue;
                    }
                    else
                        _availableNormalTeamName_Previous = availableNormalTeamName;
                }
                #endregion

                #region Normal Team ---------------------------------------------------------------
                _teamRepository.Teams?.TryGetValue(availableNormalTeamName, out team);

                if (team != null)
                {
                    if (chatSession == null && team.ChatSessions != null && team.ChatSessions.Count > 0)
                    {
                        team.ChatSessions.TryTake(out chatSession);

                        if (chatSession != null && !chatSession.IsActive)
                            continue;
                    }

                    bool isAssigned = false;
                    if (chatSession != null && chatSession.IsActive)
                    {
                        if (team.RoundRobinListOfAgents != null)
                        {
                            foreach (SeniorityTypeEnum type in team.RoundRobinListOfAgents.Keys)
                            {
                                RoundRobinList<Agent>? roundRobinListOfAgents = null;

                                team.RoundRobinListOfAgents.TryGetValue(type, out roundRobinListOfAgents);

                                if (roundRobinListOfAgents != null)
                                {
                                    int agentIndex = team.AgentCountBySeniorityType[type];
                                    while (agentIndex > 0 && !isAssigned)
                                    {
                                        Agent agent = roundRobinListOfAgents.Next();

                                        if (agent != null && agent.AssignedChatSessions.Count < agent.Capacity)
                                        {
                                            isAssigned = agent.AssignedChatSessions.TryAdd(chatSession);
                                        }

                                        agentIndex--;
                                    }                                    
                                }
                            }
                        }
                    }                                        
                }
                #endregion

                #region Overflow Team -------------------------------------------------------------
                string overflowTeamName = _teamRepository.GetOverflowTeamName();
                if (!String.IsNullOrEmpty(overflowTeamName))
                {
                    _teamRepository.Teams?.TryGetValue(overflowTeamName, out team);

                    if (team != null)
                    {
                        if (chatSession == null && team.ChatSessions != null && team.ChatSessions.Count > 0)
                        {
                            team.ChatSessions.TryTake(out chatSession);

                            if (chatSession != null && !chatSession.IsActive)
                                continue;
                        }

                        bool isAssigned = false;
                        if (chatSession != null && chatSession.IsActive)
                        {
                            if (team.RoundRobinListOfAgents != null)
                            {
                                foreach (SeniorityTypeEnum type in team.RoundRobinListOfAgents.Keys)
                                {
                                    RoundRobinList<Agent>? roundRobinListOfAgents = null;

                                    team.RoundRobinListOfAgents.TryGetValue(type, out roundRobinListOfAgents);

                                    if (roundRobinListOfAgents != null)
                                    {
                                        int agentIndex = team.AgentCountBySeniorityType[type];
                                        while (agentIndex > 0 && !isAssigned)
                                        {
                                            Agent agent = roundRobinListOfAgents.Next();

                                            if (agent != null && agent.AssignedChatSessions.Count < agent.Capacity)
                                            {
                                                isAssigned = agent.AssignedChatSessions.TryAdd(chatSession);
                                            }

                                            agentIndex--;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
            }
        }

        public async Task InactivateExpiredChatSessions(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (ChatSession chatSession in _chatSessionGlobalDictionary.Values)
                {
                    if ( DateTime.Now.Subtract(chatSession.LastPollDateTime).TotalSeconds > ApplicationConfig.ExpirationDurationInSeconds)
                        chatSession.IsActive = false;
                }
                await Task.Delay(1000);
            }
        }

        public async Task<ChatSession?> CheckChatSessionStatus(string token)
        {            
            _chatSessionGlobalDictionary.TryGetValue(token, out var chatSession);
            if (chatSession == null)
                return null;
            
            chatSession.LastPollDateTime = DateTime.Now;

            return chatSession;
        }

        public async Task<ChatSession?> CloseChatSession(string token)
        {
            if (String.IsNullOrEmpty(token))
                throw new Exception("Invalid token");

            if (!_chatSessionGlobalDictionary.ContainsKey(token))
                throw new Exception("Token does not exists!");

            if (_chatSessionGlobalDictionary != null)
            {                
                _chatSessionGlobalDictionary.TryGetValue(token.Trim(), out var chatSession);
                if (chatSession != null)
                {
                    bool IsSuccess = _chatSessionGlobalDictionary.TryRemove(token, out chatSession);

                    if (IsSuccess)
                        return chatSession;
                }                
            }

            return null;
        }
    }
}
