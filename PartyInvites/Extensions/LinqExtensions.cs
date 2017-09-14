﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Extensions
{
    public static class LinqExtensions
    {
	    public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	    {
		    return !source.Any(predicate);
	    }
    }
}
