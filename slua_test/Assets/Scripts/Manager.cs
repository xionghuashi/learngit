using UnityEngine;
using System.Collections;
using SLua;

public class Manager : MonoBehaviour {

    private LuaSvr ls;
    private LuaTable lt;
    private LuaFunction lf;

    void Start()
    {
        ls = new LuaSvr();
        ls.init(null, () =>
        {
            lt = (LuaTable)ls.start("Scripts/Manager");
        });
    }
}
