using UnityEngine;
using System.Collections.Generic;

public class UGUISpriteAsset : ScriptableObject
{
    /// <summary>
    /// 图片资源
    /// </summary>
    public Texture texSource;
    /// <summary>
    /// 所有sprite信息 SpriteAssetInfor类为具体的信息类
    /// </summary>
    public List<SpriteAssetInfor> listSpriteAssetInfor;
}
