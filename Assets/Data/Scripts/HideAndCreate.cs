using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class HideAndCreate : MonoBehaviour {
    private Interactable _interactable;
    public SteamVR_Action_Boolean xButton;
    private TableData table;
    private GameObject bigBuilding;
    private bool _isAnimated;

    public bool _isTouched;

    private void Start() {
        table = GetComponentInParent<TableData>();
        _interactable = GetComponent<Interactable>();
    }

    public void Update() {
        if (_isTouched) {
            MoveTableUnderGround();
        }

        if (_isAnimated) {
            AnimateBigBuildingAppearance();
        }

        GetPinchDown();
    }

    private void GetPinchDown() {
        if (xButton.GetStateDown(SteamVR_Input_Sources.Any) && _interactable.isHovering) {
            _isTouched = true;

            table.chosenBuilding = gameObject;
            table.chosenBuildingData[0] = transform.position;
            table.chosenBuildingData[1] = transform.localScale;
        }
    }

    private void MoveTableUnderGround() {
        if (table.transform.position.y >= -3) {
            table.transform.position += new Vector3(0, -1, 0) * Time.deltaTime;
        }
        else {
            _isTouched = false;
            MoveBuildingUp();
        }
    }

    private void MoveBuildingUp() {
        transform.localScale = new Vector3(3, 3, 3);
        _isAnimated = true;
    }

    private void AnimateBigBuildingAppearance() {
        if (transform.position.y >= 1) {
            _isAnimated = false;
            return;
        }

        transform.position += new Vector3(0, 0.1f, 0);
    }
}