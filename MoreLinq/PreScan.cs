﻿#region License and Terms
//
// MoreLINQ - Extensions to LINQ to Objects
// Copyright (c) 2008-9 Jonathan Skeet. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System;
using System.Collections.Generic;

namespace MoreLinq
{
    public static partial class MoreEnumerable
    {
        /// <summary>
        /// Performs a pre-scan (exclusive prefix sum) on a sequence of elements.
        /// </summary>
        /// <remarks>
        /// An exclusive prefix sum returns an equal-length sequence where the
        /// N-th element is the sum of the first N-1 input elements (the first
        /// element is a special case, it is set to the identity). More
        /// generally, the pre-scan allows any commutative binary operation,
        /// not just a sum.
        /// </remarks>
        /// <typeparam name="TSource">Type of elements in source sequence</typeparam>
        /// <param name="source">Source sequence</param>
        /// <param name="transformation">Transformation operation</param>
        /// <param name="identity">Identity element (see remarks)</param>
        /// <returns>The scanned sequence</returns>
        
        public static IEnumerable<TSource> PreScan<TSource>(this IEnumerable<TSource> source,
            Func<TSource, TSource, TSource> transformation, TSource identity)
        {
            source.ThrowIfNull("source");
            transformation.ThrowIfNull("transformation");
            return PreScanImpl(source, transformation, identity);
        }

        private static IEnumerable<T> PreScanImpl<T>(IEnumerable<T> source, Func<T, T, T> f, T id)
        {
            var aggregator = id;

            foreach (var i in source)
            {
                yield return aggregator;
                aggregator = f(aggregator, i);
            }
        }
    }
}
