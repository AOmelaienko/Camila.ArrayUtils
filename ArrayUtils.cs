using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Camila {
  public static class ArrayUtils {
    public static int[] GetIndices ( int[] Lengths, int FlatIndex ) {
      int[] result = new int[Lengths.Length];
      Parallel.For ( 0, result.Length, i => result[i] = ( FlatIndex / Lengths.Take ( i ).Product () ) % Lengths[i] );
      return result;
    }
    public static int GetIndex ( int[] Lengths, int[] RankedIndices ) {
      if ( RankedIndices.Length > Lengths.Length )
        throw new IndexOutOfRangeException ();
      int result = 0;
      Parallel.For ( 0, RankedIndices.Length, i => Interlocked.Add ( ref result, RankedIndices[i] * Lengths.Take ( i ).Product () ) );
      return (int) result;
    }
  }
}
