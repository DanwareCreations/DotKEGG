﻿using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace DotKEGG.Test {

    [TestFixture(Author = "Dan Vicarel", TestOf = typeof(ECNumber), Description = "Tests basic functionality of EC Numbers")]
    internal class ECNumberTest {

        private static ECNumber s_oxidoreductase = LigandDb.Enzyme(ECEnzymeClass.OxidoReductase, 2u, 1u, 12u);
        private static ECNumber s_transferase = LigandDb.Enzyme(ECEnzymeClass.Transferase, 3u, 2u, 13u);
        private static ECNumber s_hydrolase = LigandDb.Enzyme(ECEnzymeClass.Hydrolase, 4u, 11u, 4u);
        private static ECNumber s_lyase = LigandDb.Enzyme(ECEnzymeClass.Lyase, 6u, 1u, 1u);
        private static ECNumber s_isomerase = LigandDb.Enzyme(ECEnzymeClass.Isomerase, 5u, 3u, 4u);
        private static ECNumber s_ligase = LigandDb.Enzyme(ECEnzymeClass.Ligase, 4u, 1u, 1u);

        [Test(Author = "Dan Vicarel", TestOf = typeof(ECNumber), Description = "Checks that EC Number Instances have appropriate values")]
        [TestCaseSource(nameof(ecNumberInstanceTestCases))]
        public void ECNumberInstanceTest(ECNumber ec, ECEnzymeClass classId, uint id2, uint id3, uint serialId, string ecStr) {
            Assert.AreEqual(classId, ec.EcClass);
            Assert.AreEqual(id2, ec.Id2);
            Assert.AreEqual(id3, ec.Id3);
            Assert.AreEqual(serialId, ec.SerialId);
            Assert.AreEqual(ecStr, ec.ToString());
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(ECNumber), Description = "Checks that EC Number Instances have appropriate values")]
        [TestCaseSource(nameof(ecNumberInstanceTestCases))]
        public void ECNumberFactoryTest(ECNumber ec, ECEnzymeClass classId, uint id2, uint id3, uint serialId, string ecStr) {
            // Construct some EC Numbers using the EC Class-specific factory methods
            var oxidoreductase = ECNumber.OxidoReductase(2u, 1u, 12u);
            var transferase = ECNumber.Transferase(3u, 2u, 13u);
            var hydrolase = ECNumber.Hydrolase(4u, 11u, 4u);
            var lyase = ECNumber.Lyase(6u, 1u, 1u);
            var isomerase = ECNumber.Isomerase(5u, 3u, 4u);
            var ligase = ECNumber.Ligase(4u, 1u, 1u);
            
            // Assert that these objects are equivalent to the ones generated by the normal constructor
            Assert.AreEqual(s_oxidoreductase, oxidoreductase);
            Assert.AreEqual(s_transferase, transferase);
            Assert.AreEqual(s_hydrolase, hydrolase);
            Assert.AreEqual(s_lyase, lyase);
            Assert.AreEqual(s_isomerase, isomerase);
            Assert.AreEqual(s_ligase, ligase);
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(ECNumber), Description = "Checks that EC Number Instances can be compared for equality.")]
        public void ECNumberEqualityTest() {
            ECNumber a = s_lyase;
            ECNumber b = s_lyase;

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

        [Test(Author = "Dan Vicarel", TestOf = typeof(ECNumber), Description = "Checks that EC Number Instances can be compared for inequality.")]
        public void ECNumberInequalityTest() {
            ECNumber a = s_lyase;
            ECNumber b = s_isomerase;

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

        [Test(Author = "Dan Vicarel", TestOf = typeof(ECNumber), Description = "Checks that EC Number Instances are not equal to null.")]
        public void ECNumberNullInequalityTest() {
            ECNumber a = s_transferase;

            Assert.False(a.Equals(null));
            Assert.False(a == null);
            Assert.True(a != null);
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(ECNumber), Description = "Checks that all EC Number Instances have unique HashCodes")]
        public void ECNumberUniqueHashCodeTest() {
            int[] hashCodes = new int[6] {
                s_oxidoreductase.GetHashCode(),
                s_transferase.GetHashCode(),
                s_hydrolase.GetHashCode(),
                s_lyase.GetHashCode(),
                s_isomerase.GetHashCode(),
                s_ligase.GetHashCode(),
            };
            Assert.AreEqual(hashCodes.Length, hashCodes.Distinct().Count(), $"There is at least one duplicate {nameof(ECNumber)} hash code!");
        }

        private static IEnumerable<TestCaseData> ecNumberInstanceTestCases() {
            yield return new TestCaseData(s_oxidoreductase, ECEnzymeClass.OxidoReductase, 2u, 1u, 12u, "1.2.1.12");
            yield return new TestCaseData(s_transferase, ECEnzymeClass.Transferase, 3u, 2u, 13u, "2.3.2.13");
            yield return new TestCaseData(s_hydrolase, ECEnzymeClass.Hydrolase, 4u, 11u, 4u, "3.4.11.4");
            yield return new TestCaseData(s_lyase, ECEnzymeClass.Lyase, 6u, 1u, 1u, "4.6.1.1");
            yield return new TestCaseData(s_isomerase, ECEnzymeClass.Isomerase, 5u, 3u, 4u, "5.5.3.4");
            yield return new TestCaseData(s_ligase, ECEnzymeClass.Ligase, 4u, 1u, 1u, "6.4.1.1");
    }

    }

}
