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

	public virtual ABILITY getAbility()
	{
		return ABILITY.SENSORY;
	}

	public virtual float getDC()
	{
		return 10.0f;
	}

}