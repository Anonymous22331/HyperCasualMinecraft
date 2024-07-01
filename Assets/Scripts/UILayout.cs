using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestTHC
{
    public class UILayout : MonoBehaviour
    {
        [SerializeField] private Text _minedBlocksCount;
        [SerializeField] private GameObject IronPickaxe;
        [SerializeField] private GameObject DiamondPickaxe;

        [Inject]
        private void Construct(BlockSpawner spawner, IDamageCalculator calculator)
        {
            spawner.OnBlockMined += OnBlockMined;
            SetToolActive(calculator);
        }

        private void SetToolActive(IDamageCalculator calculator)
        {
            switch (calculator.GetCalculatorType())
            {
                case CalculatorType.Diamond:
                {
                    DiamondPickaxe.SetActive(true);
                    break;
                }
            case CalculatorType.Iron:
                {
                    IronPickaxe.SetActive(true);
                    break;
                }
            }
        }
        
        private void OnBlockMined(int count)
        {
            _minedBlocksCount.text = string.Format("Blocks dug count: {0}", count);
        }
        
    }
}