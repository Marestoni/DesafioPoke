namespace DesafioPOKE.Model;

public class PokemonType
{
    public int Slot { get; set; }
    public Type Type { get; set; }
    public override string ToString()
    {
        return $"{ Type.Name }";
    }
}

