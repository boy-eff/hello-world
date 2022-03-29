using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class Word
    {
        public Word(string value, string translation)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (string.IsNullOrWhiteSpace(translation))
            {
                throw new ArgumentNullException(nameof(translation));
            }

            Value = value;
            Translation = translation;
        }

        private Word()
        {
            
        }

        public int Id { get; private set; }
        public string? Value { get; private set; }
        public string? Translation { get; private set; }
    }
}