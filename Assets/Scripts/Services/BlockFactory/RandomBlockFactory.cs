using System.Collections.Generic;
using UnityEngine;

namespace TestTHC
{
    public class RandomBlockFactory : BlockFactory
    {
        [SerializeField] private List<Block> _blocks;
        
        public override Block GetBlockPrefab()
        {
            var index = Random.Range(0, _blocks.Count);
            return _blocks[index];
        }
    }
}