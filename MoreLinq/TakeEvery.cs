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

using System.Linq;
using System.Collections.Generic;

namespace MoreLinq
{
    public static partial class MoreEnumerable
    {
        /// <summary>
        /// Returns every N-th element of a source sequence.
        /// </summary>
        /// <typeparam name="TSource">Type of the source sequence</typeparam>
        /// <param name="source">Source sequence</param>
        /// <param name="step">Steps in which to partition source</param>
        /// <remarks>
        /// This operator uses deferred execution and streams the results.
        /// </remarks>
        /// <example>
        /// <code>
        /// int[] numbers = { 1, 2, 3, 4, 5 };
        /// IEnumerable&lt;int&gt; result = numbers.Every(2);
        /// </code>
        /// The <c>result</c> variable, when iterated over, will yield 1, 3 and 5, in turn.
        /// </example>
        
        public static IEnumerable<TSource> TakeEvery<TSource>(this IEnumerable<TSource> source, int step)
        {
            source.ThrowIfNull("source");
            step.ThrowIfNonPositive("step");
            return source.Where((e, i) => i % step == 0);
        }
    }
}
