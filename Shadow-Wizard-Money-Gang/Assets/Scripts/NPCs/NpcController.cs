using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField]private GameObject dialog;
    public void ActiveDialog()
    {
        dialog.SetActive(true);
    }
    public bool DialogActive()
    {
        return dialog.activeInHierarchy;
    }
}
