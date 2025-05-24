using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class BaseNode : Node
{
	public virtual string getDialogText()
	{
		return "";
	}
	
	public virtual Sprite getSprite()
	{
		return null;
	}

}