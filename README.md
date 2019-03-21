# EBasket !(https://travis-ci.org/frankely/EBasket.svg?branch=master)
.NET Core Project built using clean architecture, domain driven design and test driven development.



## Testing

The following project follows Test Driven Development and relies on xUnit and AutoFixture.

### What is TDD?

> "All code is guilty until proven innocent" - Someone who writes Unit Tests

![testpyramid](https://martinfowler.com/bliki/images/testPyramid/test-pyramid.png)

*source: martinfowler.com*

TDD is an innovative software development approach where tests are written, before writing the bare minimum of code required for the test to be fulfilled. The code will then be refactored, as often as necessary, in order to pass the test, with the process being repeated for each piece of functionality. The below illustration shows how it works. To summarize, write minimal code and refactor continuously in order to satisfy the test.

*source: https://blog.testlodge.com/what-is-tdd/*

#### Structure

##### Arrange (Given)

All necessary preconditions and inputs.

##### Act (When)

On the object or method under test.

##### Assert (Then)

That the expected results have occurred.

#### Lifecycle

##### Red 

In the red phase, you have to write a test on a behavior that you are about to implement.

##### Green 

This is usually the easiest phase, because in this phase you write (production) code. 

##### Refactor

In the refactor phase, you are allowed to change the code, while keeping all tests green, so that it becomes better.

### How to write a basic test

Let's say that you are working in the shopping car feature of an e-commerce site, and now you need to be able to add items to a cart.

#### Model

Having an initial model along these lines:

```csharp
public class Cart
{
    public Guid Id { get; }
    public IEnumerable<Item> Items { get; }

    public Cart()
    {

    }

    public void AddItem(Item item)
    {

    }
}
public class Item
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
```

#### Red

```csharp
[Fact]  /*given    when             then*/
public void Given_Item_Is_Added_To_Cart_It_Should_Be_Added_To_Items()
{
    var item = new Item();
    var sut = new Cart(); //arrange

    sut.AddItem(item); //act

    Assert.NotEmpty(sut.Items); //assert
}
```

*This is a failing test* (red)

#### Green

After adding production code (implementation code), now our **Cart** implements the **AddItem** feature allowing the test to pass.

```csharp
public class Cart
{
    private readonly List<Item> _items = new List<Item>();

    public IEnumerable<Item> Items => _items.ToList(); // this will make the previous assertion pass

    public void AddItem(Item item)
    {
    	_items.Add(item); // this will make the previous assertion pass
    }
}
```

*This is a passing test (green)*

#### Refactor

Refactoring would be the phase where improvements are added without breaking the integrity of the implementation because the feature AddItem is covered.



### Adding AutoFixture

AutoFixture is an open source library for .NET designed to minimize the 'Arrange' phase of your unit tests in order to maximize maintainability. Its primary goal is to allow developers to focus on what is being tested rather than how to setup the test scenario, by making it easier to create object graphs containing test data.

*source: https://github.com/AutoFixture/AutoFixture*

With AutoFixture we will reduce the amount of code needed to arrange our test. 

```csharp
[Fact]  /*given    when             then*/
public void Given_Item_Is_Added_To_Cart_It_Should_Be_Added_To_Items()
{
    var item = new Item();
    var sut = new Cart(); //arrange

    sut.AddItem(item); //act

    Assert.NotEmpty(sut.Items); //assert
}
```

The previous test is creating an instance of Item to provide it to the **AddItem** method. However, what values are in the Item's properties are not relevant for this use case and could be auto-generated for us using AutoFixture.

```csharp
[Theory] //Since we are passing parameters xUnit requires this instead of Fact
[AutoData] //this will tell xunit to create instances of the parameters pass to the test 
public void Given_Item_Is_Added_To_Cart_It_Should_Be_Added_To_Items(Item item/* this is being auto-generated at runtime by AutoFixture*/)
{
    var sut = new Cart();

    sut.AddItem(item);

    Assert.NotEmpty(sut.Items);
}
```

*AutoFixture and AutoFixture.xUnit2 NugGet packages must be installed*
