using UnityEngine;
using Zenject;

namespace TestTHC
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInputController _playerInputController;
        
        [Inject]
        private IDamageCalculator _damageCalculator;

        private void Awake()
        {
             _playerInputController.MineBlockRequest += OnBlockClickRequest;
        }
        
        private void OnBlockClickRequest(Block block)
        {
            Mine(block);
        }

        private void Mine(Block block)
        {
            float damage = _damageCalculator.CalculateDamage();
            block.RemoveHealth(damage);
        }
    }
}