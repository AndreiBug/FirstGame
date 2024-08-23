using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReappearMilk : MonoBehaviour
{
    public GameObject childGameObject;
    public float delay = 2.0f;
    private bool IsStartingToActivate = false;


    // Update is called once per frame
    void Update()
    {
        if (childGameObject.activeSelf == false && IsStartingToActivate == false)
        {
            IsStartingToActivate = true;
            StartCoroutine(ActivateChild());
        }
    }
    private IEnumerator ActivateChild()
    {
        yield return new WaitForSeconds(delay);
        IsStartingToActivate = false;

        childGameObject.SetActive(true);
    }
}
