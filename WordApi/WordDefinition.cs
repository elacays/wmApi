using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordApi
{
    public class WordDefinition
    {
        public int Id { get; set; }
        public string WordDef { get; set; }
        public int LngId { get; set; }

        public IEnumerable<WordMeaning> Meanings { get; set; }
    }

    public class WordMeaning
    {
        public int Id { get; set; }
        public string Meaning { get; set; }
        public int LngId { get; set; }

        public int WordDefinitionId { get; set; }

        [ForeignKey("WordDefinitionId")]
        [JsonIgnore]
        public WordDefinition WordDef { get; set; }

       
    }
}
