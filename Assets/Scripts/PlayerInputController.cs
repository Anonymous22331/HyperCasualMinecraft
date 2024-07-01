using System;
using UnityEngine;
using Zenject;

namespace TestTHC
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private float _attackCooldown = 1.0f;
        private InputHandler _inputHandler;

        public event Action<Block> MineBlockRequest;
        private DateTime _previousAttackTime;

        [Inject]
        private void Init(InputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            _inputHandler.BlockClicked += OnBlockClickRequest;
        }

        private void OnBlockClickRequest(Block block)
        {
            if (_previousAttackTime.AddSeconds(_attackCooldown) < DateTime.Now)
            {
                _previousAttackTime = DateTime.Now;
                MineBlockRequest?.Invoke(block);
            }
        }

        private void Update()
        {
            _inputHandler.Handle();
        }
    }
}