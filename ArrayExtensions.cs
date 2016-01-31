using System;
using System.Threading.Tasks;

namespace Camila {

    public static class ArrayExtensions {
  
        public static T[] Flatten<T> ( this Array Array ) {
            if ( !Array.GetType ().GetElementType ().Equals ( typeof ( T ) ) )
                throw new ArrayTypeMismatchException ();
            if ( Array.Rank == 1 )
                return (T[]) Array;
            T[] result = new T[Array.GetLengths ().Product ()];
            int[] lengths = Array.GetLengths ();
            Parallel.For ( 0, result.Length, i => result[i] = (T) Array.GetValue ( Utils.Array.GetIndices ( lengths, i ) ) );
            return result;
        }
        
        public static Array Restore<T> ( this T[] FlatArray, int[] Lengths ) {
            Array result = Array.CreateInstance ( typeof ( T ), Lengths );
            Parallel.For ( 0, FlatArray.Length, i => result.SetValue ( FlatArray[i], ArrayUtils.GetIndices ( Lengths, i ) ) );
            return result;
        }
        
        public static int[] GetLengths ( this Array Array ) {
            int[] result = new int[Array.Rank];
            Parallel.For ( 0, Array.Rank, i => result[i] = Array.GetLength ( i ) );
            return result;
        }
    
    }
  
}
