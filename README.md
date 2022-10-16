# Random Service

Contains a Random Service that provides an **IRandomizer** abstraction whose contract is equivalent to **System.Random**.

Most of the functionality is covered by unit tests.

Also included are benchmarks that may be of interest.

### List of available randomizers:

- **PseudoRandom** - Decorator for System.Random, to support the IRandomizer contract;
- **ConcurrentPseudoRandom** - A random number generator guaranteeing thread safety;
- **CryptoRandom** - A random number generator based on the System.Security.Cryptography.RNGCryptoServiceProvider.

### Supported types:

1. Int32/Int
2. Double
3. Byte[]

### Supported types via extension methods:

1. SByte
2. Byte
3. Int16/Short
4. UInt16/UShort
5. UInt32/UInt
6. Int64/Long
7. UInt64/ULong
8. Float
9. Decimal
10. Char[]
11. String
12. Boolean
13. Enum

## Usage

A service is best consumed through an IoC container. But nothing prevents you from creating an instance where you see fit.

```csharp
var randomizer = new PseudoRandom();
var randomService = new RandomService(randomizer);

var randomValue = randomService.GetRandomizer().NextDouble(0, 100);
```

## Ps

Some extension methods may not perform well and will be improved in future releases.

Your suggestions for improvements are welcome.