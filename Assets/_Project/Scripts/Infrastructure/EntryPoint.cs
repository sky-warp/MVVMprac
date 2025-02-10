using _Project.Scripts.CharacterStats.View;
using _Project.Scripts.CharacterStats.ViewModel;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private StatsView _statsView;

        private void Start()
        {
            StatsDefaultModel model = new StatsDefaultModel(15, 15, 15, 5);
            StatsViewModel viewModel = new StatsViewModel(model);
            _statsView.Init(viewModel);
        }

        private void OnDestroy()
        {
        }
    }
}