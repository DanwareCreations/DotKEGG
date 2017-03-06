namespace Cell.Metabolism {

    public interface IEnzyme : IProtein {
        
        ICompound[] Cofactors { get; }
        IReaction[] Reactions { get; }
        float RateMultiplier(ISolution solution);

    }

}
