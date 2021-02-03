using System;
using UnityEngine;

public class ObjectSelector : MonoBehaviour {
    private Camera _rayCaster;
    private ISelectable _previousSelection;

    public static ObjectSelector Instance;

    /// <summary>
    /// Meant to called when the Object Selector has stopped being used.
    /// </summary>
    public void CleanUp() {
        _previousSelection.OnDeselected();
        _previousSelection = null;
    }

    public void CheckForCleanUp(ISelectable selectable) {
        if (selectable == _previousSelection) {
            CleanUp();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _rayCaster = Camera.main;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// 
    /// </summary>
    private void Update() {
        if (!Input.GetMouseButtonUp(0)) 
            return;
        
        var ray = _rayCaster.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out var hit)) 
            return;
        
        if (hit.transform == null) 
            return;
            
        UpdateSelection(hit);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="hitObject"></param>
    private void UpdateSelection(RaycastHit hitObject) {
        var possibleSelection = hitObject.transform.GetComponent<ISelectable>();

        if(possibleSelection == null)
            return;

        _previousSelection?.OnDeselected();

        possibleSelection.OnSelected();

        _previousSelection = possibleSelection;
    }
}