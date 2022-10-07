using System;

namespace Depra.Random.System
{
    public sealed class ThreadSafeRandom : global::System.Random
    {
        private static readonly global::System.Random Global = new global::System.Random();

        [ThreadStatic] private static global::System.Random _local;

        public override int Next() => Next(1, int.MaxValue);

        public override int Next(int maxExclusive) => Next(1, maxExclusive);

        public override int Next(int minInclusive, int maxExclusive)
        {
            var inst = _local;

            if (inst != null)
            {
                return inst.Next(minInclusive, maxExclusive);
            }

            int seed;

            lock (Global)
            {
                seed = Global.Next();
            }

            _local = inst = CreateRandom(seed);

            return inst.Next(minInclusive, maxExclusive);
        }

        public long NextLong(long minInclusive, long maxExclusive)
        {
            var inst = _local;

            if (inst != null)
            {
                return inst.NextLong(minInclusive, maxExclusive);
            }

            int seed;

            lock (Global)
            {
                seed = Global.Next();
            }

            _local = inst = CreateRandom(seed);

            return inst.NextLong(minInclusive, maxExclusive);
        }

        public override void NextBytes(byte[] buffer)
        {
            var inst = _local;

            if (inst != null)
            {
                inst.NextBytes(buffer);
                return;
            }

            int seed;

            lock (Global)
            {
                seed = Global.Next();
            }

            _local = inst = CreateRandom(seed);
            inst.NextBytes(buffer);
        }

        public void NextChars(char[] buffer)
        {
            var inst = _local;

            if (inst != null)
            {
                inst.NextChars(buffer);
                return;
            }

            int seed;

            lock (Global)
            {
                seed = Global.Next();
            }

            _local = inst = CreateRandom(seed);
            inst.NextChars(buffer);
        }

        private static global::System.Random CreateRandom(int seed) => new global::System.Random(seed);
    }
}