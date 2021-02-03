using System;
using UnityEngine;

public class Ground : MonoBehaviour, ISelectable
{
    public void OnSelected()
    {
        var position = transform.position;
        Debug.LogError($"Selected Ground at: X: {position.x}, Y: {position.y}, Z:{position.z}");
    }

    public void OnDeselected()
    {
        var position = transform.position;
        Debug.LogError($"Deselected Ground at: X: {position.x}, Y: {position.y}, Z:{position.z}");
    }

    public void OnDestroy() {
        ObjectSelector.Instance.CheckForCleanUp(this);
    }
}
