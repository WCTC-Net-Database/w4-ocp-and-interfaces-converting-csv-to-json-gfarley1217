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
            var jsonString = File.ReadAllText(filePath);
            var characters = JsonSerializer.Deserialize<List<Character>>(jsonString);
            return characters ?? new List<Character>(); // This line taught me about the null-coalescing operator which I had been unaware of
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