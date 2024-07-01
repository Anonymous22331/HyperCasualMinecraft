using UnityEngine;

namespace TestTHC
{
    public abstract class BlockFactory : MonoBehaviour
    {
        public abstract Block GetBlockPrefab();
    }
}