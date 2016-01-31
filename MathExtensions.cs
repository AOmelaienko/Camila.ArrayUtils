using System.Collections.Generic;
using System.Linq;

namespace Camila {
    
    public static class MathExtensions {
        
        public static int Product ( this IEnumerable<int> Enumeration ) {
            return Enumeration.Aggregate ( 1, ( seed, element ) => seed * element );
        }
        
    }
    
}
