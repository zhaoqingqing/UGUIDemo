## 仓库说明

博客介绍：[uGUI练习 开篇](http://www.cnblogs.com/zhaoqingqing/p/3972596.html)

在2014年9月份使用Unity 4.6 Beta b18编写的示例，现使用Unity 5.3.5f1更新并完善示例 

## 文件夹说明

### uGUI

博客中ugui练习的工程

### HSVPicker(拾色器)

源地址：https://github.com/judah4/HSV-Color-Picker-Unity

![https://github.com/zhaoqingqing/UGUIDemo/blob/master/Doc/ColorPicker.gif](https://github.com/zhaoqingqing/UGUIDemo/blob/master/Doc/ColorPicker.gif)

### Quickmsg

基于UGUI和Dotween写的一个快速弹出提示信息的消息窗，路径：Asset/QuickMsg/ 见如下：

![https://github.com/zhaoqingqing/UGUIDemo/blob/master/Doc/quickmsg.gif](https://github.com/zhaoqingqing/UGUIDemo/blob/master/Doc/quickmsg.gif)

## 更多资料

Unity 教程：https://unity3d.com/cn/learn/tutorials/topics/user-interface-ui

Unity手册：https://docs.unity3d.com/Manual/UICanvas.html

Unity脚本手册：https://docs.unity3d.com/ScriptReference/UI.Button.html

官方的Unity Samples: UI [https://www.assetstore.unity3d.com/en/#!/content/25468](https://www.assetstore.unity3d.com/en/#!/content/25468)

## RoadMap

事件系统：更倾向于类似NGUI的UIEventLister封装



布局系统：





## UGUI插件库

### 内置特效

关于Position As UV1的使用，需要特定的shader（detail）和图片来起作用

可以参考：http://www.manew.com/blog-77510-2929.html

### Tween插件

https://github.com/luzexi/Unity3DuGUI-Toolkit

这个作者重写了和NGUI类似的Tween组件，给UGUI使用，UI_TweenColor，UI_TweenGroup，UI_TweenPosition，UI_TweenRotation，UI_TweenScale。

当然如果是经常使用，还是推荐dotween

### 其它

Text文字间距：http://blog.csdn.net/qq_26999509/article/details/51902551

Text彩虹字：http://blog.csdn.net/qq_26999509/article/details/51863098

Text文字渐变色：http://www.xuanyusong.com/archives/3471

Text 倒影效果： http://blog.csdn.net/qq_26999509/article/details/51884121

文字下划线：思路：生成一个新的Text 文字为____



基于BaseMeshEffect的更多扩展

https://docs.unity3d.com/ScriptReference/UI.BaseMeshEffect.html

更多的扩展：http://blog.csdn.net/u010019717/article/details/47393501

