using System;
using DotKEGG;

public class DbEntryComparison {
    public void CompareGetEntryMethods() {
        #region Inline Code
        KeggDb db = DiseaseDb.Instance;
        KeggId kid = db.Entry(00118);
        HNumber hnum = DiseaseDb.Disease(00118);

        Console.WriteLine(kid == hnum);

        // Outputs "true"
        #endregion
    }
}
