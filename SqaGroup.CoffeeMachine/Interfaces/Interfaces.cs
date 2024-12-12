namespace SqaGroup.CoffeeMachine.Interfaces;

public interface ICoffeeMachine
{
    public IBrewingUnit BrewingUnit { get; }
}

public interface ICoffeeMachineOption
{
    public bool IsCoffeeMachineOption => true;
}

//other possibility: have an abstract CoffeeMachineOption class that concrete
//classes can inherit from, but that feels like overkill. Maybe if we have
//certain behaviors that all CoffeeMachineOptions _must_ implement -
//diagnostics, perhaps? A SelfTest function that returns status codes?
//Out of scope for now.
public interface IBrewingUnit: ICoffeeMachineOption
{
    public void Brew();
}
public interface IGrinder: ICoffeeMachineOption
{
    public void Grind();
}

