using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 参考自：http://blog.csdn.net/qq992817263/article/details/50958025
/// </summary>
public class ChangeSprite : MonoBehaviour
{
    public Image mImage;
    public UGUISpriteAsset usa;
    private float fTime = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    void OnGUI()
    {
        if (GUILayout.Button("更换Sprite"))
        {
            if (mImage)
            {
                //方法一
                var xxsprite = Resources.Load("Images/Bordered2", typeof(Sprite)) as Sprite;
                mImage.overrideSprite = xxsprite;
            }
        }
        //方法二 通过www加载

        //方法三 通过Texture转换
    }

    // Update is called once per frame  
    void Update()
    {
        fTime += Time.deltaTime;
        if (fTime >= 0.3f)
        {
            mImage.sprite = usa.listSpriteAssetInfor[Random.Range(0, usa.listSpriteAssetInfor.Count)].sprite;
            fTime = 0.0f;
        }
    }
}
