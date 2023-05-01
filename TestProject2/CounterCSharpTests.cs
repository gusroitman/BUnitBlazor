using BlazorApp1.Pages;
using Bunit;
using Xunit;

namespace BlazorTestOne;

/// <summary>
/// These tests are written entirely in C#.
/// Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
/// </summary>
public class CounterCSharpTests : TestContext
{
    [Fact]
    public void CounterRenderTitle()
    {
        using var ctx = new TestContext();

        // Act
        var component = ctx.RenderComponent<Counter>();

        // Assert que el h1 tag tenga la palabra Counter
        Assert.Equal("Counter", component.Find($"h1").TextContent);
    }

    [Fact]
    public void CounterStartsAtZero()
	{
        // Arrange
        var cut = RenderComponent<Counter>();

        // Assert que el contenido del parrafo muestre el contador en 0
        cut.Find("p").MarkupMatches("<p role = \"status\" >Current count: 0</p>");
    }

    [Fact]
    public void ClickingButtonIncrementsCounter()
    {
        // Arrange
        var cut = RenderComponent<Counter>();

        // Act - click button para incrementar el contador
        cut.Find("button").Click();

        // Assert que el contador fue incrementado
        cut.Find("p").MarkupMatches("<p role = \"status\" >Current count: 1</p>");
    }

    [Fact]
    public void CounterShouldIncrementWhenSelected()
    {
        // Arrange - usar using para dispose...
        using var ctx = new TestContext();
        var cut = ctx.RenderComponent<Counter>();
        var contador = cut.Find("p");

        // Act
        cut.Find("button").Click();     
        var contadorText = contador.TextContent;

        // Assert que haga match con el texto
        contadorText.MarkupMatches("Current count: 1");
    }

    [Fact]
    public void CounterRendersSuccessfully()
    {
        using var ctx = new TestContext();

        // Render el componente Counter.
        var component = ctx.RenderComponent<Counter>();

        // Assert: primero que encuentre el elemento padre, despues verificar el contenido que sea Click me.
        Assert.Equal("Click me", component.Find($".btn").TextContent);
    }

    [Fact]
    public void CountersWithParametersRendersSuccessfully()
    {
        using var ctx = new TestContext();

        var components = ctx.RenderComponent<Counter>();

        // Render el componente Counter (pasandole el parametro opcional DefaultCount en 10).
        var component = ctx.RenderComponent<Counter>(
          parameters =>
            parameters
              // Add parametros
              .Add(c => c.DefaultCount, 10)
        );

        // Assert: primero que encuentre el elemento padre, despues verificar el contenido.
        Assert.Equal("Click me", component.Find($".btn").TextContent);
    }

    [Fact]
    public void CounterButtonClickAndUpdatesCount()
    {
        // Arrange
        using var ctx = new TestContext();
        var component = ctx.RenderComponent<Counter>();

        // Act
        var counterValue = "0";
        Assert.Equal(counterValue, component.Find($"#counterVal").TextContent);

        counterValue = "1";
        var buttonElement = component.Find("button");

        buttonElement.Click();

        //Assert
        Assert.Equal(counterValue, component.Find($"#counterVal").TextContent);
    }
}