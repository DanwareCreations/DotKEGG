namespace Cell.Metabolism {

    public interface IProtein : ICompound {
        IGene Gene { get; }
    }

}
