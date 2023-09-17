using ChatSessionManagement.Core.Repositories;
using ChatSessionManagement.Core.Services;
using ChatSessionManagement.DTOs;
using ChatSessionManagement.Models;
using ChatSessionManagement.Repositories.InMemoryRepositories;

namespace ChatSessionManagement.Services
{
    public class ChatSessionService : IChatSessionService
    {
        #region Private Variables -----------------------------------------------------------------
        IChatSessionRepository _chatSessionRepository;
        #endregion

        #region Constructors ----------------------------------------------------------------------
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="droneRepository"></param>
        public ChatSessionService(IChatSessionRepository chatSessionRepository)
        {
            _chatSessionRepository = chatSessionRepository;
        }
        #endregion

        public async Task<ChatSession> CreateChatSession()
        {
            return await _chatSessionRepository.CreateNewChatSession();
        }

        public async Task<ChatSession> CheckChatSession(string token)
        {
            return await _chatSessionRepository.CheckChatSessionStatus(token);
        }
    }
}
