using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace TestTHC
{
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _parent;
        [SerializeField] private Texture _removedImage;

         private int _blocksCount;
         private int _blocksScore;

         private const float _scaleValue = 1f;

         public UnityAction<int> OnBlockMined;

        private BlockFactory _factory;

        [Inject]
        private void Construct(BlockFactory factory)
        {
            _factory = factory;
        }

        private void Start()
        {
            CreateChunk();
        }

        private void CreateChunk()
        {
            for (int i = 0; i < 9; i++)
            {
                var enemyPrefab = _factory.GetBlockPrefab();
                var go = GameObject.Instantiate(enemyPrefab);
                go.Init(this);
                go.transform.parent = _parent.transform;
                go.transform.localScale = new Vector3(_scaleValue,_scaleValue,_scaleValue);
            }
        }

        private void ReleaseChunk()
        {
            foreach (Transform child in _parent.transform)
            {
                Destroy(child.gameObject);
            }
        }
        public void DestroyBlock(Block block, int blockScore)
        {
            _blocksScore += blockScore;
            _blocksCount++;
            OnBlockMined?.Invoke(_blocksScore);
            block.transform.GetComponent<RawImage>().texture = _removedImage;
            //Обнуление очков
            if (_blocksCount % 9 == 0)
            {
                ReleaseChunk();
                CreateChunk();
                _blocksCount = 0;
            }
        }
        
    }
}