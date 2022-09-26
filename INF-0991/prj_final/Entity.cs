/// <summary>
///  This is an abstract class called entity used to help to generate itens in the map
/// </summary>
public abstract class Entity {

    private string Symbol;

    public Entity(string Symbol)
    {
        this.Symbol = Symbol;
    }

    public sealed override string ToString()
    {
        return Symbol;
    }

}

