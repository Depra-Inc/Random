using System;
using Depra.Random.Randomizers;

namespace Depra.Random.Services
{
    public static class RandomServiceBuilderExtensions
    {
        public static IRandomServiceBuilder With<T>(this IRandomServiceBuilder builder, IRandomizer<T> randomizer) =>
            builder.With(typeof(T), randomizer);

        public static IRandomServiceBuilder With(this IRandomServiceBuilder builder, IRandomizerCollection fromCollection)
        {
            var randomizers = fromCollection.GetAllRandomizers();
            foreach (var randomizer in randomizers)
            {
                builder.With(randomizer.ValueType, randomizer);
            }

            return builder;
        }

        public static IRandomServiceBuilder With<T>(this IRandomServiceBuilder builder,
            IRandomizerCollection fromCollection) => With(builder, typeof(T), fromCollection);

        public static IRandomServiceBuilder With(this IRandomServiceBuilder builder, Type valueType,
            IRandomizerCollection fromCollection) => builder.With(valueType, fromCollection.GetRandomizer(valueType));
    }
}