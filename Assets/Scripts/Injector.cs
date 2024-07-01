using System;
using TestTHC;
using UnityEngine;
using Zenject;

public class Injector : MonoInstaller
{
    
    [Header("Tool Data")]
    [SerializeField] private CalculatorType _calculatorType;
    [SerializeField] private IronPickaxeConfig _ironPickaxeConfig;
    [SerializeField] private DiamondPickaxeConfig _diamondPickaxeConfig;
   
    [Header("Block Spawn Data")] [SerializeField]
    private BlockSpawner _spawner;
    [SerializeField] private BlockFactoryType _blockFactoryType;
   
    [SerializeField] private SingleBlockFactory _singleBlockFactory;
    [SerializeField] private RandomBlockFactory _randomBlockFactory;

    [SerializeField] private InputType _inputType;

    public override void InstallBindings()
    {
        
        var calculator = SelectCalculator(_calculatorType);
        Container.Bind<IDamageCalculator>().FromInstance(calculator);

        var factory = SelectBlockFactory(_blockFactoryType);
        Container.Bind<BlockFactory>().FromInstance(factory);

        Container.Bind<BlockSpawner>().FromInstance(_spawner);

        var inputHandler = SelectInputHandler(_inputType);
        Container.Bind<InputHandler>().FromInstance(inputHandler);
        
    }
    
    private IDamageCalculator SelectCalculator(CalculatorType calculatorType)
    {
        switch (calculatorType)
        {
            case CalculatorType.Iron:
                return new DamageCalculatorIron(_ironPickaxeConfig);
            case CalculatorType.Diamond:
                return new DamageCalculatorDiamond(_diamondPickaxeConfig);
            default:
                return new DamageCalculatorIron(_ironPickaxeConfig);
        }
    }

    private BlockFactory SelectBlockFactory(BlockFactoryType blockFactoryType)
    {
        switch (blockFactoryType)
        {
            case BlockFactoryType.Single:
                return _singleBlockFactory;
            case BlockFactoryType.Random:
                return _randomBlockFactory;
            default:
                throw new ArgumentOutOfRangeException(nameof(blockFactoryType), blockFactoryType, null);
        }
    }

    private InputHandler SelectInputHandler(InputType inputType)
    {
        switch (inputType)
        {
            case InputType.Mouse:
                return new MouseInputHandler();
            case InputType.Keyboard_Space:
                return new KeyboardInputHandler();
            default:
                throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null);
        }
    }
}