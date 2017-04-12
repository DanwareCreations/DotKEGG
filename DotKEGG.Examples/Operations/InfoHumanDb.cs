using System;
using DotKEGG;

public class InfoHumanDb {
    public void GetHumanGeneInfo() {
        // Get KEGG gene info using the human organism code
        printInfo(KeggInfo.ForOrganism("hsa"));

        // Get KEGG gene info using the human T number
        printInfo(KeggInfo.ForGenome(new TNumber(01001)));
    }
    private void printInfo(InfoResults info) {
        Console.WriteLine("KEGG human Info:");
        Console.WriteLine("\tName: {0}", info.Name);
        Console.WriteLine("\tAbbreviation: {0}", info.Abbreviation);
        Console.WriteLine("\tFull Name: {0}", info.FullName);
        Console.WriteLine("\tVersion: {0}", info.Version);
        Console.WriteLine("\tOrganization: {0}", info.Organization);
        Console.WriteLine("\tNumber of Genes: {0}", info.NumEntries[0].Value);
    }
}

// Both methods of querying the KEGG gene database for humans should generate output like the following:

// KEGG human Info:
//      Name: T01001
//      Abbreviation: hsa
//      Full Name: Homo sapiens (human) KEGG Genes Database
//      Version: Release 81.0+/03-24, Mar 17
//      Organization: Kanehisa Laboratories
//      Number of Genes: 39,229 entries