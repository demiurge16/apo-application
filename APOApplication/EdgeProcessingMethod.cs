using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOApplication
{
    public enum EdgeProcessingMethod : byte
    {
        DuplicateEdges,
        UseExistingPixels,
        IgnoreEdges
    }
}
