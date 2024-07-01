using UnityEngine;

namespace TestTHC
{
    [CreateAssetMenu(fileName = "IronPickaxeConfig", menuName = "TestTHC/Iron", order = 1)]
    public class IronPickaxeConfig : ScriptableObject
    {
        [SerializeField] private int _minDamage;
        [SerializeField] private int _maxDamage;

        public int MinDamage => _minDamage;
        public int MaxDamage => _maxDamage;
    }
}