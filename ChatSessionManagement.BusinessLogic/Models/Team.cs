using ChatSessionManagement.BusinessLogic.Infrastructure.Enumerations;
using RoundRobin;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ChatSessionManagement.BusinessLogic.Models
{
    public abstract class Team
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = String.Empty;
        public TeamTypeEnum TeamType { get; set; } = TeamTypeEnum.Normal;
        public List<Agent> MemberList { get; set; } = new List<Agent>();
        public BlockingCollection<ChatSession>? ChatSessions { get; set; }
        public ConcurrentDictionary<SeniorityTypeEnum, RoundRobinList<Agent>>? RoundRobinListOfAgents { get; set; } = null;
        public ConcurrentDictionary<SeniorityTypeEnum, int> AgentCountBySeniorityType { get; set; } = new ConcurrentDictionary<SeniorityTypeEnum, int>();

        public short Capacity
        {
            get
            {
                short capacity = 0;

                foreach (var agent in MemberList)                
                    capacity += agent.Capacity;

                return capacity;
            }
        }  

        public void BuildRoundRobinListOfAgents()
        {            
            if (RoundRobinListOfAgents == null)
            {
                RoundRobinListOfAgents = new ConcurrentDictionary<SeniorityTypeEnum, RoundRobinList<Agent>>();

                foreach (SeniorityTypeEnum type in Enum.GetValues(typeof(SeniorityTypeEnum)))
                {
                    List<Agent>? agentList = (from a in MemberList
                                              where a.SeniorityType == type
                                              select a).ToList();

                    if (agentList != null)
                    {
                        RoundRobinListOfAgents.TryAdd(type, new RoundRobinList<Agent>(agentList));

                        AgentCountBySeniorityType.TryAdd(type, agentList.Count);
                    }
                }
            }                       
        }        
    }
}
