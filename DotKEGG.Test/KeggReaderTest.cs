using System;
using System.Net;
using System.Linq;

using NUnit.Framework;

namespace DotKEGG.Test {

    [TestFixture(Author = "Dan Vicarel", TestOf = typeof(KeggReader), Description = "Checks that correct values can be streamed from a KEGG REST operation.")]
    internal class KeggReaderTest {

        private static WebClient s_web = new WebClient() { BaseAddress = "http://rest.kegg.jp/list/pathway" };
        private static int s_buffer_size = 15;

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader), Description = "Checks that KeggReader Instances cannot be constructed without valid arguments.")]
        public void KeggReaderConstructorTest() {
            Assert.Throws<ArgumentNullException>(() => new KeggReader(null));
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader), Description = "Checks that KeggReader Instances can be disposed correctly.")]
        public void KeggReaderDisposeTest() {
            var reader = new KeggReader(s_web.OpenRead(string.Empty));

            Assert.False(reader.Disposed);
            Assert.DoesNotThrow(() => reader.Dispose());
            Assert.True(reader.Disposed);
            Assert.DoesNotThrow(() => reader.Dispose());
            Assert.True(reader.Disposed);
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader), Description = "Checks that KeggReader Instances can be disposed correctly.")]
        public void KeggReaderCannotCallOnDisposedTest() {
            var reader = new KeggReader(s_web.OpenRead(string.Empty));
            reader.Dispose();

            Assert.Throws<InvalidOperationException>(() => reader.Read());
            Assert.Throws<InvalidOperationException>(() => reader.ReadBlock(new KeggId[1], 0, 1));
            Assert.Throws<InvalidOperationException>(() => reader.ReadToEnd());
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader), Description = "Checks that KeggReader can read several KeggIds correctly.")]
        public void KeggReaderReadTest() {
            KeggId id;

            using (var reader = new KeggReader(s_web.OpenRead(string.Empty))) {
                id = reader.Read();
                Assert.NotNull(id);
                Assert.IsInstanceOf<MapNumber>(id);
                Assert.AreEqual(00010u, id.Number);

                id = reader.Read();
                Assert.NotNull(id);
                Assert.IsInstanceOf<MapNumber>(id);
                Assert.AreEqual(00020u, id.Number);
            }
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader), Description = "Checks that KeggReader can read a block of KeggIds correctly.")]
        public void KeggReaderReadBlockTest() {
            KeggId[] buffer = new KeggId[s_buffer_size];

            using (var reader = new KeggReader(s_web.OpenRead(string.Empty))) {
                int numSaved = reader.ReadBlock(buffer, 0, s_buffer_size);
                Assert.AreEqual(s_buffer_size, numSaved);
                Assert.IsEmpty(buffer.Where(kid => kid == null));
            }
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader), Description = "Checks that KeggReader can read a block of KeggIds correctly.")]
        public void KeggReaderReadInvalidBlockTest() {
            KeggId[] buffer = new KeggId[s_buffer_size];

            using (var reader = new KeggReader(s_web.OpenRead(string.Empty))) {
                Assert.Throws<ArgumentNullException>(() => reader.ReadBlock(null, 0, s_buffer_size));
                Assert.Throws<ArgumentOutOfRangeException>(() => reader.ReadBlock(buffer, -1, s_buffer_size));
                Assert.Throws<ArgumentOutOfRangeException>(() => reader.ReadBlock(buffer, 0, -1));
                Assert.Throws<ArgumentException>(() => reader.ReadBlock(buffer, s_buffer_size, s_buffer_size));
            }
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader), Description = "Checks that KeggReader can read the remaining KeggIds correctly.")]
        public void KeggReaderReadToEndTest() {
            KeggId[] remaining;

            // Get the number of returned IDs, and assert that none of them are null
            int count = 0;
            using (var reader = new KeggReader(s_web.OpenRead(string.Empty))) {
                remaining = reader.ReadToEnd();
                count = remaining.Length;
                Assert.IsEmpty(remaining.Where(id => id == null));
            }

            // Assert that we get the correct number of IDs after a couple initial Reads
            const short NUM_READS = 4;
            using (var reader = new KeggReader(s_web.OpenRead(string.Empty))) {
                for (int r = 0; r < NUM_READS; ++r)
                    reader.Read();
                remaining = reader.ReadToEnd();
                Assert.AreEqual(count - NUM_READS, remaining.Length);
            }
        }

        [Test(Author = "Dan Vicarel", TestOf = typeof(KeggReader), Description = "Checks KeggReader's behavior when it has reached the end of its Stream.")]
        public void KeggReaderEndOfStreamTest() {
            using (var reader = new KeggReader(s_web.OpenRead(string.Empty))) {
                reader.ReadToEnd();

                // Assert that a Read at the end of the stream returns null
                KeggId id = null;
                Assert.DoesNotThrow(() => id = reader.Read());
                Assert.Null(id);

                // Assert that a ReadBlock at the end of the stream saves nothing
                KeggId[] buffer = new KeggId[s_buffer_size];
                int numSaved = 0;
                Assert.DoesNotThrow(() => numSaved = reader.ReadBlock(buffer, 0, s_buffer_size));
                Assert.Zero(numSaved);
            }
        }

    }

}
