using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace DotKEGG {

    /// <summary>
    /// Represents a reader that can read a sequential series of KEGG IDs from a KEGG REST response.
    /// </summary>
    [ComVisible(true)]
    public class KeggReader : IDisposable {
        private StreamReader _reader;
        private bool _disposed = false;

    #if DEBUG
        public KeggReader(Stream input)
    #else
        internal KeggReader(Stream input)
    #endif
        {
            if (input == null)
                throw new ArgumentNullException($"Cannot define a {nameof(KeggReader)} instance from a null Stream!");
            _reader = new StreamReader(input, Encoding.UTF8);
        }

        #region Disposal / Finalization

        /// <summary>
        /// Releases all resources used by the <see cref="KeggReader"/> object.
        /// </summary>
        public void Dispose() => dispose(true);
        /// <summary>
        /// <see langword="true"/> if the <see cref="KeggReader"/> object has been disposed via <see cref="Dispose"/>, otherwise <see langword="false"/>.
        /// </summary>
        public bool Disposed => _disposed;
        ~KeggReader() => dispose(false);

        #endregion

        /// <summary>
        /// Reads a line of characters from the current stream and returns the data as a <see cref="KeggId"/>.
        /// </summary>
        /// <returns>The next <see cref="KeggId"/> from the input stream, or <see langword="null"/> if the end of the input stream is reached.</returns>
        public KeggId Read() {
            if (_disposed)
                throw new InvalidOperationException("Cannot read a KEGG ID from a reader that has been disposed!");

            string line = _reader.ReadLine();
            return idFromLine(line);
        }
        /// <summary>
        /// Reads a specified maximum number of KEGG IDs from the current stream and writes the data to a buffer, beginning at the specified index.
        /// </summary>
        /// <param name="buffer">
        /// When this method returns, contains the specified <see cref="KeggId"/> array with 
        /// the values between <paramref name="index"/> and (<paramref name="index"/> + <paramref name="count"/> - 1) replaced by 
        /// the KEGG IDs read from the current source.
        /// </param>
        /// <param name="index">The position in <paramref name="buffer"/> at which to begin writing.</param>
        /// <param name="count">The maximum number of KEGG IDs to read.</param>
        /// <returns>
        /// The number of KEGG IDs that have been read. The number will be less than or equal to <paramref name="count"/>, depending on 
        /// whether all input characters have been read.
        /// </returns>
        public int ReadBlock(KeggId[] buffer, int index, int count) {
            // Validate parameters
            if (_disposed)
                throw new InvalidOperationException("Cannot read KEGG IDs from a reader that has been disposed!");
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer), "Cannot read a block of KEGG IDs into a null buffer!");
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), index, "Cannot save a block of KEGG IDs at a negative buffer index!");
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, "Cannot read a negative number of KEGG IDs!");
            if (buffer.Length - index < count)
                throw new ArgumentException($"There is not enough room in {nameof(buffer)} for the requested number of KEGG IDs.");

            // Parse KEGG IDs from the requested number of lines from the Stream
            int numSaved;
            for (numSaved = 0; numSaved < count; ++numSaved) {
                if (_reader.EndOfStream)
                    break;
                string line = _reader.ReadLine();
                KeggId kid = idFromLine(line);
                buffer[index + numSaved] = kid;
            }

            return numSaved;
        }
        /// <summary>
        /// Reads all remaining KEGG IDs from the current position to the end of the stream.
        /// </summary>
        /// <returns>
        /// The rest of the stream as a <see cref="KeggId"/> array, from the current position to the end. 
        /// If the current position is at the end of the stream, returns an empty array.
        /// </returns>
        public KeggId[] ReadToEnd() {
            if (_disposed)
                throw new InvalidOperationException("Cannot read KEGG IDs from a reader that has been disposed!");

            char[] newLine = { '\n' };
            KeggId[] ids = _reader.ReadToEnd()
                                  .Split(newLine, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(line => idFromLine(line))
                                  .ToArray();
            return ids;
        }

        #region Helpers

        private KeggId idFromLine(string line) {
            // If we've reached the end of the Stream then just return null
            if (line == null)
                return null;

            // Otherwise, get the database abbreviation and KEGG ID number from that line
            string dbget = line.Substring(0, line.IndexOf('\t'));
            string id = dbget.Substring(dbget.IndexOf(':') + 1);
            int digitPos;
            for (digitPos = 0; digitPos < id.Length; ++digitPos) {
                if (char.IsDigit(id[digitPos]))
                    break;
            }
            string dbAbbrev = id.Substring(0, digitPos);
            uint num = Convert.ToUInt32(id.Substring(digitPos, id.Length - digitPos));

            // Return a boxed KeggId with these values
            switch (dbAbbrev) {
                case "map":
                    return new MapNumber(num);

                case "br":
                    return new BRNumber(num);

                case "md":
                    return new MNumber(num);

                case "ko":
                    return new KNumber(num);

                case "gn":
                    return new TNumber(num);

                case "cpd":
                    return new CNumber(num);

                case "gl":
                    return new GNumber(num);

                case "rn":
                    return new RNumber(num);

                case "rc":
                    return new RCNumber(num);

                case "ds":
                    return new HNumber(num);

                case "dr":
                    return new DNumber(num);

                case "dg":
                    return new DGNumber(num);

                case "ev":
                    return new ENumber(num);

                default:
                    throw new InvalidOperationException();
            }
        }
        private void dispose(bool disposing) {
            if (disposing && !_disposed) {
                _reader.Dispose();
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        #endregion
    }
}