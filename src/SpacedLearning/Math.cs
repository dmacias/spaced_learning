using System;
using System.Collections.Generic;
using System.Linq;

namespace Math{
    public static class AlgebraicProperties {

        ///<param name="pairs">Assumes a bipartite graph's edge list.  This implies the graph is left-total and surjective.</param>
        public static bool IsInjective<T>(IEnumerable<Tuple<T,T>> pairs){
            pairs = pairs.Distinct().ToList();  //removes multi-edges from edge pairs
            var ys = pairs.Select(x => x.Item2).ToList();
            var uniqueYs = ys.Distinct().ToList();
            return ys.Count == uniqueYs.Count;
        }

        ///<param name="pairs">Assumes a bipartite graph's edge list.  This implies the graph is left-total and surjective.</param>
        public static bool IsFunctional<T>(IEnumerable<Tuple<T,T>> pairs){
            pairs = pairs.Distinct().ToList();  //removes multi-edges from edge pairs
            var xs = pairs.Select(x => x.Item1).ToList();
            var uniqueXs = xs.Distinct().ToList();
            return xs.Count == uniqueXs.Count;
        }
    }
}