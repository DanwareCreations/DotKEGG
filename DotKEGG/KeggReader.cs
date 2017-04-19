using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace DotKEGG {

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

        public void Dispose() => dispose(true);
        public bool Disposed => _disposed;
        ~KeggReader() => dispose(false);

        #endregion

        public KeggId Read() {
            if (_disposed)
                throw new InvalidOperationException("Cannot read a KEGG ID from a reader that has been disposed!");

            string line = _reader.ReadLine();
            return idFromLine(line);
        }
        public int ReadBlock(KeggId[] buffer, int index, int count) {
            if (_disposed)
                throw new InvalidOperationException("Cannot read KEGG IDs from a reader that has been disposed!");

            int num;
            for (num = 0; num < count; ++num) {
                if (!_reader.EndOfStream) {
                    string line = _reader.ReadLine();
                    KeggId kid = idFromLine(line);
                    buffer[index + num] = kid;
                }
            }

            return num;
        }
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