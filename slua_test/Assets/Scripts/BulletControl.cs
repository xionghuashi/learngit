using UnityEngine;
using System.Collections;
using SLua;

public class BulletControl : MonoBehaviour {

    private LuaSvr ls;
    private LuaTable lt;
    private LuaFunction init;
    private LuaFunction update;
    private LuaFunction ontrigger;

    void Start()
    {
        ls = new LuaSvr();
        ls.init(null, () =>
        {
            lt = (LuaTable)ls.start("Scripts/Bullet");
            init = (LuaFunction)lt["init"];
            update = (LuaFunction)lt["update"];
            ontrigger = (LuaFunction)lt["ontriggerenter"];
            init.call(gameObject);
        });
    }

    void Update()
    {
            update.call(lt);        
    }

    void OnCollisionEnter(Collision collision)
    {
        ontrigger.call(collision.gameObject);
    }
}