using UnityEngine;

namespace TestTHC
{
    public class DamageCalculatorDiamond : IDamageCalculator
    {
        private readonly DiamondPickaxeConfig _tool;

        public DamageCalculatorDiamond(DiamondPickaxeConfig weapon)
        {
            _tool = weapon;
        }

        public int CalculateDamage()
        {
            var chanceThrow = Random.Range(0f, 1f);
            var critResult = chanceThrow < _tool.CritChance ? _tool.CritDamageModifier : 1;
            return _tool.Damage * critResult;
        }

        public CalculatorType GetCalculatorType()
        {
            return CalculatorType.Diamond;
        }
    }
}