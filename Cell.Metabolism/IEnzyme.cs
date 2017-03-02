namespace Cell.Metabolism {

    public interface IEnzyme : IProtein {
        
        ICompound[] Cofactors { get; }
        IReaction Reaction { get; }
        float VelocityIn(Solution solution);

    }

}
