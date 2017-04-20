using System;
using System.Collections.Generic;

using DotKEGG;

public class InfoCompositeDb {
    public void GetLigandInfo() {
        InfoResults info = LigandDb.Instance.Info();    // Get KEGG LIGAND info

        Console.WriteLine("KEGG LIGAND Info:");
        Console.WriteLine("\tName: {0}", info.Name);
        Console.WriteLine("\tAbbreviation: {0}", info.Abbreviation);
        Console.WriteLine("\tFull Name: {0}", info.FullName);
        Console.WriteLine("\tVersion: {0}", info.Version);
        Console.WriteLine("\tOrganization: {0}", info.Organization);
        Console.WriteLine("\tNumber of Entries in Auxiliary Databases:");
        foreach (KeyValuePair<string, uint> pair in info.NumEntries)
            Console.WriteLine("\t\t{0} - {1}", pair.Key, pair.Value);
    }
}

// This example should generate output like the following:

// KEGG LIGAND Info:
//      Name: ligand
//      Abbreviation: ligand
//      Full Name: KEGG Ligand Database
//      Version: Release 81.0+/03-25, Mar 17
//      Organization: Kanehisa Laboratories
//      Number of Entries in Auxiliary Databases:
//          compound - 17,947 entries
//          glycan - 11,015 entries
//          reaction - 10,491 entries
//          rpair - entries
//          rclass - 3,116 entries
//          enzyme - 6,896 entries