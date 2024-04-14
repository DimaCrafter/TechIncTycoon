public interface IMenu<Parent> where Parent: ContextedBehaviour {
    public Parent parent { get; set; }
}
