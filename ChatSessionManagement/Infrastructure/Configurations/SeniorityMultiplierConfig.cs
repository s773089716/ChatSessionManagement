using ChatSessionManagement.Infrastructure.Enumerations;

namespace ChatSessionManagement.Infrastructure.Configurations
{
    public static class SeniorityMultiplierConfig
    {
        private static Dictionary<SeniorityTypeEnum, float>? _seniorityMultiplier = null;

        private static Dictionary<SeniorityTypeEnum, float> SeniorityMultiplier
        {
            get
            {
                if (_seniorityMultiplier == null)
                {
                    _seniorityMultiplier = new Dictionary<SeniorityTypeEnum, float>()
                    {
                        { SeniorityTypeEnum.Junior, 0.4F },
                        { SeniorityTypeEnum.Midlevel, 0.6F },
                        { SeniorityTypeEnum.Senior, 0.8F },
                        { SeniorityTypeEnum.Lead, 0.5F },
                    };

                }
                return _seniorityMultiplier;
            }
        }

        private static Dictionary<SeniorityTypeEnum, float>? GetSeniorityMultiplierList()
        {
            return SeniorityMultiplier;
        }

        public static float GetSeniorityMultiplierBySeniorityTypeEnum(SeniorityTypeEnum seniorityTypeEnum)
        {
            if (SeniorityMultiplier.ContainsKey(seniorityTypeEnum))
                return SeniorityMultiplier[seniorityTypeEnum];

            return 0F;
        }
    }
}
