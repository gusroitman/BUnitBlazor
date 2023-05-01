using BlazorApp1.Pages;
using Bunit;

namespace BlazorTestOne;

public class ConversorCSharpTests : TestContext
{
    [Fact]
    public void ConversorRenderTitle()
    {
        // Arrange - usar using para dispose...
        using var ctx = new TestContext();

        // Act
        var component = ctx.RenderComponent<Conversor>();

        // Assert que el h2 tag tenga la palabra Conversor de Moneda
        Assert.Equal("Conversor de Moneda", component.Find($"h2").TextContent);
    }

    [Fact]
    public void ConversorInputsChangedToNewValue()
    {
        // Arrange - usar using para dispose...
        using var ctx = new TestContext();
        int expectedFirstInput = 100;
        double expectedSecondInput = 5.3;
        var component = ctx.RenderComponent<Conversor>();

        // Act - Buscamos y cambiamos el valor del input text
        // Buscamos el selector de css cambio donde tengamos el input y lo cambio al valor 100 que es el expected
        component.Find(cssSelector: "#cambio input").Change(expectedFirstInput.ToString());

        // Simulamos que le damos click al botón y hacemos la conversión de moneda con el nuevo valor
        component.Find(cssSelector: "button").Click();

        // Buscamos nuevamente el input dentro de nuestro div css cambio 
        var label = component.FindAll("#cambio input");

        // Asignamos el valor del primer elemento con el nuevo atributo value a una variable
        var result = label[0].Attributes.GetNamedItem("value")?.Value.ToString();

        // Repetimos el procedimiento de buscar con el segundo input
        // Buscamos el input dentro de nuestro div css cambiodolar del segundo input
        var label2 = component.FindAll("#cambiodolar input");

        // Asignamos el valor del primer elemento con el nuevo atributo value a una variable
        var result2 = label2[0].Attributes.GetNamedItem("value")?.Value.ToString();

        // Assert 
        // Comparamos que "100" sea el value del texto del primer input 
        Assert.Equal(expectedFirstInput.ToString(), result);

        // Comparamos que "5.3" sea el value del texto del segundo input 
        Assert.Equal(expectedSecondInput.ToString(), result2);
    }

}
