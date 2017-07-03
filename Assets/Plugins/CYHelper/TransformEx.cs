using UnityEngine;
using System.Collections;

/// <summary>
/// Transform的扩展方法
/// </summary>
public static class TransformEx
{


    public static void SetPositionX_(this Transform t, float newX)
    {
        t.position = new Vector3(newX, t.position.y, t.position.z);
    }

    //public static void SetPositionY(this Transform t, float newY)
    //{
    //    t.position = new Vector3(t.position.x, newY, t.position.z);
    //}

    public static void SetPositionZ_(this Transform t, float newZ)
    {
        t.position = new Vector3(t.position.x, t.position.y, newZ);
    }

    public static void SetLocalPosX_(this Transform pTran, float pScale)
    {
        pTran.localPosition = new Vector3(pScale, pTran.localPosition.y, pTran.localPosition.z);
    }

    public static void SetLocalPosY_(this Transform pTran, float pScale)
    {
        pTran.localPosition = new Vector3(pTran.localPosition.x, pScale, pTran.localPosition.z);
    }

    public static void SetLocalPosZ_(this Transform pTran, float pScale)
    {
        pTran.localPosition = new Vector3(pTran.localPosition.x, pTran.localPosition.y, pScale);
    }

    public static void SetLocalPos(this Transform pTran, float x, float y, float z)
    {
        pTran.localPosition = new Vector3(x, y, z);
    }

    public static void SetLocalPositionYAdd(this Transform t, float newY)
    {
//        t.localPosition = new Vector3(t.localPosition.x, t.GetLocalPositionY() + newY, t.localPosition.z);
    }

    public static void SetLocalRotX(this Transform pTran, float angle)
    {
        pTran.localRotation =
            Quaternion.Euler(new Vector3(angle, pTran.localRotation.eulerAngles.y,
                pTran.localRotation.eulerAngles.z));
    }

    public static void SetLocalRotY(this Transform pTran, float angle)
    {
        pTran.localRotation =
            Quaternion.Euler(new Vector3(pTran.localRotation.eulerAngles.x, angle,
                pTran.localRotation.eulerAngles.z));
    }

    public static void SetLocalRotZ(this Transform pTran, float angle)
    {
        pTran.localRotation =
            Quaternion.Euler(new Vector3(pTran.localRotation.eulerAngles.x, pTran.localRotation.eulerAngles.y,
                angle));
    }

    public static void SetLocalRot(this Transform pTran, float x, float y, float z)
    {
        pTran.localRotation = Quaternion.Euler(new Vector3(x, y, z));
    }

    public static void SetLocalScaleX(this Transform pTran, float pScale)
    {
        pTran.localScale = new Vector3(pScale, pTran.localScale.y, pTran.localScale.z);
    }

    public static void SetLocalScaleY(this Transform pTran, float pScale)
    {
        pTran.localScale = new Vector3(pTran.localScale.x, pScale, pTran.localScale.z);
    }

    public static void SetLocalScaleZ(this Transform pTran, float pScale)
    {
        pTran.localScale = new Vector3(pTran.localScale.x, pTran.localScale.y, pScale);
    }

    public static void SetLocalScaleZero_(this Transform t)
    {
        t.localScale = Vector3.zero;
    }

    public static void ZomeLocalScaleX(this Transform pTran, float pScale)
    {
        pTran.SetLocalScaleX(pTran.localScale.x*pScale);
    }

    public static void ZomeLocalScaleY(this Transform pTran, float pScale)
    {
        pTran.SetLocalScaleY(pTran.localScale.y*pScale);
    }

    public static void ZomeLocalScaleZ(this Transform pTran, float pScale)
    {
        pTran.SetLocalScaleZ(pTran.localScale.z*pScale);
    }

    public static void SetLocalScale(this Transform pTran, float x, float y, float z)
    {
        pTran.localScale = new Vector3(x, y, z);
    }

    public static void ZomeLocalScale(this Transform pTran, float x, float y, float z)
    {
        pTran.localScale = new Vector3(pTran.localScale.x*x, pTran.localScale.y*y, pTran.localScale.z*z);
        ;
    }

    public static void ZomeLocalScale(this Transform pTran, float pScale)
    {
        pTran.localScale *= pScale;
    }

    public static void SetParentAndPos(this Transform pTran, Vector3 pLocalPos, Transform pParent = null)
    {
        SetParentAndTrans(pTran, pParent);
        pTran.transform.localPosition = pLocalPos;

    }

    public static void SetParentAndRot(this Transform pTran, Vector3 pLocalRot, Transform pParent = null)
    {
        SetParentAndTrans(pTran, pParent);
        pTran.transform.localRotation = Quaternion.Euler(pLocalRot);
    }

    public static void SetParentAndScale(this Transform pTran, Vector3 pLocalScale, Transform pParent = null)
    {
        SetParentAndTrans(pTran, pParent);
        pTran.transform.localScale = pLocalScale;
    }

    public static void SetParentAndTrans(this Transform pTran, Transform pParent = null)
    {
        if (pParent != null)
        {
            pTran.transform.parent = pParent;
        }
    }

    public static void SetParentAndTrans(this Transform pTran, Vector3 pLocalPos, Vector3 pLocalRot,
        Vector3 pLocalScale,
        Transform pParent = null)
    {
        pTran.transform.parent = pParent;
        pTran.transform.localPosition = pLocalPos;
        pTran.transform.localRotation = Quaternion.Euler(pLocalRot);
        pTran.transform.localScale = pLocalScale;
    }

    public static void SetActive(this Transform pTran, bool pFlag)
    {
        pTran.gameObject.SetActive(pFlag);
    }

    public static T AddComponent<T>(this Transform pTran) where T : MonoBehaviour
    {
        return pTran.gameObject.AddComponent<T>();
    }

    public static T AddCompIfNull<T>(this Transform pObj) where T : MonoBehaviour
    {
        T _com = pObj.GetComponent<T>();
        if (_com != null)
        {
            return _com;
        }
        else
        {
            return pObj.AddComponent<T>();
        }
    }

    public static Transform FindChildX(this Transform pTran, string name, bool includeInactive = true)
    {
        var childs = pTran.GetComponentsInChildren<Transform>(includeInactive);
        var max = childs.Length;

        for (int idx = 0; idx < max; idx++)
        {
            if (childs[idx] == null) continue;
            if (childs[idx].name == name)
            {
                return childs[idx];
            }
        }
        return null;
    }

    public static Transform FindOrAdd(this Transform pTran,string childName)
    {
        Transform tr = pTran.Find(childName);
        if (tr == null)
        {
            GameObject go = new GameObject(childName);
            tr = go.transform;
            tr.parent = pTran;
            tr.localPosition = Vector3.zero;
            tr.localRotation = Quaternion.identity;
            tr.localScale = Vector3.one;
        }
        return tr;
    }

    public static RectTransform GetRT(this Transform pTran)
    {
        return  pTran as RectTransform;
    }
}