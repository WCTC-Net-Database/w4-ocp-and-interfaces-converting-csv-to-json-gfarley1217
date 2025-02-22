using System.Text.Json.Serialization;

namespace W4_assignment_template.Models;

public class Character
{
    public string Name { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public List<string> Equipment { get; set; }

    public Character(string name, string @class, int level, int hp, List<string> equipment)
    {
        Name = name;
        Class = @class;
        Level = level;
        HP = hp;
        Equipment = equipment;
    }

    [JsonConstructor]
    public Character(string name, string @class, int level, int hp)
    {
        Name = name;
        Class = @class;
        Level = level;
        HP = hp;
        Equipment = new List<string>();
    }



}

// Copilot and intellisense helped to write code above

