using System.IO;
using System.Linq;

namespace DotKEGG {
    
    public sealed class KeggReader<ID> : KeggReader where ID : KeggId {

        internal KeggReader(Stream input) : base(input) { }

        public new ID Read() => base.Read() as ID;
        public int ReadBlock(ID[] buffer, int index, int count) => base.ReadBlock(buffer, index, count);
        public new ID[] ReadToEnd() => base.ReadToEnd().Cast<ID>().ToArray();

    }

}