using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    private SpecialArea mySpecialArea;
    public float HideDistance;

    private void Update()
    {
        mySpecialArea = FindObjectOfType<SpecialArea>();
        if (mySpecialArea)
        {
            var dir = mySpecialArea.transform.position - transform.position;
            if (dir.magnitude < HideDistance)
            {
                SetChildrenActive(false);
            }
            else
            {
                SetChildrenActive(true);
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        else
        {
            SetChildrenActive(false);
        }
    }

    void SetChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }


}
