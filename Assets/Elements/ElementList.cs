using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ElementList {
	bool[] elementActivationList; //index 0==A 1==B 2==C

	public ElementList()
	{
		this.elementActivationList = new bool[3];
		this.ResetElements();
	}

	public ElementList(List<ElementType> activeElements)
	{
		this.elementActivationList = new bool[3];
		this.ResetElements();

		foreach (ElementType activeElement in activeElements) 
		{
			this.ActivateElement (activeElement);
		}
		
	}

	public void ActivateElement(ElementType elementToBeActivated)
	{
		switch (elementToBeActivated) 
		{
		case ElementType.A:
			this.elementActivationList [0] = true;
			break;

		case ElementType.B:
			this.elementActivationList [1] = true;
			break;

		case ElementType.C:
			this.elementActivationList [2] = true;
			break;

		default:
			break;
		}
	}

	public void SwitchElementState(ElementType elementToBeActivated)
	{
		switch (elementToBeActivated) 
		{
		case ElementType.A:
			this.elementActivationList [0] = !this.elementActivationList [0];
			break;

		case ElementType.B:
			this.elementActivationList [1] = !this.elementActivationList [1];
			break;

		case ElementType.C:
			this.elementActivationList [2] = !this.elementActivationList [2];
			break;

		default:
			break;
		}
	}

	public void ResetElements()
	{
		this.elementActivationList [0] = false;
		this.elementActivationList [1] = false;
		this.elementActivationList [2] = false;
	}

	public bool AtLeastOneElementIsActive()
	{
		if (this.elementActivationList [0] || this.elementActivationList [1] || this.elementActivationList [2])
			return true;
		else
			return false;
	}

	public List<ElementType> getActiveElements()
	{
		List<ElementType> activeElements = new List<ElementType>();
		for(int i=0; i<3; i++)
		{
			if (this.elementActivationList[i]) 
			{
				switch(i)
				{
				case 0:
					activeElements.Add (ElementType.A);
					break;
				case 1:
					activeElements.Add (ElementType.B);
					break;
				case 2:
					activeElements.Add (ElementType.C);
					break;
				default:
					break;
				}
			}
		}
		return activeElements;
	}

	public ElementType getFirstActiveElement()
	{
		for(int i=0; i<3; i++)
		{
			if (this.elementActivationList[i]) 
			{
				switch(i)
				{
				case 0:
					return ElementType.A;
				case 1:
					return  ElementType.B;
				case 2:
					return  ElementType.C;
				}
			}
		}
		return ElementType.A;
	}	
}
