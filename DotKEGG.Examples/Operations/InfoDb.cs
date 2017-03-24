using System;
using DotKEGG;

public class InfoDb {
    public void GetCompoundInfo() {
        InfoResults info = KeggInfo.Database(CompoundDb.Instance);      // Get KEGG COMPOUND info

        Console.WriteLine("KEGG COMPOUND Info:");
        Console.WriteLine("\tName: {0}", info.Name);
        Console.WriteLine("\tAbbreviation: {0}", info.Abbreviation);
        Console.WriteLine("\tFull Name: {0}", info.FullName);
        Console.WriteLine("\tVersion: {0}", info.Version);
        Console.WriteLine("\tOrganization: {0}", info.Organization);
        Console.WriteLine("\tNumber of Entries: {0}", info.NumEntries[0].Value);
    }
}

// This example should generate output like the following:

// KEGG COMPOUND Info:
//      Name: compound
//      Abbreviation: cpd
//      Full Name: KEGG Compound Database
//      Version: Release 81.0+/03-25, Mar 17
//      Organization: Kanehisa Laboratories
//      Number of Entries: 17,947 entries