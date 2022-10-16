using System;
using Depra.Random.Randomizers;

namespace Depra.Random.System
{
    /// <summary>
    /// Decorator for <see cref="Random"/>, to support the <see cref="IRandomizer"/> contract.
    /// </summary>
    public sealed class PseudoRandom : global::System.Random, IRandomizer { }
}