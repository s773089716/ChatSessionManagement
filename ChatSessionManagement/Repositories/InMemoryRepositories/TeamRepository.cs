using ChatSessionManagement.Core.Repositories;
using ChatSessionManagement.Infrastructure.Factories;
using ChatSessionManagement.Infrastructure.Enumerations;
using ChatSessionManagement.Models;
using System.Collections.Concurrent;
using ChatSessionManagement.Infrastructure.Configurations;

namespace ChatSessionManagement.Repositories.InMemoryRepositories
{
    public class TeamRepository : ITeamRepository
    {
        private static ConcurrentDictionary<string, Team>? _teams = null;
        private IAgentRepository _agentRepository;

        public ConcurrentDictionary<string, Team>? Teams
        {
            get
            {
                if (_teams == null)
                {
                    Team _team;
                    _teams = new ConcurrentDictionary<string, Team>();

                    _team = TeamFactory.CreateTeamA();
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Lead));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Midlevel));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Midlevel));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.ChatSessions = new BlockingCollection<ChatSession>(Convert.ToInt32( _team.Capacity * ApplicationConfig.QueueMutiplier));
                    _teams.TryAdd(TeamFactory.TeamName.TeamA, _team);

                    _team = TeamFactory.CreateTeamB();
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Senior));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Midlevel));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.ChatSessions = new BlockingCollection<ChatSession>(Convert.ToInt32(_team.Capacity * ApplicationConfig.QueueMutiplier));
                    _teams.TryAdd(TeamFactory.TeamName.TeamB, _team);

                    _team = TeamFactory.CreateTeamC();                    
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Midlevel));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Midlevel));
                    _team.ChatSessions = new BlockingCollection<ChatSession>(Convert.ToInt32(_team.Capacity * ApplicationConfig.QueueMutiplier));
                    _teams.TryAdd(TeamFactory.TeamName.TeamC, _team);

                    _team = TeamFactory.CreateTeamO();
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.ChatSessions = new BlockingCollection<ChatSession>(Convert.ToInt32(_team.Capacity * ApplicationConfig.QueueMutiplier));
                    _teams.TryAdd(TeamFactory.TeamName.TeamOverflow, _team);                    

                }
                return _teams;
            }
        }

        public TeamRepository(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public string GetAvailableNormalTeamName()
        {
            DateTime time = DateTime.Now;
            if (time.Hour >= 6 && time.Hour < 14)
                return TeamFactory.TeamName.TeamA;
            else if (time.Hour >= 14 && time.Hour < 22)
                return TeamFactory.TeamName.TeamB;
            else
                return TeamFactory.TeamName.TeamC;
        }

        public string GetAvailableOverflowTeamName()
        {
            DateTime time = DateTime.Now;
            if (time.Hour >= 6 && time.Hour < 22)
                return TeamFactory.TeamName.TeamOverflow;
            else
                return String.Empty;
        }
    }
}
