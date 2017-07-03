using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// Detail		:  自动绑定在MsgTemplate上，单个MsgTemplate的行为
/// Author		:  qingqing-zhao(569032731@qq.com)
/// CreateTime  :  #CreateTime#
/// </summary>
public class XUIMidMsgAnimator : MonoBehaviour
{
    public XUIMidMsg UICtrler;
    private Text msgLabel;
    private Image msgBackground;

    public void StartAnimate(string msgStr)
    {
        msgLabel = UnityHelper.GetChildComponent<Text>("Label", transform);
        msgBackground = UnityHelper.GetChildComponent<Image>("Background", transform);
        Debug.Assert(msgLabel);
        Debug.Assert(msgBackground);

        msgLabel.text = msgStr;

        StartCoroutine(MsgCoroutine());
    }

    public void StopAnimate()
    {
        StopAllCoroutines();

        // 清理残留动画
        foreach (Transform tween in gameObject.GetComponents<Transform>())
        {
            tween.transform.DOKill();
        }
    }

    // 出现动画
    IEnumerator MsgCoroutine()
    {
        //淡入
        MaskableGraphic[] graphics = this.GetComponentsInChildren<MaskableGraphic>();
        foreach (MaskableGraphic widget in graphics)
        {
            widget.color = new Color(widget.color.r, widget.color.g, widget.color.b, 0);
            var endColor = new Color(widget.color.r, widget.color.g, widget.color.b, 255);
            widget.DOFade(255, XUIMidMsg.FADE_TIME);
        }

        this.transform.localScale = new Vector3(0, 1, 0);
        
        //从小变大
        transform.DOScale(Vector3.one, XUIMidMsg.FADE_TIME);
  
        yield return new WaitForSeconds(XUIMidMsg.FADE_TIME);   // 等待淡入动画

        yield return new WaitForSeconds(XUIMidMsg.MSG_TIME);   // 等待显示时间

        UICtrler.m_WaitingMsgList.Remove(this);   //已经结束显示了

        yield return StartCoroutine(WaitMsgDelete());
    }

    //消失动画
    public IEnumerator WaitMsgDelete()
    {
        MaskableGraphic[] graphics = this.GetComponentsInChildren<MaskableGraphic>();
        foreach (MaskableGraphic widget in graphics) // 淡出
        {
            var endColor = new Color(widget.color.r, widget.color.g, widget.color.b, 0);
            widget.DOFade(0, XUIMidMsg.FADE_TIME);
        }

        var endPos = this.transform.localPosition + new Vector3(0, XUIMidMsg.MSG_HEIGHT, 0);
        transform.DOLocalMove(endPos, XUIMidMsg.FADE_TIME);
        yield return new WaitForSeconds(XUIMidMsg.FADE_TIME);  // 等待淡出动画
        StopAnimate();
        UICtrler.PoolDelete(this);
    }
}
