using _Project.Scripts.CharacterStats.ViewModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.CharacterStats.View
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private Button _increaseStrButton;
        [SerializeField] private Button _increaseDexButton;
        [SerializeField] private Button _increaseIntButton;

        [SerializeField] private Button _applyStatsButton;
        [SerializeField] private Button _resetStatsButton;
        
        [SerializeField] private TextMeshProUGUI _strStatText;
        [SerializeField] private TextMeshProUGUI _dexStatText;
        [SerializeField] private TextMeshProUGUI _intStatText;
        
        [SerializeField] private TextMeshProUGUI _availableSkillPointsText;
        
        [SerializeField] private Sprite _avaliableButtonSprite;
        [SerializeField] private Sprite _notAvailableButtonSprite;
        
        private StatsViewModel _statsViewModel;

        public void Init(StatsViewModel statsViewModel)
        {
            _statsViewModel = statsViewModel;

            _statsViewModel.StrView.OnValueChanged += ShowStrStatValue;
            _statsViewModel.DexView.OnValueChanged += ShowDexStatValue;
            _statsViewModel.IntView.OnValueChanged += ShowIntStatValue;
            
            _statsViewModel.StrButtonAvailable.OnValueChanged += OnIncreaseStrStatButtonAvailable;
            _statsViewModel.DexButtonAvailable.OnValueChanged += OnIncreaseDexStatButtonAvailable;
            _statsViewModel.IntButtonAvailable.OnValueChanged += OnIncreaseIntStatButtonAvailable;
            
            _statsViewModel.SkillPoints.OnValueChanged += ShowAvailableSkillPoints;
            
            _increaseStrButton.onClick.AddListener(_statsViewModel.OnIncreaseStrButtonClicked);
            _increaseDexButton.onClick.AddListener(_statsViewModel.OnIncreaseDexButtonClicked);
            _increaseIntButton.onClick.AddListener(_statsViewModel.OnIncreaseIntButtonClicked);
            
            _applyStatsButton.onClick.AddListener(_statsViewModel.OnApplyButtonClicked);
            _resetStatsButton.onClick.AddListener(_statsViewModel.OnResetButtonClicked);
            
            _strStatText.text = _statsViewModel.StrView.Value.ToString();
            _dexStatText.text = _statsViewModel.DexView.Value.ToString();
            _intStatText.text = _statsViewModel.IntView.Value.ToString();
            _availableSkillPointsText.text = $"Skill points: {statsViewModel.SkillPoints.Value.ToString()}";
        }

        private void ShowStrStatValue(int value)
        {
            _strStatText.text = value.ToString();
        }
        
        private void ShowDexStatValue(int value)
        {
            _dexStatText.text = value.ToString();
        }
        
        private void ShowIntStatValue(int value)
        {
            _intStatText.text = value.ToString();
        }

        private void ShowAvailableSkillPoints(int value)
        {
            _availableSkillPointsText.text = $"Skill points: {value.ToString()}";
        }

        private void OnIncreaseStrStatButtonAvailable(bool value)
        {
            OnButtonEnabled(_increaseStrButton, value);
        }
        
        private void OnIncreaseDexStatButtonAvailable(bool value)
        {
            OnButtonEnabled(_increaseDexButton, value);
        }
        
        private void OnIncreaseIntStatButtonAvailable(bool value)
        {
            OnButtonEnabled(_increaseIntButton, value);
        }
        
        private void OnButtonEnabled(Button button, bool value)
        {
            button.enabled = value;
            button.image.sprite = value ? _avaliableButtonSprite : _notAvailableButtonSprite;
        }
    }
}