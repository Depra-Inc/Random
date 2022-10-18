// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.System.Mapping
{
    internal sealed class SystemRandomizersMapper
    {
        private readonly INumberRandomizer<int> _intRandomizer;
        private readonly ITypedRandomizer<double> _doubleRandomizer;
        private readonly IArrayRandomizer<byte[]> _byteRandomizer;

        public IRandomizer GetRandomizer(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Int32:
                    return _intRandomizer;
                case TypeCode.Double:
                    return _doubleRandomizer;
                default:
                {
                    if (type == typeof(byte[]))
                    {
                        return _byteRandomizer;
                    }

                    throw new ArgumentException();
                }
            }
        }

        public IEnumerable<IRandomizer> GetAllRandomizers()
        {
            yield return _intRandomizer;
            yield return _doubleRandomizer;
            yield return _byteRandomizer;
        }

        public SystemRandomizersMapper(
            INumberRandomizer<int> intRandomizer,
            ITypedRandomizer<double> doubleRandomizer,
            IArrayRandomizer<byte[]> byteRandomizer)
        {
            _intRandomizer = intRandomizer;
            _doubleRandomizer = doubleRandomizer;
            _byteRandomizer = byteRandomizer;
        }
    }
}