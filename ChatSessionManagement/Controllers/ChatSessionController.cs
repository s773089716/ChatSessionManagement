using ChatSessionManagement.Core.Services;
using ChatSessionManagement.DTOs;
using ChatSessionManagement.Infrastructure.Enumerations;
using ChatSessionManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatSessionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatSessionController : ControllerBase
    {
        #region Private Variables -----------------------------------------------------------------
        private IChatSessionService _chatSessionService;
        private readonly ILogger<ChatSessionController> _logger;
        #endregion

        #region Constructors ----------------------------------------------------------------------        
        public ChatSessionController(IChatSessionService chatSessionService, ILogger<ChatSessionController> logger)
        {
            //TODO: Need to use proper logging provider and be injected through middleware
            _logger = logger;
            _chatSessionService = chatSessionService;
        }
        #endregion

        #region Web Methods -----------------------------------------------------------------------          
        [HttpPost]
        [Route("CreateChatSession")]
        public async Task<ActionResult<CreateChatSessionResponse>> CreateChatSession()
        {
            CreateChatSessionResponse response = new CreateChatSessionResponse();
            try
            {
                ChatSession chatSession = await _chatSessionService.CreateChatSession();                

                if (chatSession != null)
                {
                    response.ChatSession = chatSession;
                    return Ok(response);
                }                    
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.MessageType = DTOMessageType.Error;
            }

            return new BadRequestObjectResult(response);
        }

        [HttpPost]
        [Route("CheckChatSessionStatus")]
        public async Task<ActionResult<CreateChatSessionResponse>> CheckChatSessionStatus(CheckChatSessionStatusRequest request)
        {
            CheckChatSessionStatusResponse response = new CheckChatSessionStatusResponse();
            try
            {
                if (request == null)
                    throw new Exception("Invalid request");

                if (String.IsNullOrEmpty(request.Token))
                    throw new Exception("Invalid token");

                ChatSession chatSession = await _chatSessionService.CheckChatSessionStatus(request.Token);

                if (chatSession != null)
                {
                    response.ChatSession = chatSession;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.MessageType = DTOMessageType.Error;
            }

            return new BadRequestObjectResult(response);
        }
        #endregion
    }
}
