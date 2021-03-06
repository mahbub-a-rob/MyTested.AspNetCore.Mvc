﻿namespace MyTested.AspNetCore.Mvc.Internal.TestContexts
{
    using Contracts;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.DependencyInjection;
    using Utilities.Extensions;

    public static class HttpTestContextCachingExtensions
    {
        public static IMemoryCache GetMemoryCache(this HttpTestContext testContext)
            => testContext.HttpContext.RequestServices.GetRequiredService<IMemoryCache>();

        internal static IMemoryCacheMock GetMemoryCacheMock(this HttpTestContext testContext)
            => testContext.GetMemoryCache().AsMemoryCacheMock();
    }
}
