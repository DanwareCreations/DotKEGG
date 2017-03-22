﻿namespace DotKEGG {
    
    public sealed class DrugDb : KeggDb {

        private static DrugDb _instance = new DrugDb();

        private DrugDb() {
            Name = "drug";
            Abbreviation = "dr";
            Prefix = "D";
        }

        public static DrugDb Instance = new DrugDb();

        public static DNumber Drug(uint number) {
            return new DNumber(number);
        }

        public override KeggId Entry(uint number) {
            return new DNumber(number);
        }

    }

}