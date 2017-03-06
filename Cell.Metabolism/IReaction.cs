namespace Cell.Metabolism {

    public interface IReaction {

        ICompound[] GetReactants();
        ICompound[] GetProducts();

        void AddReactant(ICompound compound, uint coefficient, Concentration concentration);
        void AddProduct(ICompound compound, uint coefficient, Concentration concentration);
        void RemoveReactant(ICompound compound);
        void RemoveProduct(ICompound compound);

        uint StoichiometryOf(ICompound compound);
        float EquilibriumConstant(Temperature temperature);
        float ReactionQuotient(ISolution solution);

    }

}
