using System;
using System.Collections.Generic;
using System.Linq;

namespace NumSet
{
    public class NumSet
    {
        private HashSet<int>? _set;

        public HashSet<int> Set{
            get => _set!;
            private set => _set = value?? throw new ArgumentNullException();
        }

        public NumSet(params int[] array)
        {
            _set = new HashSet<int>(array?? throw new ArgumentNullException(nameof(array)));
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            int[] setArray = Set.ToArray();

            for(int i = 0; i < setArray.Length; i++)
            {
               hashCode += setArray[i].GetHashCode();
            }
            return hashCode*7;
        }

        public override bool Equals(Object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is not NumSet numSet)
            {
                return false;
            }
            return this.Set.IsSubsetOf(numSet.Set) && numSet.Set.IsSubsetOf(this.Set);
        }

        public static bool operator ==(NumSet first, NumSet second)
        {
            if (first is null && second is null) return true;
            if (first is null ^ second is null) return false;
            return first!.Equals(second);
        }

        public static bool operator !=(NumSet first, NumSet second)
            => !(first == second);

        public static NumSet operator +(NumSet first, NumSet second)
        {
            first.Set.UnionWith(second.Set);
            return first;
        }

        public static NumSet operator -(NumSet first, NumSet second)
        {
            foreach (int element in second.Set)
            {
                first.Set.Remove(element);
            }

            return first;
        }

        public static implicit operator int[](NumSet numSet) // cast into int[]
        {
            if (numSet is null) 
            {
                throw new ArgumentNullException(nameof(numSet));
            }
            return numSet.Set.ToArray();
        }

        public override string ToString()
        {
            int[] numSetArray = Set.ToArray();
            string numSetString = "{";
            for(int i = 0; i < numSetArray.Length; i++)
            {
                numSetString += numSetArray[i];
                
                if(i != numSetArray.Length-1)
                    numSetString += ", ";
            }
            numSetString += "}";

            return numSetString;
        }
    }
}
