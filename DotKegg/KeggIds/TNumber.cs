namespace DotKEGG {

    public sealed class TNumber : KeggId {

        public TNumber(uint number) {
            Number = number;
        }

        public GenomeDb GenomeDatabase => _db as GenomeDb;
        public MetaGenomeDb MetaGenomeDatabase => _db as MetaGenomeDb;

    }

}
