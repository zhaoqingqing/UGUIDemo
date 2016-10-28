using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 数学知识：Mathf.Pow(2, 4)：2的4次方
/// </summary>
public class DIYTest : MonoBehaviour
{
    public List<Vector3> TriangleList = new List<Vector3>() { new Vector3(0, 0, 0), new Vector3(1, 0, -1), new Vector3(-1, 0, -1), new Vector3(2, 0, -2), new Vector3(-2, 0, -2) };
    public int Count = 5;
    private List<GameObject> NPCList = new List<GameObject>();
    int[] evenArry = new int[] { 0, 1, 2, 4, 6 };
    int[] oddArry = new int[] { 0, 1, 3, 5, 7 };
    // Use this for initialization
    void Start()
    {
        //TestPrint(evenArry);
        //TestPrint(oddArry);
        Debug.LogFormat("pow1:{0},pow2:{1} ,{2}  ,{3}", Mathf.Pow(2, 3), Mathf.Pow(-1, 0), Mathf.Pow(-1, 1), Mathf.Pow(-1, 2));
    }

    public void TestPrint(int[] array)
    {
        StringBuilder sb = new StringBuilder();
        for (int idx = 0; idx < array.Length; idx++)
        {
            sb.AppendFormat("{0},", array[idx] % 2);
        }
        Debug.Log(sb.ToString());
    }

    private float btnSpace = 20;
    // OnGUI is called for rendering and handling GUI events
    public void OnGUI()
    {
        if (GUILayout.Button("生成"))
        {
            Create();
        }
        GUILayout.Space(btnSpace);

        if (GUILayout.Button("三角形"))
        {
            Triangle();
        }
        if (GUILayout.Button("三角形-2"))
        {
            SortTriangle();
        }
        GUILayout.Space(btnSpace);

        if (GUILayout.Button("圆形"))
        {
            Circle();
        }
        if (GUILayout.Button("圆形-2"))
        {
            SortCircle();
        }
        GUILayout.Space(btnSpace);

        if (GUILayout.Button("圆弧形"))
        {
            SortArc();
        }
    }

    public void Clear()
    {
        if (NPCList.Count <= 0) return;
        var max = NPCList.Count;
        for (int idx = 0; idx < max; idx++)
        {
            Destroy(NPCList[idx]);
        }
        NPCList.Clear();
    }

    public void Create()
    {
        Clear();
        for (int i = 0; i < Count; i++)
        {
            NPCList.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        }
    }

