﻿using System;
using JetBrains.Annotations;

namespace CreativeCoders.Core
{
    public static class ThrowExtensions
    {
        [ContractAnnotation("halt <= self: null")]
        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Global
        public static void ThrowIfNull(this object self, Func<Exception> createException)
        {
            if (self == null)
            {
                throw createException();
            }
        }
    }
}