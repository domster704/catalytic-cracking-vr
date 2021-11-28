using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class HideAndCreate : MonoBehaviour {
    private Interactable _interactable;
    public SteamVR_Action_Boolean xButton;
    private TableData table;
    public GameObject bigBuilding;

    public float scale = 3f;
    
    public bool _isTouched;

    private void Start() {
        table = GetComponentInParent<TableData>();
        _interactable = GetComponent<Interactable>();
    }

    public void Update() {
        GetPinchDown();
    }

    private void GetPinchDown() {
        if (xButton.GetStateDown(SteamVR_Input_Sources.Any) && _interactable.isHovering) {
            table.chosenBuilding = gameObject;
            table.chosenBuildingData[0] = transform.position;
            table.chosenBuildingData[1] = transform.localScale;
            
            MoveTableUnderGround();
        }
    }

    private void MoveTableUnderGround() {
        table.SetFlag(null, false);
        Instantiate(bigBuilding, transform.position, Quaternion.identity);
        // transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        MoveBuildingUp();
    }

    private void MoveBuildingUp() {
        transform.localScale = new Vector3(scale / table.transform.localScale.x, scale / table.transform.localScale.y, scale / table.transform.localScale.z);
    }
}