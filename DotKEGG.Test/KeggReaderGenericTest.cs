using System;
using System.Net;
using System.Linq;

using NUnit.Framework;

namespace DotKEGG.Test {

    [TestFixture(Author = "Dan Vicarel", TestOf = typeof(KeggReader<MapNumber>), Description = "Checks that correct values can be streamed from a KEGG REST operation.")]
    internal class KeggReaderGenericTest {

        private static WebClient s_web = new WebClient() { BaseAddress = "http://rest.kegg.jp/list/pathway" };
        private static int s_buffer_size = 15;

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader<MapNumber>), Description = "Checks that KeggReader Instances cannot be constructed without valid arguments.")]
        public void KeggReaderGenericConstructorTest() {
            Assert.Throws<ArgumentNullException>(() => new KeggReader<MapNumber>(null));
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader<MapNumber>), Description = "Checks that KeggReader Instances can be disposed correctly.")]
        public void KeggReaderGenericDisposeTest() {
            var reader = new KeggReader<MapNumber>(s_web.OpenRead(string.Empty));

            Assert.False(reader.Disposed);
            Assert.DoesNotThrow(() => reader.Dispose());
            Assert.True(reader.Disposed);
            Assert.DoesNotThrow(() => reader.Dispose());
            Assert.True(reader.Disposed);
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader<MapNumber>), Description = "Checks that KeggReader Instances can be disposed correctly.")]
        public void KeggReaderGenericCannotCallOnDisposedTest() {
            var reader = new KeggReader<MapNumber>(s_web.OpenRead(string.Empty));
            reader.Dispose();

            Assert.Throws<InvalidOperationException>(() => reader.Read());
            Assert.Throws<InvalidOperationException>(() => reader.ReadBlock(new MapNumber[1], 0, 1));
            Assert.Throws<InvalidOperationException>(() => reader.ReadToEnd());
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader<MapNumber>), Description = "Checks that KeggReader can read several KeggIds correctly.")]
        public void KeggReaderGenericReadTest() {
            MapNumber map;

            using (var reader = new KeggReader<MapNumber>(s_web.OpenRead(string.Empty))) {
                map = reader.Read();
                Assert.NotNull(map);
                Assert.AreEqual(00010u, map.Number);

                map = reader.Read();
                Assert.NotNull(map);
                Assert.AreEqual(00020u, map.Number);
            }
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader<MapNumber>), Description = "Checks that KeggReader can read a block of KeggIds correctly.")]
        public void KeggReaderGenericReadBlockTest() {
            MapNumber[] buffer = new MapNumber[s_buffer_size];

            using (var reader = new KeggReader<MapNumber>(s_web.OpenRead(string.Empty))) {
                int numSaved = reader.ReadBlock(buffer, 0, s_buffer_size);
                Assert.AreEqual(s_buffer_size, numSaved);
                Assert.IsEmpty(buffer.Where(map => map == null));
            }
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader<MapNumber>), Description = "Checks that KeggReader can read a block of KeggIds correctly.")]
        public void KeggReaderGenericReadInvalidBlockTest() {
            MapNumber[] buffer = new MapNumber[s_buffer_size];

            using (var reader = new KeggReader<MapNumber>(s_web.OpenRead(string.Empty))) {
                Assert.Throws<ArgumentNullException>(() => reader.ReadBlock(null, 0, s_buffer_size));
                Assert.Throws<ArgumentOutOfRangeException>(() => reader.ReadBlock(buffer, -1, s_buffer_size));
                Assert.Throws<ArgumentOutOfRangeException>(() => reader.ReadBlock(buffer, 0, -1));
                Assert.Throws<ArgumentException>(() => reader.ReadBlock(buffer, s_buffer_size, s_buffer_size));
            }
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader<MapNumber>), Description = "Checks that KeggReader can read the remaining KeggIds correctly.")]
        public void KeggReaderGenericReadToEndTest() {
            MapNumber[] remaining;

            // Get the number of returned IDs, and assert that none of them are null
            int count = 0;
            using (var reader = new KeggReader<MapNumber>(s_web.OpenRead(string.Empty))) {
                remaining = reader.ReadToEnd();
                count = remaining.Length;
                Assert.IsEmpty(remaining.Where(id => id == null));
            }

            // Assert that we get the correct number of IDs after a couple initial Reads
            const short NUM_READS = 4;
            using (var reader = new KeggReader<MapNumber>(s_web.OpenRead(string.Empty))) {
                for (int r = 0; r < NUM_READS; ++r)
                    reader.Read();
                remaining = reader.ReadToEnd();
                Assert.AreEqual(count - NUM_READS, remaining.Length);
            }
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader<MapNumber> ), Description = "Checks KeggReader's behavior when it has reached the end of its Stream.")]
        public void KeggReaderGenericEndOfStreamTest() {
            using (var reader = new KeggReader<MapNumber>(s_web.OpenRead(string.Empty))) {
                reader.ReadToEnd();

                // Assert that a Read at the end of the stream returns null
                MapNumber map = null;
                Assert.DoesNotThrow(() => map = reader.Read());
                Assert.Null(map);

                // Assert that a ReadBlock at the end of the stream saves nothing
                MapNumber[] buffer = new MapNumber[s_buffer_size];
                int numSaved = 0;
                Assert.DoesNotThrow(() => numSaved = reader.ReadBlock(buffer, 0, s_buffer_size));
                Assert.Zero(numSaved);

                // Assert that a ReadToEnd at the end of the stream returns an empty array
                MapNumber[] remaining = null;
                Assert.DoesNotThrow(() => remaining = reader.ReadToEnd());
                Assert.NotNull(remaining);
                Assert.IsEmpty(remaining);
            }
        }

    }

}
