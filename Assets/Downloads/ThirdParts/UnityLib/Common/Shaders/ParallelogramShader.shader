Shader "Custom/MyParallelogramShader"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _Skew ("Skew", Float) = 0
        _Center("Center",vector) = (0,0,0,0)
        _SliderX("SliderX",Range(0,1500)) = 1500
        _SliderY("SliderY",Range(0,1500)) = 1500
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            Name "Default"
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0

            #include "UnityCG.cginc"
            #include "UnityUI.cginc"

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float2 texcoord  : TEXCOORD0;
                float4 worldPosition : TEXCOORD1;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            sampler2D _MainTex;
            fixed4 _Color;
            float2 _Center;
            float _SliderX;
            float _SliderY;
            float _Skew;
            float4 _MainTex_ST;

            v2f vert(appdata_t v)
            {
                v2f OUT;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
                OUT.worldPosition = v.vertex;
                OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);
                OUT.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                OUT.color = v.color *_Color;
                return OUT;
            }

            // 判断点是否在平行四边形内
            fixed checkInParallelogram(float4 worldPosition)
            {
                // 将世界坐标转换为以中心为原点的局部坐标
                float2 local = worldPosition.xy - _Center.xy;

                // 计算Y轴偏移
                float skewOffset = local.x * _Skew;

                // 判断是否在平行四边形内
                if (abs(local.x) <= _SliderX / 2 && abs(local.y - skewOffset) <= _SliderY / 2)
                    return 1;
                return 0;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                half4 color = tex2D(_MainTex, IN.texcoord) * IN.color;
                //color.a = checkInParallelogram(IN.worldPosition) == 1 ? 0.9 : 0;
                color.a = checkInParallelogram(IN.worldPosition) == 1 ? 0 : 0.9;
                return color;
            }
        ENDCG
        }
    }
}