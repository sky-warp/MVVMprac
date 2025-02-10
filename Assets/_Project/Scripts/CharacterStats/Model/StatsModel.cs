using _Project.Scripts.Infrastructure;

namespace _Project.Scripts.CharacterStats.Model
{
    public class StatsModel
    {
        public readonly ReactProp<int> STR = new();
        public readonly ReactProp<int> DEX = new();
        public readonly ReactProp<int> INT = new();
        
        private int _availableSkillPoints;

        public int AvailableSkillPoints
        {
            get => _availableSkillPoints;
            set
            {
                _availableSkillPoints = value;
            }
        }

        public StatsModel(int str, int dex, int intel, int availableSkillPoints)
        {
            STR.Value = str;
            DEX.Value = dex;
            INT.Value = intel;
            AvailableSkillPoints = availableSkillPoints;
        }
    }
}