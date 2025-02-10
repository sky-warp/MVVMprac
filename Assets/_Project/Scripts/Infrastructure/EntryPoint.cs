using _Project.Scripts.CharacterStats.Model;
using _Project.Scripts.CharacterStats.View;
using _Project.Scripts.CharacterStats.ViewModel;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private StatsView _view;

        private void Start()
        {
            StatsModel model = new(15, 15, 15, 5);
            StatsViewModel viewModel = new(model);
            _view.Init(viewModel);
        }
    }
}