using NUnit.Framework;
using SqaGroup.CoffeeMachine.Domain;
using SqaGroup.CoffeeMachine.Interfaces;

namespace SqaGroup.CoffeeMachine.Tests.Domain;

[TestFixture]
[TestOf(typeof(CoffeeMachine.Domain.CoffeeMachine))]
public class CoffeeMachineTest
{
    //not the best way that I would structure a test suite, but
    //good enough for now

    private class NamedGrinder : Grinder
    {
        public NamedGrinder()
        {
        }

        public NamedGrinder(string name)
        {
         Name = name;   
        }
        public string Name { get; } = "Named Grinder";
    }

    private class NamedBrewingUnit : BrewingUnit
    {
        public NamedBrewingUnit()
        {
        }

        public NamedBrewingUnit(string name)
        {
            Name = name;
        }
        public string Name { get; } = "Named BrewingUnit";
    }

    [Test]
    public void ACoffeeMachine_ShouldAlwaysHaveABrewingUnit()
    {
        var machine = new CoffeeMachine.Domain.CoffeeMachine();
        Assert.That(machine.BrewingUnit, Is.Not.Null);
    }
    [Test]
    public void ACoffeeMachine_ShouldAlwaysHaveABrewingUnit2()
    {
        IBrewingUnit nullBrewingUnit  = null;
        var options = new ICoffeeMachineOption[] { nullBrewingUnit };
        var machine = new CoffeeMachine.Domain.CoffeeMachine(options);
        Assert.That(machine.BrewingUnit, Is.Not.Null);
    }

    [Test]
    public void ACoffeeMachine_CanHaveANamedBrewingUnit()
    {
        var namedBrewingUnit = new NamedBrewingUnit("Phred");
        var options = new ICoffeeMachineOption[] { namedBrewingUnit };
        var machine = new CoffeeMachine.Domain.CoffeeMachine(options);
        Assert.That((machine.BrewingUnit as NamedBrewingUnit).Name, Is.EqualTo("Phred"));
    }

    [Test]
    public void ACoffeeMachine_ShouldAlwaysHaveTheFirstGrinderPassedToTheConstructor()
    {
        var grinder1 = new NamedGrinder("Grinder1");
        var grinder2 = new NamedGrinder("Grinder2");
        var options = new ICoffeeMachineOption[] { grinder1, grinder2 };
        var machine = new CoffeeMachine.Domain.CoffeeMachine(options);
        Assert.That(machine.Grinder, Is.Not.Null);
        Assert.That((machine.Grinder as NamedGrinder).Name, Is.EqualTo("Grinder1"));
    }
}