Shader "Custom/MySquareShader"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _Raid("Radius", Range(0, 100)) = 0

        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255

        _ColorMask ("Color Mask", Float) = 15

        [Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0

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

        Stencil
        {
            Ref [_Stencil]
            Comp [_StencilComp]
            Pass [_StencilOp]
            ReadMask [_StencilReadMask]
            WriteMask [_StencilWriteMask]
        }

        Cull Off
        Lighting Off
        ZWrite Off
        ZTest [unity_GUIZTestMode]
        Blend SrcAlpha OneMinusSrcAlpha
        ColorMask [_ColorMask]

        Pass
        {
            Name "Default"
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0

            #include "UnityCG.cginc"
            #include "UnityUI.cginc"

            #pragma multi_compile __ UNITY_UI_CLIP_RECT
            #pragma multi_compile __ UNITY_UI_ALPHACLIP


            float _Raid;

            struct appdata_t
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                float2 texcoord : TEXCOORD0;
                float4 worldPosition : TEXCOORD1;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            sampler2D _MainTex;
            fixed4 _Color;
            fixed4 _TextureSampleAdd;
            float4 _ClipRect;
            float4 _MainTex_ST;

            float2 _Center;
            float _SliderX;
            float _SliderY;

            v2f vert(appdata_t v)
            {
                v2f OUT;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
                OUT.worldPosition = v.vertex;
                OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);

                OUT.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);

                OUT.color = v.color * _Color;
                return OUT;
            }

            //水平圆角矩形
            fixed checkInCircleRectHorizontal(float4 worldPosition)
            {
                float4 rec1Pos = float4(_Center.x - _SliderX / 2 - _Raid, _Center.y - _SliderY / 2,
                                        _Center.x + _SliderX / 2 + _Raid, _Center.y + _SliderY / 2);
                float4 rec2Pos = float4(_Center.x - _SliderX / 2 - 2 * _Raid, _Center.y - _SliderY / 2 + _Raid,
                                        _Center.x + _SliderX / 2 + 2 * _Raid, _Center.y + _SliderY / 2 - _Raid);
                fixed2 step1 = step(rec1Pos.xy, worldPosition.xy) * step(worldPosition.xy, rec1Pos.zw);
                fixed2 step2 = step(rec2Pos.xy, worldPosition.xy) * step(worldPosition.xy, rec2Pos.zw);
                fixed rec1 = step1.x * step1.y < 1 ? 0 : 1;
                fixed rec2 = step2.x * step2.y < 1 ? 0 : 1;
                fixed dis1 = distance(float2(_Center.x - _SliderX / 2 - _Raid, _Center.y + _SliderY / 2 - _Raid),
                                      worldPosition.xy) < _Raid
                                 ? 1
                                 : 0;
                fixed dis2 = distance(float2(_Center.x - _SliderX / 2 - _Raid, _Center.y - _SliderY / 2 + _Raid),
                                    worldPosition.xy) < _Raid
                               ? 1
                               : 0;
                fixed dis3 = distance(float2(_Center.x + _SliderX / 2 + _Raid, _Center.y + _SliderY / 2 - _Raid),
                                                       worldPosition.xy) < _Raid
                                                  ? 1
                                                  : 0;
                fixed dis4 = distance(float2(_Center.x + _SliderX / 2 + _Raid, _Center.y - _SliderY / 2 + _Raid),
  worldPosition.xy) < _Raid
                        ? 1
                        : 0;
                return (dis1 + dis2 + dis3 + dis4 + rec1 + rec2) > 0 ? 0 : 1;
            }


            fixed checkInCircleRectVectory(float4 worldPosition)
            {
                float4 rec1Pos = float4(_Center.x - _SliderX / 2, _Center.y - _SliderY / 2 - _Raid,
               _Center.x + _SliderX / 2, _Center.y + _SliderY / 2 + _Raid);
                float4 rec2Pos = float4(_Center.x - _SliderX / 2 + _Raid, _Center.y - _SliderY / 2 - 2 * _Raid,
                    _Center.x + _SliderX / 2 - _Raid,
                    _Center.y + _SliderY / 2 + 2 * _Raid);
                fixed2 step1 = step(rec1Pos.xy, worldPosition.xy) * step(worldPosition.xy, rec1Pos.zw);
                fixed2 step2 = step(rec2Pos.xy, worldPosition.xy) * step(worldPosition.xy, rec2Pos.zw);
                fixed rec1 = step1.x * step1.y < 1 ? 0 : 1;
                fixed rec2 = step2.x * step2.y < 1 ? 0 : 1;
                fixed dis1 = distance(float2(_Center.x + _SliderX / 2 - _Raid, _Center.y + _SliderY / 2 + _Raid),
                                    worldPosition.xy) < _Raid
                               ? 1
                               : 0;
                fixed dis2 = distance(float2(_Center.x - _SliderX / 2 + _Raid, _Center.y - _SliderY / 2 - _Raid),
                                                                            worldPosition.xy) < _Raid
                                                                            ? 1
                                                                            : 0;
                fixed dis3 = distance(float2(_Center.x + _SliderX / 2 - _Raid, _Center.y - _SliderY / 2 - _Raid),
     worldPosition.xy) < _Raid
                                                  ? 1
                                                  : 0;
                fixed dis4 = distance(float2(_Center.x - _SliderX / 2 + _Raid, _Center.y + _SliderY / 2 + _Raid),
               worldPosition.xy) < _Raid
          ? 1
          : 0;
                return (dis1 + dis2 + dis3 + dis4 + rec1 + rec2) > 0 ? 0 : 1;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                half4 color = (tex2D(_MainTex, IN.texcoord) + _TextureSampleAdd) * IN.color;

                #ifdef UNITY_UI_CLIP_RECT
                color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
                #endif

                #ifdef UNITY_UI_ALPHACLIP
                clip (color.a - 0.001);
                #endif
                //float2 dis = IN.worldPosition.xy - _Center.xy;
                //color.a *= (abs(dis.x)>_SliderX) || (abs(dis.y) > _SliderY);
                //color.rgb *= color.a;

                color.a = checkInCircleRectHorizontal(IN.worldPosition) == 0 ? 0 : color.a;

                //float uvX = abs(100 - 0.5);
                //float uvY = abs(100 - 0.5);

                //_Raid = 0.2;
                //uvX = max(0, uvX - (0.5 - _Raid));
                //uvY = max(0, uvY - (0.5 - _Raid));

                //color.a =  uvX * uvX + uvY * uvY > _Raid * _Raid ? 0 : 1;

                return color;
            }
            ENDCG
        }
    }
}