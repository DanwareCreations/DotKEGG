namespace Cell.Metabolism {

    public interface IReaction {

        ICompound[] Reactants { get; }
        ICompound[] Catalysts { get; }
        ICompound[] Products { get; }
        float EquilibriumConstant(Temperature temperature);
        float GetReactionQuotient(Solution solution);

    }

}
