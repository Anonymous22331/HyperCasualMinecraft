using UnityEngine;

namespace TestTHC
{
    [CreateAssetMenu(fileName = "DiamondPickaxeConfig", menuName = "TestTHC/Diamond", order = 1)]
    public class DiamondPickaxeConfig : ScriptableObject
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _critChance;
        [SerializeField] private int _critDamageModifier;

        public int Damage => _damage;
        public float CritChance => _critChance;
        public int CritDamageModifier => _critDamageModifier;
    }
}