    /// <summary>
    /// 三角排列
    /// </summary>
    public void Triangle()
    {
        Create();
        for (int i = 0; i < Count; i++)
        {
            int j = i / 5;
            int k = i % 5;

            NPCList[i].transform.localPosition = new Vector3(5 * j, 0, 0) + TriangleList[k];
            NPCList[i].transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public float TriangleX = 1;
    public float TriangleZ = 1;
    public Vector3 StartPos = Vector3.zero;

    /// <summary>
    /// 等腰三角形
    /// 给定中心坐标,横间距,纵间距
    /// 假设以(0,0)为初始点,横纵间距都为1,排列如下：(-3,3),(-2,2),(-1,1),(0,0),(1,1),(2,2),(3,3)
    /// 开口向上
    /// </summary>
    public void SortTriangle()
    {
        Create();
        int evenCount = 1;
        int oddCount = 1;
        //从1开始,先右再左
        for (int idx = 1; idx <= Count; idx++)
        {
            float posX = 0;
            float posZ = 0;
            int relIdx = idx - 1;
            if (idx > 1)
            {
                var isEven = idx % 2;
                //奇数和偶数的Z改变，开口方向就会改变
                if (isEven == 0) //偶数
                {
                    posX = evenCount * TriangleX;
                    posZ = -evenCount * TriangleZ;
                    evenCount++;
                }
                else  //奇数
                {
                    posX = -oddCount * TriangleX;
                    posZ = -oddCount * TriangleZ;
                    oddCount++;
                }
                NPCList[relIdx].transform.localPosition = new Vector3(posX, 0, posZ);
            }
            else
            {
                NPCList[relIdx].transform.localPosition = StartPos;
            }

            NPCList[relIdx].transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public float Angle = 30;//弧度？角度?
    public float DistanceX = 3;//半径?控制x之间的间距，系数

    /// <summary>
    /// 圆弧排列
    /// 已知中心点坐标,半径,弧度,将多个坐标排列
    /// 圆心和半径是变化的
    /// 开口向下
    /// </summary>
    public void Circle()
    {
        Create();
        float radius = DistanceX * (Count / Angle + 1);
        for (int idx = 0; idx < Count; idx++)
        {
            float angle = Mathf.Pow(-1, idx) * (Angle / (Count / Angle + 1)) / 180 * Mathf.PI * ((idx + 1) / 2);

            float posX = radius * Mathf.Sin(angle);
            float posZ = -radius * (1 - Mathf.Cos(angle));//开口朝向
            Debug.LogFormat("angle:{0} ,sin:{1} ,cos:{2},x:{3} ,z:{4} \r{5}", angle, Mathf.Sin(angle), Mathf.Cos(angle), posX, posZ,radius);

            NPCList[idx].transform.localPosition = new Vector3(posX, 0, posZ);
            NPCList[idx].transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public float circleRadius = 3;//半径
    public Vector3 circleCenterPos = Vector3.zero;//圆心坐标

    /// <summary>
    /// 圆形排列
    /// 已知中心点坐标,半径,将多个坐标排列成圆
    /// 开口向下
    /// </summary>
    public void SortCircle()
    {
        Create();

        List<float> angles = new List<float>();
        float maxAngle = 360.0f;
        //小于指定数量，能排的最大角度
        if (Count <= 6)
        {
            maxAngle = 180.0f;
        }
        float angleP = maxAngle / (float)Count;//求平均值
        for (int idx = 1; idx <= Count; idx++)
        {
            angles.Add(angleP * (float)idx);
        }
        Debug.LogFormat("circleCenterPos:{0},{1}", circleCenterPos.x, circleCenterPos.z);//0,-3
        /**
        http://www.zybang.com/question/744080e079e4533e514b258daba45df7.html
        弧度*~=180*角度,所以角度=(弧度*3.14)/180
        公式 (x-a)平方+(y-b)平方=半径 平方 :其它(a,b)为圆心坐标 ,则x=a+r*cosO y=b+r*sinO
        */
        for (int idx = 0; idx < Count; idx++)
        {
            //根据圆的公式求任意点的坐标
            float posX = circleCenterPos.x + circleRadius * Mathf.Cos(angles[idx] * Mathf.PI / 180.0f);
            //z +- 可改变开口方向
            float posZ = circleCenterPos.z - circleRadius * Mathf.Sin(angles[idx] * Mathf.PI / 180.0f);
            Debug.LogFormat("{0} =>{1}  {2},{3}", idx, angles[idx], posX, posZ);
            NPCList[idx].transform.localPosition = new Vector3(posX, 0, posZ);
            NPCList[idx].transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public float 弧长 = 2.0f;
    public float 角度 = 20.0f;
    /// <summary>
    /// 圆弧排列
    /// 已知每两个坐标间距,求半径，夹角,将多个坐标排列成圆弧
    /// 开口向下
    /// </summary>
    public void SortArc()
    {
        Create();
        float radius = 弧长 * 180.0f / (角度 * Mathf.PI);
        /**
        弧度*PI=180*角度,所以角度=(弧度*PI)/180
        弧长=(角度数*PI*r)/180 即r=弧长*180/(角度*PI）
        已知半径，圆心，可以求出任意角度的坐标值
        */
        for (int idx = 0; idx < Count; idx++)
        {
       
            //根据圆的公式求任意点的坐标
            float posX = circleCenterPos.x + radius * Mathf.Cos(角度 * Mathf.PI / 180.0f) * idx;
            float posZ = circleCenterPos.z + radius * Mathf.Sin(角度 * Mathf.PI / 180.0f) * idx;
            Debug.LogFormat("{0} =>{1}  {2},{3}", idx, 角度, posX, posZ);
            NPCList[idx].transform.localPosition = new Vector3(posX, 0, posZ);
            NPCList[idx].transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
