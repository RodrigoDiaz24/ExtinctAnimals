using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtinctAnimals.Infrastructure.Configuration
{
    public class ExtinctAnimalsApiOptions
    {
        public const string SectionName = "ExtinctAnimalsApi";

        public string BaseUrl { get; init; } = default!;
    }
}
