using UnityEngine;
using System.Collections;

public class controlBinds : MonoBehaviour {
	public KeyCode camFw, camBw, camRt, camLf, mouse0, mouse1, pause1, pause2;
	public KeyCode configMenu, buildingMenu, upgradeMenu, unitMenu;

    void Start() {
        camFw = KeyCode.UpArrow;
        camBw = KeyCode.DownArrow;
        camRt = KeyCode.RightArrow;
        camLf = KeyCode.LeftArrow;
        mouse0 = KeyCode.Mouse0;
        mouse1 = KeyCode.Mouse1;
		pause1 = KeyCode.P;
        pause2 = KeyCode.Escape;
		configMenu = KeyCode.M;
		buildingMenu = KeyCode.B;
		upgradeMenu = KeyCode.U;
		unitMenu = KeyCode.S;
    }

    public void setCamFw(KeyCode newBind) { camFw = newBind; }
    public void setCamBw(KeyCode newBind) { camBw = newBind; }
    public void setCamRt(KeyCode newBind) { camRt = newBind; }
    public void setCamLf(KeyCode newBind) { camLf = newBind; }
    public void setMouse0(KeyCode newBind) { mouse0 = newBind; }
    public void setMouse1(KeyCode newBind) { mouse1 = newBind; }
	public void setPause1(KeyCode newBind) { pause1 = newBind; }
	public void setPause2(KeyCode newBind) { pause2= newBind; }
	public void setConfigMenu(KeyCode newBind) { configMenu = newBind; }
	public void setBuildingMenu(KeyCode newBind) { buildingMenu = newBind; }
	public void setUpgradeMenu(KeyCode newBind) { upgradeMenu = newBind; }
	public void setUnitMenu(KeyCode newBind) { unitMenu = newBind; }
}
