using SqaGroup.CoffeeMachine.Interfaces;

namespace SqaGroup.CoffeeMachine.Domain;

public class CoffeeMachine: ICoffeeMachine
{
    private IBrewingUnit _brewingUnit;
    private IGrinder? _grinder;

    public CoffeeMachine()
    {
        //every CoffeeMachine must have a valid BrewingUnit
        _brewingUnit = new BrewingUnit();
    }

    //call the default constructor so that we always have a basic BrewingUnit
    //initialized
    public CoffeeMachine(ICoffeeMachineOption[] options) : this()
    {
        /*
         * TODO: lots of behavior TBD here: do we throw an exception if we have a
         *  previously unknown ICoffeeMachineOption type, are our option
         *  initializations FIFO or LIFO or do we throw an exception if we have
         *  a duplicate Type in options, do we limit the size of options, must we
         *  have at least one option, etc.
         *  Other undefined/unclear issues: do we want the Options exposed as
         *  properties, or do we just want certain methods and properties of the
         *  Options exposed? Should there be a Brew() method on the CoffeeMachine
         *  that calls a hidden BrewingUnit.Brew() method?
         */
        //assume that we must have at least one option
        if (options == null || options.Length == 0)
        {
            throw new ArgumentNullException(nameof(options));
        }
        //mandatory options: do not replace the BrewingUnit with a null value
        var possibleBrewingUnit = options.FirstOrDefault(o => o is IBrewingUnit) as IBrewingUnit;
        if (possibleBrewingUnit != null)
        {
            _brewingUnit = possibleBrewingUnit;
        }

        //for now, get the first value in the collection that's the right type
        _grinder = options.FirstOrDefault(o => o is IGrinder) as IGrinder;
    }
    
    //TODO: do we want properties to be settable?
    public IBrewingUnit BrewingUnit => _brewingUnit;
    public IGrinder? Grinder => _grinder;
}