using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TestTHC
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private float _health;
        [SerializeField] private float _duration;
        [SerializeField] private float _magnitude;
        [SerializeField] private int _blockScore;

        private bool _scoreCounted = false;
        private BlockSpawner _spawner;
    
        public void Init(BlockSpawner spawner)
        {
            _spawner = spawner;
        }
        
        public void RemoveHealth(float damageValue)
        {
            _health -= damageValue;
            _health = Mathf.Max(0, _health);

            if (_health <= 0 && !_scoreCounted)
            {
                _spawner.DestroyBlock(this, _blockScore);
                _scoreCounted = true;
            }
            else
            {
                StartCoroutine(Shake());
            }
        }

        private IEnumerator Shake()
        {
            Quaternion originalRotation = transform.localRotation;
            float elapsed = 0.0f;

            while (elapsed < _duration)
            {
                float z = Random.Range(-1f, 1f) * _magnitude;

                transform.localRotation = originalRotation * Quaternion.Euler(0, 0, z);

                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localRotation = originalRotation;
        }
    }
}