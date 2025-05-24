using UnityEngine;

public class SimpleDialogV2 : BaseNode
{
	[Input] public string entry;
	[Output] public string exit;

	[TextArea(7, 20)]

	public string dialogText;
	public Sprite dialogImage;
	public Sprite actorImage;
	public BGM backgroundMusic;
	public bool slideInActor;

	public override string getDialogText()
	{
		return dialogText;
	}

	public override Sprite getSprite()
	{
		return dialogImage;
	}

	public Sprite getActorSprite()
	{
		return actorImage;
	}

	public bool shouldSlide()
	{
		return slideInActor;
	}

	public BGM getBGM()
	{
		return backgroundMusic;
	}

}