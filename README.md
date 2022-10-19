# Random Service

Contains a Random Service that provides an **IRandomizer** abstraction whose contract is equivalent to **System.Random**.

## Features

- **New** random number generators based on **System.Random**:
    - **ConcurrentPseudoRandom** - A random number generator guaranteeing thread safety;
    - **CryptoRandom** - A random number generator based on the System.Security.Cryptography.RNGCryptoServiceProvider.

- Supported **types**:
    1. Int32/Int
    2. Double
    3. Byte[]

- Supported **types** via **extension** methods:
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

- Extensibility (see **[Depra.Unity.Random](https://github.com/Depression-aggression/Unity-Random)**);
- Most of the functionality is covered by **unit tests;**
- Also included are **benchmarks** that may be of interest.

## Usage

To instantiate a service you need to use the **builder** pattern.

Instance creation with a **custom randomizer**:

```csharp
var randomService = new RandomServiceBuilder()
                .With<int>(new CutomIntRandomizer()) // Or another randomizer
                .Build();                            // for type Int32
```

Instantiating with a **collection** of **randomizers**:

```csharp
var randomService = new RandomServiceBuilder()
                .With(new PseudoRandomizers()) // Or another collection of randomizers. 
                .Build();

// You can get randomizers from collections working with System.Random in this way:
var intRandomizer = randomService.GetRandomizer(typeof(int))
intRandomizer = randomService.GetNumberRandomizer<int>();
var doubleRandomizer = randomService.GetTypedRandomizer<double>();
var byteArrayRandomizer = randomService.GetArrayRandomizer<byte[]>();
```

With the help of **extension methods** for randomizers, you can also get random value types that are not supported through System.Random.
An example of getting a **random string** using **INumberRandomizer<int>**:

```csharp
var intRandomizer = randomService.GetNumberRandomizer<int>();
var randUpperCaseString = intRandomizer.NextString(length: 10, includeLowerCase: false);
var randString = intRandomizer.NextString(length: 20, allowedCharacters: "abcdef");
```

## Integrations:

- **[Depra.Unity.Random](https://github.com/Depression-aggression/Unity-Random)** - To provide support for UnityEngine.Random.

## Ps

Some extension methods may not perform well and will be improved in future releases.

Your suggestions for improvements are welcome.