using UnityEngine;

public class SimpleDialog : BaseNode
{

	[Input] public string entry;
	[Output] public string exit;

	[TextArea(7, 20)]
	
	public string dialogText;
	public Sprite dialogImage;

	public override string getDialogText()
	{
		return dialogText;
	}
	
	public override Sprite getSprite()
	{
		return dialogImage;
	}

}