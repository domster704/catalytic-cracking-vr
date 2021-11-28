using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample {
    public class ButtonClick : UIElement {
        private SkeletonUIOptions ui;

        public TableData table;

        protected override void Awake() {
            base.Awake();
            // table = GameObject.Find("Table").GetComponent<TableData>();

            ui = this.GetComponentInParent<SkeletonUIOptions>();
        }

        protected override void OnButtonClick() {
            base.OnButtonClick();

            if (ui != null) {
                table.SetFlag(null, true);
                
                if (table.chosenBuilding != null) {
                    table.chosenBuilding.transform.position = table.chosenBuildingData[0];
                    table.chosenBuilding.transform.localScale = table.chosenBuildingData[1];
                }
            }
        }
    }
}