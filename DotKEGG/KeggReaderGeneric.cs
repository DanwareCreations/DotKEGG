using System.IO;
using System.Linq;

namespace DotKEGG {
    
    /// <summary>
    /// Represents a reader that can read a sequential series of strongly typed <see cref="KeggId"/>s from a KEGG REST response.
    /// </summary>
    /// <typeparam name="ID">The type of KEGG IDs to read.</typeparam>
    /// <inheritdoc/>
    public sealed class KeggReader<ID> : KeggReader where ID : KeggId {

        internal KeggReader(Stream input) : base(input) { }

        /// <summary>
        /// Reads a line of characters from the current stream and returns the data as a strongly-typed <see cref="KeggId"/>.
        /// </summary>
        /// <returns>The next strongly-typed <see cref="KeggId"/> from the input stream, or <see langword="null"/> if the end of the input stream is reached.</returns>
        public new ID Read() => base.Read() as ID;
        /// <summary>
        /// Reads a specified maximum number of strongly-typed KEGG IDs from the current stream and writes the data to a buffer, beginning at the specified index.
        /// </summary>
        /// <param name="buffer">
        /// When this method returns, contains the specified strongly-typed <see cref="KeggId"/> array with 
        /// the values between <paramref name="index"/> and (<paramref name="index"/> + <paramref name="count"/> - 1) replaced by 
        /// the KEGG IDs read from the current source.
        /// </param>
        /// <param name="index">The position in <paramref name="buffer"/> at which to begin writing.</param>
        /// <param name="count">The maximum number of KEGG IDs to read.</param>
        /// <returns>
        /// The number of KEGG IDs that have been read. The number will be less than or equal to <paramref name="count"/>, depending on 
        /// whether all input characters have been read.
        /// </returns>
        public int ReadBlock(ID[] buffer, int index, int count) => base.ReadBlock(buffer, index, count);
        /// <summary>
        /// Reads all remaining KEGG IDs from the current position to the end of the stream.
        /// </summary>
        /// <returns>
        /// The rest of the stream as a strongly-typed <see cref="KeggId"/> array, from the current position to the end. 
        /// If the current position is at the end of the stream, returns an empty array.
        /// </returns>
        public new ID[] ReadToEnd() => base.ReadToEnd().Cast<ID>().ToArray();

    }

}