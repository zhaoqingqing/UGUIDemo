using UnityEngine;
using System.Collections;

public static class GameObjectEx
{
	public static void SetLocalPosX(this GameObject pObj, float pScale)
	{
		pObj.transform.localPosition = new Vector3(pScale, pObj.transform.localPosition.y,
			pObj.transform.localPosition.z);
	}

	public static void SetLocalPosY(this GameObject pObj, float pScale)
	{
		pObj.transform.localPosition = new Vector3(pObj.transform.localPosition.x, pScale,
			pObj.transform.localPosition.z);
	}

	public static void SetLocalPosZ(this GameObject pObj, float pScale)
	{
		pObj.transform.localPosition = new Vector3(pObj.transform.localPosition.x, pObj.transform.localPosition.y,
			pScale);
	}

	public static void SetLocalPos(this GameObject pObj, float x, float y, float z)
	{
		pObj.transform.localPosition = new Vector3(x, y, z);
	}

	public static void SetLocalRotX(this GameObject pObj, float pScale)
	{
		pObj.transform.localRotation =
			Quaternion.Euler(new Vector3(pScale, pObj.transform.localRotation.eulerAngles.y,
				pObj.transform.localRotation.eulerAngles.z));
	}

	public static void SetLocalRotY(this GameObject pObj, float pScale)
	{
		pObj.transform.localRotation =
			Quaternion.Euler(new Vector3(pObj.transform.localRotation.eulerAngles.x, pScale,
				pObj.transform.localRotation.eulerAngles.z));
	}

	public static void SetLocalRotZ(this GameObject pObj, float pScale)
	{
		pObj.transform.localRotation =
			Quaternion.Euler(new Vector3(pObj.transform.localRotation.eulerAngles.x,
				pObj.transform.localRotation.eulerAngles.y, pScale));
	}

	public static void SetLocalRot(this GameObject pObj, float x, float y, float z)
	{
		pObj.transform.localRotation = Quaternion.Euler(new Vector3(x, y, z));
	}

	public static void SetLocalRot(this GameObject pObj,Vector3 pVec)
	{
		pObj.transform.localRotation = Quaternion.Euler(pVec);
	}

	public static void SetLocalScaleX(this GameObject pObj, float pScale)
	{
		pObj.transform.localScale = new Vector3(pScale, pObj.transform.localScale.y, pObj.transform.localScale.z);
	}

	public static void SetLocalScaleY(this GameObject pObj, float pScale)
	{
		pObj.transform.localScale = new Vector3(pObj.transform.localScale.x, pScale, pObj.transform.localScale.z);
	}

	public static void SetLocalScaleZ(this GameObject pObj, float pScale)
	{
		pObj.transform.localScale = new Vector3(pObj.transform.localScale.x, pObj.transform.localScale.y, pScale);
	}

	public static void ZomeLocalScaleX(this GameObject pObj, float pScale)
	{
		pObj.SetLocalScaleX(pObj.transform.localScale.x*pScale);
	}

	public static void ZomeLocalScaleY(this GameObject pObj, float pScale)
	{
		pObj.SetLocalScaleY(pObj.transform.localScale.y*pScale);
	}

	public static void ZomeLocalScaleZ(this GameObject pObj, float pScale)
	{
		pObj.SetLocalScaleZ(pObj.transform.localScale.z*pScale);
	}

	public static void SetLocalScale(this GameObject pObj, float x, float y, float z)
	{
		pObj.transform.localScale = new Vector3(x, y, z);
	}

	public static void SetLocalScale(this GameObject pObj, Vector3 pSize)
	{
		pObj.transform.localScale = pSize;
	}

	public static void ZomeLocalScale(this GameObject pObj, float x, float y, float z)
	{
		pObj.transform.localScale = new Vector3(pObj.transform.localScale.x*x, pObj.transform.localScale.y*y,
			pObj.transform.localScale.z*z);
		;
	}

	public static void ZomeLocalScale(this GameObject pObj, float pScale)
	{
		pObj.transform.localScale *= pScale;
	}

	public static void SetParentAndPos(this GameObject pObj, Vector3 pLocalPos, Transform pParent = null)
	{
		SetParentAndTrans(pObj, pParent);
		pObj.transform.transform.localPosition = pLocalPos;

	}

	public static void SetParentAndRot(this GameObject pObj, Vector3 pLocalRot, Transform pParent = null)
	{
		SetParentAndTrans(pObj, pParent);
		pObj.transform.transform.localRotation = Quaternion.Euler(pLocalRot);
	}

	public static void SetParentAndScale(this GameObject pObj, Vector3 pLocalScale, Transform pParent = null)
	{
		SetParentAndTrans(pObj, pParent);
		pObj.transform.transform.localScale = pLocalScale;
	}

	public static void SetParentAndTrans(this GameObject pObj, Transform pParent = null)
	{
		if (pParent != null)
		{
			pObj.transform.transform.parent = pParent;
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

	public static T AddCompIfNull<T>(this GameObject pObj) where T : MonoBehaviour
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
}