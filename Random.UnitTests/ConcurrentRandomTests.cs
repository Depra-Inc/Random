// using System;
// using System.Linq;
// using System.Threading.Tasks;
// using Depra.Random.System;
// using FluentAssertions;
// using NUnit.Framework;
//
// namespace Depra.Random.UnitTests.System
// {
//     [TestFixture(Category = nameof(System), TestOf = typeof(ConcurrentRandom))]
//     public class ConcurrentRandomTests
//     {
// #if !NET6_0_OR_GREATER
//         [Test]
//         public void WhenGetRandomValueParallel_AndRandomNumberGeneratorIsSystem_ThenAllZero()
//         {
//             // Arrange.
//             var random = new global::System.Random();
//             var allThreadIssues = 0;
//
//             // Act.
//             Parallel.For(0, 16, body =>
//             {
//                 var numbers = new int[10_000];
//                 for (var i = 0; i < numbers.Length; i++)
//                 {
//                     numbers[i] = random.Next();
//                 }
//
//                 var threadIssues = numbers.Count(x => x == 0);
//                 allThreadIssues += threadIssues;
//                 
//                 Console.WriteLine($"Thread {body} issues: {threadIssues}");
//             });
//
//             // Assert.
//             allThreadIssues.Should().NotBe(0);
//         }
// #endif
//     }
// }