
public interface Interactible
{
    public string InteractionPrompt {get;}

    public string Name();

    public bool Interact(Interactor interactor);

    public void DisplayNextSentence();

    public void DisplayWrongAnswerPrompt();
}