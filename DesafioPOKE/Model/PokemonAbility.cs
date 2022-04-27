
namespace DesafioPOKE.Model;

public class PokemonAbility
{
    public bool Is_Hidden { get; set; }
    public int Slot { get; set; }
    public Ability Ability { get; set; }
    public override string ToString()
    {
        return $"{ Ability.Name }";
    }

}

