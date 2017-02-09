using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Detail		:  UGUI Helper
/// Author		:  qingqing-zhao(569032731@qq.com)
/// CreateTime  :  #CreateTime#
/// </summary>
public class UGUIHelper
{

    /// <summary>
    /// Finds the first Selectable element in the providade hierarchy.
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public static GameObject FindFirstEnabledSelectable(GameObject gameObject)
    {
        if (gameObject == null) return null;
        GameObject go = null;
        var selectables = gameObject.GetComponentsInChildren<Selectable>(true);
        foreach (var selectable in selectables)
        {
            if (selectable.IsActive() && selectable.IsInteractable())
            {
                go = selectable.gameObject;
                break;
            }
        }
        return go;
    }
}
