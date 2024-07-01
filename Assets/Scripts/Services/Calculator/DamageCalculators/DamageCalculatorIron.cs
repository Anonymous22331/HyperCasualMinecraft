using UnityEngine;

namespace TestTHC
{
    public class DamageCalculatorIron : IDamageCalculator
    {
        private readonly IronPickaxeConfig _tool;

        public DamageCalculatorIron(IronPickaxeConfig tool)
        {
            _tool = tool;
        }

        public int CalculateDamage()
        {
            return Random.Range(_tool.MinDamage, _tool.MaxDamage);
        }
    
        public CalculatorType GetCalculatorType()
        {
            return CalculatorType.Iron;
        }
    }
}