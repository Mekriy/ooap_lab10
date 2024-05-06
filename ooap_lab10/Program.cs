public class DarkForestGame
{
    private IGameStrategy _gameStrategy;
    private List<Character> _characters;

    public DarkForestGame(IGameStrategy gameStrategy, List<Character> characters)
    {
        _gameStrategy = gameStrategy;
        _characters = characters;
    }

    public DarkForestGame(List<Character> characters)
    {
        _characters = characters;
    }

    public void SetStrategy(IGameStrategy strategy)
    {
        _gameStrategy = strategy;
    }

    public void DoChallenges()
    {
        Console.WriteLine(_gameStrategy.StartChallenge(_characters));
    }
}

public class Character
{
    public string Name { get; set; }
    public string MagicArtefacts { get; set; }

    public Character(string name, string magicArtefacts)
    {
        Name = name;
        MagicArtefacts = magicArtefacts;
    }
}
public interface IGameStrategy
{
    string StartChallenge(List<Character> characters);
}

public class ScenarioOne : IGameStrategy
{
    public string StartChallenge(List<Character> characters)
    {
        Console.WriteLine("Scenario one has Forest and Mountain challenge");
        foreach (var character in characters)
        {
            if (character.MagicArtefacts == "Forest + Mountain")
            {
                return $"{character.Name} passed challenge with this artefacts: {character.MagicArtefacts}";
            }
        }
        return "No one passed challenge";
    }
}
public class ScenarioTwo : IGameStrategy
{
    public string StartChallenge(List<Character> characters)
    {
        Console.WriteLine("Scenario two has Water and Mountain challenge");
        foreach (var character in characters)
        {
            if (character.MagicArtefacts == "Water + Mountain")
            {
                return $"{character.Name} passed challenge with this artefacts: {character.MagicArtefacts}";
            }
        }
        return "No one passed challenge";
    }
}
public class ScenarioThree : IGameStrategy
{
    public string StartChallenge(List<Character> characters)
    {
        Console.WriteLine("Scenario three has Water and Forest challenge");
        foreach (var character in characters)
        {
            if (character.MagicArtefacts == "Water + Forest")
            {
                return $"{character.Name} passed challenge with this artefacts: {character.MagicArtefacts}";
            }
        }
        return "No one passed challenge";
    }
}
public class ScenarioFour : IGameStrategy
{
    public string StartChallenge(List<Character> characters)
    {
        Console.WriteLine("Scenario four has Forest challenge");
        foreach (var character in characters)
        {
            if (character.MagicArtefacts.Contains("Forest"))
            {
                return $"{character.Name} passed challenge with this artefacts: {character.MagicArtefacts}";
            }
        }
        return "No one passed challenge";
    }
}
internal static class Program
{
    private static void Main()
    {
        List <Character> characters =
        [
            new Character("Gandalf","Water + Mountain"),
            new Character("Frieren","Forest + Mountain"),
            new Character("Fern","Water + Forest")
        ];
        DarkForestGame game = new DarkForestGame(characters);
        game.SetStrategy(new ScenarioOne());
        game.DoChallenges();

        game.SetStrategy(new ScenarioTwo());
        game.DoChallenges();

        game.SetStrategy(new ScenarioThree());
        game.DoChallenges();

        game.SetStrategy(new ScenarioFour());
        game.DoChallenges();
    }
}