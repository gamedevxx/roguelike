using System.Collections;
using System.Collections.Generic;

public class OnDestroyManager {
    public int alive;

    public void IamKilled() {
    	alive--;
    }

    public OnDestroyManager(int enemiesCnt) {
    	alive = enemiesCnt;
    }
}
