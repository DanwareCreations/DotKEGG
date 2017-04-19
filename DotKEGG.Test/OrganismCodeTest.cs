using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace DotKEGG.Test {

    [TestFixture(Author = "Dan Vicarel", TestOf = typeof(OrganismCode), Description = "Tests basic functionality of organism codes")]
    internal class OrganismCodeTest {

        private static OrganismCode s_human = new OrganismCode("hsa");
        private static OrganismCode s_ecoli = new OrganismCode("eco");
        
        [Test(Author = "Dan Vicarel", TestOf = typeof(OrganismCode), Description = "Checks that OrganismCode Instances cannot be constructed with invalid codes.")]
        public void OrganismCodeConstructorTest() {
            Assert.Throws<ArgumentNullException>(() => new OrganismCode(null));
            Assert.Throws<ArgumentException>(() => new OrganismCode(string.Empty));
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(OrganismCode), Description = "Checks that OrganismCode Instances have appropriate values")]
        [TestCaseSource(nameof(organismCodeInstanceTestCases))]
        public void OrganismCodeInstanceTest(OrganismCode orgCode, string code) {
            Assert.AreEqual(code, orgCode.Code);
            Assert.AreEqual(code, orgCode.ToString());
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(OrganismCode), Description = "Checks that OrganismCode Instances can be compared for equality.")]
        public void OrganismCodeEqualityTest() {
            OrganismCode a = s_ecoli;
            OrganismCode b = s_ecoli;

            Assert.True(a.Equals(b));
            Assert.True(b.Equals(a));
            Assert.True(a == b);
            Assert.False(a != b);
            Assert.True(Equals(a, b));

            object objA = a;
            object objB = b;
            Assert.True(objA.Equals(b));
            Assert.True(b.Equals(objA));
            Assert.True(Equals(objA, b));
            Assert.True(objB.Equals(a));
            Assert.True(a.Equals(objB));
            Assert.True(Equals(objB, a));
            Assert.True(objB.Equals(objA));
            Assert.True(objA.Equals(objB));
            Assert.True(Equals(objB, objA));
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(OrganismCode), Description = "Checks that OrganismCode Instances can be compared for inequality.")]
        public void OrganismCodeInequalityTest() {
            OrganismCode a = s_ecoli;
            OrganismCode b = s_human;

            Assert.False(a.Equals(b));
            Assert.False(b.Equals(a));
            Assert.False(a == b);
            Assert.True(a != b);
            Assert.False(Equals(a, b));

            object objA = a;
            object objB = b;
            Assert.False(objA.Equals(b));
            Assert.False(b.Equals(objA));
            Assert.False(Equals(objA, b));
            Assert.False(objB.Equals(a));
            Assert.False(a.Equals(objB));
            Assert.False(Equals(objB, a));
            Assert.False(objB.Equals(objA));
            Assert.False(objA.Equals(objB));
            Assert.False(Equals(objB, objA));
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(OrganismCode), Description = "Checks that OrganismCode Instances are not equal to null.")]
        public void OrganismCodeNullInequalityTest() {
            OrganismCode a = s_human;

            Assert.False(a.Equals(null));
            Assert.False(a == null);
            Assert.True(a != null);
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(OrganismCode), Description = "Checks that all OrganismCode Instances have unique HashCodes")]
        public void OrganismCodeUniqueHashCodeTest() {
            int[] hashCodes = new int[2] {
                 s_human.GetHashCode(),
                 s_ecoli.GetHashCode(),
            };
            Assert.AreEqual(hashCodes.Length, hashCodes.Distinct().Count(), $"There is at least one duplicate {nameof(OrganismCode)} hash code!");
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(OrganismCode), Description = "Checks that we can get the genome associated with an organism code")]
        [Ignore("The GetGenomeId() function has not been implemented yet.")]
        public void GetGenomeTest() {
            TNumber kid = s_human.GetGenomeId();
            Assert.AreEqual(01001u, kid.Number);
        }

        private static IEnumerable<TestCaseData> organismCodeInstanceTestCases() {
            yield return new TestCaseData(s_human, "hsa");
            yield return new TestCaseData(s_ecoli, "eco");
        }

    }

}
