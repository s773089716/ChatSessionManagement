using ChatSessionManagement.Core.Repositories;
using ChatSessionManagement.Infrastructure.Factories;
using ChatSessionManagement.Infrastructure.Enumerations;
using ChatSessionManagement.Models;

namespace ChatSessionManagement.Repositories.InMemoryRepositories
{
    public class TeamRepository : ITeamRepository
    {
        private static Dictionary<string, Team>? _teams = null;
        private IAgentRepository _agentRepository;

        public Dictionary<string, Team>? Teams
        {
            get
            {
                if (_teams == null)
                {
                    Team _team;
                    _teams = new Dictionary<string, Team>();

                    _team = TeamFactory.CreateTeamA();
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Lead));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Midlevel));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Midlevel));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _teams.Add(TeamFactory.TeamName.TeamA, _team);

                    _team = TeamFactory.CreateTeamB();
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Senior));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Midlevel));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));                    
                    _teams.Add(TeamFactory.TeamName.TeamB, _team);

                    _team = TeamFactory.CreateTeamC();                    
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Midlevel));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Midlevel));
                    _teams.Add(TeamFactory.TeamName.TeamC, _team);

                    _team = TeamFactory.CreateTeamO();
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _team.MemberList.Add(_agentRepository.GetNextAgentBySeniorityType(SeniorityTypeEnum.Junior));
                    _teams.Add(TeamFactory.TeamName.TeamOverflow, _team);

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
