using UnityEngine;
using System.Collections;

public class controlBinds : MonoBehaviour {
    public KeyCode camFw, camBw, camRt, camLf, mouse0, mouse1, pause;

    void Start() {
        camFw = KeyCode.UpArrow;
        camBw = KeyCode.DownArrow;
        camRt = KeyCode.RightArrow;
        camLf = KeyCode.LeftArrow;
        mouse0 = KeyCode.Mouse0;
        mouse1 = KeyCode.Mouse1;
        pause = KeyCode.P;
    }

    public void setCamFw(KeyCode newBind) { camFw = newBind; }
    public void setCamBw(KeyCode newBind) { camBw = newBind; }
    public void setCamRt(KeyCode newBind) { camRt = newBind; }
    public void setCamLf(KeyCode newBind) { camLf = newBind; }
    public void setMouse0(KeyCode newBind) { mouse0 = newBind; }
    public void setMouse1(KeyCode newBind) { mouse1 = newBind; }
    public void setPause(KeyCode newBind) { pause = newBind; }
}
