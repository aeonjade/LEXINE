using UnityEngine;

public class ExitNode : BaseNode
{
	[Input] public string entry;

	public override string getDialogText()
	{
		return "End of story. Click next to return to main menu.";
	}
}