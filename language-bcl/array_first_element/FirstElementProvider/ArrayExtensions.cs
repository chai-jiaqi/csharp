using System;
using System.Collections;

namespace FirstElementProvider
{
    static class ArrayExtensions
    {
        public static object First(this Array array)
        {
            #region Please implement the method
            
            /*
             * In this practice, we will write a simple method to get the first element of an
             * array. You cannot use any LINQ method in this test.
             *
             * Difficulty: Easy
             */
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            return First(array.GetEnumerator());

            #endregion
        }

        private static object First(IEnumerator enumerator)
        {
            enumerator.MoveNext();
            var enumeratorCurrent = enumerator.Current;

            if (enumeratorCurrent is Array array)
            {
                return First(array.GetEnumerator());
            }

            return enumeratorCurrent;
        }
    }
}