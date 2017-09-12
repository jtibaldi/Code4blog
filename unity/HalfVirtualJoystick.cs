using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HalfVirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler 
{
	private Image bgImg;
	private Image joystickImg;
	private Vector3 inputVector;

	private void Start() 
	{
		bgImg = GetComponent<Image> ();
		joystickImg = transform.GetChild (0).GetComponent<Image> ();
	}

	public virtual void OnDrag(PointerEventData ped) 
	{
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) 
		{
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

			//Detecta la posición del touch
			if (pos.y < 0) {
				inputVector = new Vector3 (pos.x * 2, 0, pos.y);
			} else 
			{
				inputVector = new Vector3 (pos.x * 2, 0, 0);
			}
			inputVector = (inputVector.magnitude > 0.2f) ? inputVector.normalized : inputVector;

			//Mueve la imagen del joystick
			joystickImg.rectTransform.anchoredPosition = 
				new Vector3 (inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3)
					, inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));			
		}			
	}

	public virtual void OnPointerDown(PointerEventData ped) 
	{
		OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped) 
	{
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	public float Horizontal() 
	{
		if (inputVector.x != 0) {
			return inputVector.x;	
		} else 
		{
			return Input.GetAxis ("Horizontal");
		}
	}

	public float Vertical () 
	{
		if (inputVector.z != 0) {
			return inputVector.z;	
		} else 
		{
			return Input.GetAxis ("Vertical");
		}
	}

}
