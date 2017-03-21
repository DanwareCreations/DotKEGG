namespace DotKEGG {

    public class Reference {

        public Reference(string pmid, string[] authors, string title, string journal) {
            PMID = pmid;
            Authors = authors;
            Title = title;
            Journal = journal;
        }

        public string PMID { get; }
        public string[] Authors { get; }
        public string Title { get; }
        public string Journal { get; }

    }

}
