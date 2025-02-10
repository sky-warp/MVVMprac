using _Project.Scripts.CharacterStats.ViewModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.CharacterStats.View
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private Button _increaseStrStatsButton;
        [SerializeField] private Button _increaseDexStatsButton;
        [SerializeField] private Button _increaseIntStatsButton;

        [SerializeField] private Button _resetStatsButton;
        [SerializeField] private Button _applyStatsButton;

        [SerializeField] private TextMeshProUGUI _strValueText;
        [SerializeField] private TextMeshProUGUI _dexValueText;
        [SerializeField] private TextMeshProUGUI _intValueText;
        [SerializeField] private TextMeshProUGUI _avaliableSkillPointsValueText;

        [SerializeField] private Sprite _availableButtonSprite;
        [SerializeField] private Sprite _disableButtonSprite;

        private StatsViewModel _viewModel;

        public void Init(StatsViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.StrView.OnValueChanged += RedrawStrValue;
            _viewModel.DexView.OnValueChanged += RedrawDexValue;
            _viewModel.IntView.OnValueChanged += RedrawIntValue;

            _viewModel.SkillsPointAvailableView.OnValueChanged += RedrawAvailableSkillPoints;
            
            _viewModel.StrButtonEnabled.OnValueChanged += OnStrButtonEnabled;
            _viewModel.DexButtonEnabled.OnValueChanged += OnDexButtonEnabled;
            _viewModel.IntButtonEnabled.OnValueChanged += OnIntButtonEnabled;
            
            _increaseStrStatsButton.onClick.AddListener(_viewModel.OnIncreaseStrButtonClicked);
            _increaseDexStatsButton.onClick.AddListener(_viewModel.OnIncreaseDexButtonClicked);
            _increaseIntStatsButton.onClick.AddListener(_viewModel.OnIncreaseIntButtonClicked);

            _applyStatsButton.onClick.AddListener(_viewModel.OnApplyButtonClicked);
            _resetStatsButton.onClick.AddListener(_viewModel.OnResetButtonClicked);

            _strValueText.text = _viewModel.StrView.Value.ToString();
            _dexValueText.text = _viewModel.DexView.Value.ToString();
            _intValueText.text = _viewModel.IntView.Value.ToString();
        }

        private void OnDestroy()
        {
            Dispose();
        }
        
        private void Dispose()
        {
            _viewModel.StrView.OnValueChanged -= RedrawStrValue;
            _viewModel.DexView.OnValueChanged -= RedrawDexValue;
            _viewModel.IntView.OnValueChanged -= RedrawIntValue;

            _viewModel.SkillsPointAvailableView.OnValueChanged -= RedrawAvailableSkillPoints;

            _viewModel.StrButtonEnabled.OnValueChanged -= OnStrButtonEnabled;
            _viewModel.DexButtonEnabled.OnValueChanged -= OnDexButtonEnabled;
            _viewModel.IntButtonEnabled.OnValueChanged -= OnIntButtonEnabled;

            _increaseStrStatsButton.onClick.RemoveListener(_viewModel.OnIncreaseStrButtonClicked);
            _increaseDexStatsButton.onClick.RemoveListener(_viewModel.OnIncreaseDexButtonClicked);
            _increaseIntStatsButton.onClick.RemoveListener(_viewModel.OnIncreaseIntButtonClicked);

            _applyStatsButton.onClick.RemoveListener(_viewModel.OnApplyButtonClicked);
            _resetStatsButton.onClick.RemoveListener(_viewModel.OnResetButtonClicked);
        }

        private void ButtonEnabled(Button btn, bool isEnabled)
        {
            btn.enabled = isEnabled;
            btn.image.sprite = isEnabled ? _availableButtonSprite : _disableButtonSprite;
        }

        private void OnStrButtonEnabled(bool obj)
        {
            ButtonEnabled(_increaseStrStatsButton, obj);
        }

        private void OnDexButtonEnabled(bool obj)
        {
            ButtonEnabled(_increaseDexStatsButton, obj);
        }

        private void OnIntButtonEnabled(bool obj)
        {
            ButtonEnabled(_increaseIntStatsButton, obj);
        }

        private void RedrawAvailableSkillPoints(int obj)
        {
            _avaliableSkillPointsValueText.text = $"Available points: {obj.ToString()}";
        }

        private void RedrawIntValue(int obj)
        {
            _intValueText.text = obj.ToString();
        }

        private void RedrawDexValue(int obj)
        {
            _dexValueText.text = obj.ToString();
        }

        private void RedrawStrValue(int obj)
        {
            _strValueText.text = obj.ToString();
        }
    }
}