using UnityEngine;

namespace TestTHC
{
    public class SingleBlockFactory : BlockFactory
    {
        [SerializeField] private Block _block;
        
        public override Block GetBlockPrefab()
        {
            return _block;
        }
    }
}