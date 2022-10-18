using System;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.ServiceBuilder
{
    public static class RandomServiceBuilderExtensions
    {
        public static IRandomServiceBuilder With<T>(this IRandomServiceBuilder builder, ITypedRandomizer<T> randomizer) =>
            builder.With(typeof(T), randomizer);

        public static IRandomServiceBuilder With<T>(this IRandomServiceBuilder builder, IArrayRandomizer<T> randomizer) =>
            builder.With(typeof(T), randomizer);

        public static IRandomServiceBuilder With(this IRandomServiceBuilder builder,
            IRandomizerCollection fromCollection)
        {
            var randomizers = fromCollection.GetAllRandomizers();
            foreach (var randomizer in randomizers)
            {
                foreach (var valueType in randomizer.ValueTypes)
                {
                    builder.With(valueType, randomizer);
                }
            }

            return builder;
        }

        public static IRandomServiceBuilder With<T>(this IRandomServiceBuilder builder,
            IRandomizerCollection fromCollection) => With(builder, typeof(T), fromCollection);

        public static IRandomServiceBuilder With(this IRandomServiceBuilder builder, Type valueType,
            IRandomizerCollection fromCollection) => builder.With(valueType, fromCollection.GetRandomizer(valueType));
    }
}