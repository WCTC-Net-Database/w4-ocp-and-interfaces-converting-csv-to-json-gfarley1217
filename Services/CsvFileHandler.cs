using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using W4_assignment_template.Interfaces;
using W4_assignment_template.Models;

namespace W4_assignment_template.Services
{
    public class CsvFileHandler : IFileHandler
    {
        public List<Character> ReadCharacters(string filePath)
        {
            var characters = new List<Character>();
            var lines = File.ReadAllLines(filePath);

            using (var reader = new StreamReader(filePath))
            {
                // Skip the header line
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    var character = new Character
                    {
                        Name = values[0],
                        Class = values[1],
                        Level = int.Parse(values[2]),
                        HP = int.Parse(values[3]),
                        Equipment = values[4].Split(';').ToList()
                    };

                    characters.Add(character);
                }
            }

            return characters;
        }

        public void WriteCharacters(string filePath, List<Character> characters)
        {
            using (var writer = new StreamWriter(filePath))
            {
                // Write the header line
                writer.WriteLine("Name,Class,Level,HP,Equipment");

                foreach (var character in characters)
                {
                    var equipment = string.Join(";", character.Equipment);
                    var line = $"{character.Name},{character.Class},{character.Level},{character.HP},{equipment}";
                    writer.WriteLine(line);
                }
            }
        }
    }
}

// Copilot and intellisense helped to write code above