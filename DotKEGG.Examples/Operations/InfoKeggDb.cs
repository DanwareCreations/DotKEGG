using System;
using DotKEGG;

public class InfoKeggDb {
    public void GetKeggInfo() {
        InfoResults info = KeggInfo.Kegg();     // Get KEGG info

        Console.WriteLine("KEGG Info:");
        Console.WriteLine("\tName: {0}", info.Name);
        Console.WriteLine("\tAbbreviation: {0}", info.Abbreviation);
        Console.WriteLine("\tFull Name: {0}", info.FullName);
        Console.WriteLine("\tVersion: {0}", info.Version);
        Console.WriteLine("\tOrganization: {0}", info.Organization);
        Console.WriteLine("\tNumber of Entries in Each Database:");
        foreach (var pair in info.NumEntries)
            Console.WriteLine("\t\t{0} - {1}", pair.Key, pair.Value);
    }
}

// This example should generate output like the following:

// KEGG Info:
//      Name: kegg
//      Abbreviation: kegg
//      Full Name: Kyoto Encyclopedia of Genes and Genomes
//      Version: Release 81.0+/03-24, Mar 17
//      Organization: Kanehisa Laboratories
//      Number of Entries in Each Database:
//          pathway - 497,947 entries
//          brite - 176,476 entries
//          module - 400,557 entries
//          disease - 1,769 entries
//          drug - 10,440 entries
//          environ - 850 entries
//          orthology - 20,749 entries
//          genome - 5,053 entries
//          genes - 21,738,416 entries
//          dgenes - entries
//          compound - 17,947 entries
//          glycan - 11,015 entries
//          reaction - 10,491 entries
//          rpair - entries
//          rclass - 3,116 entries
//          enzyme - 6,896 entries