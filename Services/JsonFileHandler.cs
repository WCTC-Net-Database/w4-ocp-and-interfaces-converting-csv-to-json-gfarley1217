using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using W4_assignment_template.Interfaces;
using W4_assignment_template.Models;

namespace W4_assignment_template.Services
{
    public class JsonFileHandler : IFileHandler
    {
        public List<Character> ReadCharacters(string filePath)
        {
            var json = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<Character>>(json);
        }

        public void WriteCharacters(string filePath, List<Character> characters)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(characters, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}

// Copilot assisted in code above