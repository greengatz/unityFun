using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandSelectable : MonoBehaviour {

    //public GameObject colliderOwner = null;
    private Collider redirectCollider = null;

    public void Start()
    {
        /*if (colliderOwner != null)
        {
            redirectCollider = colliderOwner.GetComponent<Collider>();
        }*/
        redirectCollider = GetComponent<Collider>();
    }

    public void wandSelect()
    {
        Debug.Log("selected with a wand, redirecting to mouse input");
        redirectCollider.SendMessage("OnMouseDown");
    }

    public void wandHover()
    {
        redirectCollider.SendMessage("OnMouseEnter");
    }

    public void wandExitHover()
    {
        redirectCollider.SendMessage("OnMouseExit");
    }
}
