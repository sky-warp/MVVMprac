using _Project.Scripts.CharacterStats.Model;
using _Project.Scripts.Infrastructure;

namespace _Project.Scripts.CharacterStats.ViewModel
{
    public class StatsViewModel
    {
        private const int MAX_STAT_VALUE = 18;
        
        public ReactProp<int> StrView = new();
        public ReactProp<int> DexView = new();
        public ReactProp<int> IntView = new();        
        public ReactProp<int> SkillPoints = new();        
        
        public ReactProp<bool> StrButtonAvailable = new();
        public ReactProp<bool> DexButtonAvailable = new();
        public ReactProp<bool> IntButtonAvailable = new();
        
        private StatsModel _statsModel;

        public StatsViewModel(StatsModel statsModel)
        {
            _statsModel = statsModel;
            _statsModel.STR.OnValueChanged += StrValueChange;
            _statsModel.DEX.OnValueChanged += DexValueChange;
            _statsModel.INT.OnValueChanged += IntValueChange;

            SkillPoints.OnValueChanged += OnSkilPointsChange;
            
            OnResetButtonClicked();
        }

        public void OnResetButtonClicked()
        {
            StrView.Value = _statsModel.STR.Value;
            DexView.Value = _statsModel.DEX.Value;
            IntView.Value = _statsModel.INT.Value;
            
            SkillPoints.Value = _statsModel.AvailableSkillPoints;
        }

        public void OnApplyButtonClicked()
        {
            _statsModel.STR.Value = StrView.Value;
            _statsModel.DEX.Value = DexView.Value;
            _statsModel.INT.Value = IntView.Value;
            
            _statsModel.AvailableSkillPoints = SkillPoints.Value;
        }

        public void OnIncreaseStrButtonClicked()
        {
            OnIncreaseStatButtonClicked(StrView);
        }
        
        public void OnIncreaseDexButtonClicked()
        {
            OnIncreaseStatButtonClicked(DexView);
        }
        
        public void OnIncreaseIntButtonClicked()
        {
            OnIncreaseStatButtonClicked(IntView);
        }
        
        private void StrValueChange(int value)
        {
            StrView.Value = value;
        }
        
        private void DexValueChange(int value)
        {
            DexView.Value = value;
        }

        private void IntValueChange(int value)
        {
            IntView.Value = value;
        }
        
        private void OnSkilPointsChange(int obj)
        {
            CheckButtonEnable();
        }

        private void OnIncreaseStatButtonClicked(ReactProp<int> stat)
        {
            stat.Value += 1;
            SkillPoints.Value -= 1;
        }
        
        private void CheckButtonEnable()
        {
            StrButtonAvailable.Value = StrView.Value < MAX_STAT_VALUE;
            DexButtonAvailable.Value = DexView.Value < MAX_STAT_VALUE;
            IntButtonAvailable.Value = IntView.Value < MAX_STAT_VALUE;

            if (SkillPoints.Value <= 0)
            {
                StrButtonAvailable.Value = false;
                DexButtonAvailable.Value = false;
                IntButtonAvailable.Value = false;
            }
        }
    }
}