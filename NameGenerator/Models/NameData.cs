using System.Collections.Generic;

namespace NameGenerator.Models
{
    public class NameData
    {
        public List<TableName> MaleNames { get; set; }
        public List<TableName> FemaleNames { get; set; }
        public List<TableName> MaleLastNames { get; set; }
        public List<TableName> FemaleLastNames { get; set; }
    }
}

