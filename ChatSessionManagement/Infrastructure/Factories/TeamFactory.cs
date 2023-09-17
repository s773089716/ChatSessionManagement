using ChatSessionManagement.Models;

namespace ChatSessionManagement.Infrastructure.Factories
{
    public static class TeamFactory
    {
        public static class TeamName
        {
            public readonly static string TeamA = "Team A";
            public readonly static string TeamB = "Team B";
            public readonly static string TeamC = "Team C";
            public readonly static string TeamOverflow = "Team Overflow";
        }
        public static Team CreateTeamA()
        {
            NormalTeam team = new NormalTeam();
            team.Name = TeamName.TeamA;

            return team;
        }

        public static Team CreateTeamB()
        {
            NormalTeam team = new NormalTeam();
            team.Name = TeamName.TeamB;
            return team;
        }

        public static Team CreateTeamC()
        {
            NormalTeam team = new NormalTeam();
            team.Name = TeamName.TeamC;
            team.IsNightShift = true;
            return team;
        }

        public static Team CreateTeamO()
        {
            OverflowTeam team = new OverflowTeam();
            team.Name = TeamName.TeamOverflow;

            return team;
        }
    }
}
