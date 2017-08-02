using UnityEngine;  
using UnityEngine.UI;  
using UnityEngine.EventSystems;  
using System.Collections;
using SLua;

public class ItemDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private LuaSvr ls;
    private LuaTable lt;
    private LuaFunction init;
    private LuaFunction onPointerDown;
    private LuaFunction onPointerUp;
    private LuaFunction onDrag;

    void Start()
    {
        ls = new LuaSvr();
        ls.init(null, () =>
        {
            lt = (LuaTable)ls.start("Scripts/ItemDrag");
            init = (LuaFunction)lt["init"];
            onPointerDown = (LuaFunction)lt["onPointerDown"];
            onPointerUp = (LuaFunction)lt["onPointerUp"];
            onDrag = (LuaFunction)lt["onDrag"];
            init.call(transform as RectTransform);
        });
    }

    public void OnPointerDown(PointerEventData data)
    {
            onPointerDown.call(lt, data);
    }
    public void OnPointerUp(PointerEventData data)
    {
            onPointerUp.call(lt, data);
    }

    public void OnDrag(PointerEventData data)
    {
            onDrag.call(lt, data);
    }
}
