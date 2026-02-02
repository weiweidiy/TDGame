//using Chronos;
using UnityEngine;

public class ScrollUVController : MonoBehaviour
{
    /// <summary>
    /// 当前速度
    /// </summary>
    private float curSpeed;

    /// <summary>
    /// 目标速度
    /// </summary>
    public float targetSpeed;

    /// <summary>
    /// 当前材质
    /// </summary>
    Material _material;

    /// <summary>
    /// ui偏移
    /// </summary>
    float _uvX = 0f;

    // Start is called before the first frame update
    //Timeline m_TimeLine;

    void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
        //m_TimeLine = GetComponent<Timeline>();
    }

    private void Update()
    {
        //Debug.Assert(m_TimeLine != null, "没有找到timeline" +gameObject);
        float deltaTime = GetDeltaTime();
        deltaTime *= Time.timeScale;
        _uvX += deltaTime * curSpeed;
        SetUVX(_uvX);
    }

    /// <summary>
    /// 默认的系统自带流失时间
    /// </summary>
    /// <returns></returns>
    protected virtual float GetDeltaTime()
    {
        return Time.deltaTime; 
    }

    /// <summary>
    /// 设置uv数值
    /// </summary>
    /// <param name="uvX"></param>
    public virtual void SetUVX(float uvX)
    {
        _material.SetFloat("_UVX", uvX);
    }

    /// <summary>
    /// 设置移动速度，客户端通过设置当前速度值来控制
    /// </summary>
    /// <param name="speed"></param>
    public void SetSpeed(float speed)
    {
        this.curSpeed = speed;
    }

    /// <summary>
    /// 获取当前速度
    /// </summary>
    /// <returns></returns>
    public float GetSpeed()
    {
        return curSpeed;
    }

    /// <summary>
    /// 重置UV
    /// </summary>
    public void ResetUVX()
    {
        _uvX = 0f;
    }

    /// <summary>
    /// 设置材质
    /// </summary>
    /// <param name="tex"></param>
    public void SetTexture(Texture2D tex)
    {
        _material.SetTexture("_MainTexture", tex);
    }
}
