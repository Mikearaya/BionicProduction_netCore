namespace BionicInventory.Application.Interfaces {
    public interface IBasicCommand<T> where T : class {
        void Create ();
        void Update ();
        void Delete ();
    }
}