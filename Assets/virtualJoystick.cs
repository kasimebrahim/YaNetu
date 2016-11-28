using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class virtualJoystick : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
	private Image bgImg;
	private Image joystickImage;
	private Vector3 inputVector;

	private void start()
	{
		bgImg = GetComponent<Image> ();
		joystickImage = transform.GetChild (0).GetComponent<Image>();
	}


	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera,out pos)) 
		{
			Debug.Log ("yi");
		}
			

	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag(ped);
		
	}

	public virtual void OnPointerUp(PointerEventData ped)
	{

	}


}
