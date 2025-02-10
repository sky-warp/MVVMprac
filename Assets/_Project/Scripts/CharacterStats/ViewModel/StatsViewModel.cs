using _Project.Scripts.Infrastructure;

namespace _Project.Scripts.CharacterStats.ViewModel
{
    public class StatsViewModel
    {
        private const int MAX_SKILL_STAT_VALUE = 18;
        
        //Stats value 
        public ReactiveProperty<int> StrView = new();
        public ReactiveProperty<int> DexView = new();
        public ReactiveProperty<int> IntView = new();
        public ReactiveProperty<int> SkillsPointAvailableView = new();

        public ReactiveProperty<bool> StrButtonEnabled = new();
        public ReactiveProperty<bool> DexButtonEnabled = new();
        public ReactiveProperty<bool> IntButtonEnabled = new();
        
        private StatsDefaultModel _model;

        public StatsViewModel(StatsDefaultModel model)
        {
            _model = model;
            _model.Str.OnValueChanged += OnStrChange;
            _model.Dex.OnValueChanged += OnDexChange;
            _model.Int.OnValueChanged += OnIntChange;
            
            SkillsPointAvailableView.OnValueChanged += OnCheckButtonStatus;
            
            OnResetButtonClicked();
        }

        private void OnStrChange(int value)
        {
            StrView.Value = value;
        }

        private void OnDexChange(int value)
        {
            DexView.Value = value;
        }

        private void OnIntChange(int value)
        {
            IntView.Value = value;
        }

        //Reaction on view buttons pressed
        public void OnIncreaseStrButtonClicked()
        {
            IncreasePropertyValue(StrView);
        }
        
        public void OnIncreaseDexButtonClicked()
        {
            IncreasePropertyValue(DexView);
        }
        
        public void OnIncreaseIntButtonClicked()
        {
            IncreasePropertyValue(IntView);
        }

        private void IncreasePropertyValue(ReactiveProperty<int> prop)
        {
            prop.Value += 1;
            SkillsPointAvailableView.Value -= 1;
        }
        
        //Reset stats
        public void OnResetButtonClicked()
        {
            //ViewModel values will be equal to model's values
            StrView.Value = _model.Str.Value;
            DexView.Value = _model.Dex.Value;
            IntView.Value = _model.Int.Value;
            SkillsPointAvailableView.Value = _model.SkillPointsAvailable;
        }
        
        //Apply stats
        public void OnApplyButtonClicked()
        {
            //Model values will be equal to viewModel values
            _model.Str.Value = StrView.Value;
            _model.Dex.Value = DexView.Value;
            _model.Int.Value = IntView.Value;
            _model.SkillPointsAvailable = SkillsPointAvailableView.Value;   
        }

        private void CheckButtonStatus()
        {
            StrButtonEnabled.Value = StrView.Value < MAX_SKILL_STAT_VALUE;
            DexButtonEnabled.Value = DexView.Value < MAX_SKILL_STAT_VALUE;
            IntButtonEnabled.Value = IntView.Value < MAX_SKILL_STAT_VALUE;

            if (SkillsPointAvailableView.Value <= 0)
            {
                StrButtonEnabled.Value = false;
                DexButtonEnabled.Value = false;
                IntButtonEnabled.Value = false;
            }
        }
        
        private void OnCheckButtonStatus(int obj)
        {
            CheckButtonStatus();
        }
    }
}
