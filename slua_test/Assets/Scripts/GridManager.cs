using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using SLua;

public class GridManager : MonoBehaviour {


    private LuaSvr ls;
    private LuaTable lt;
    private LuaFunction update;

	void Start () {
        ls = new LuaSvr();
        ls.init(null, () =>
        {
            lt = (LuaTable)ls.start("Scripts/GridManager");
            update = (LuaFunction)lt["update"];
        });
	}

    void Update()
    {
            update.call(lt);
    }
}
