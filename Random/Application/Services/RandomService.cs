// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using Depra.Random.Domain.Exceptions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.Services
{
    /// <inheritdoc cref="IRandomService" />
    public sealed class RandomService : IRandomService, IDisposable
    {
        private readonly IDictionary<Type, IRandomizer> _randomizers;
        private bool _disposed;

        public IRandomizer GetRandomizer(Type valueType)
        {
            if (_randomizers.TryGetValue(valueType, out var randomizer) == false)
            {
                Throw.RandomizerForTypeNotRegistered(valueType);
            }

            return randomizer;
        }

        public void RegisterRandomizer(Type valueType, IRandomizer randomizer)
        {
            if (randomizer == null)
            {
                Throw.RandomizerIsNull(valueType);
            }

            if (_randomizers.ContainsKey(valueType))
            {
                Throw.RandomizerForTypeAlreadyRegistered(valueType);
            }

            _randomizers.Add(valueType, randomizer);
        }

        public RandomService(IDictionary<Type, IRandomizer> randomizers = null) =>
            _randomizers = randomizers ?? new Dictionary<Type, IRandomizer>();

        ~RandomService() => Dispose(false);

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Private implementation of Dispose pattern.
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                DisposeRandomizers();
            }

            _disposed = true;
        }

        private void DisposeRandomizers()
        {
            foreach (var randomizer in _randomizers.Values)
            {
                if (randomizer is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}