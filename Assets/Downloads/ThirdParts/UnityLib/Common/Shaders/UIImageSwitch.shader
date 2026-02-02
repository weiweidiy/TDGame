Shader "UI/UIImageSwitch"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _MainTex2 ("MainTex2", 2D) = "white" {}
       
        _Color ("Tint", Color) = (1,1,1,1)
        _Slider ("Slider", Range(0,1)) = 0
        
        _RotAng("Angle",range(0,360))= 0
        _RangeMax("RangeMax",Float)= 1.5
        _RangeMin("RangeMin",Float)= -0.5
        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
 
        _ColorMask ("Color Mask", Float) = 15
 
        [Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
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
            "RenderPipeline" = "UniversalPipeline"
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

           HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
           
            #include "UnityCG.cginc"
 
            #pragma multi_compile_local _ UNITY_UI_CLIP_RECT
            #pragma multi_compile_local _ UNITY_UI_ALPHACLIP
 
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
                float2 texcoord2  : TEXCOORD3;
                float4 worldPosition : TEXCOORD1;
                half4  mask : TEXCOORD2;
                UNITY_VERTEX_OUTPUT_STEREO
            };
 
            sampler2D _MainTex2;	
            float4 _MainTex2_ST;
            sampler2D _MainTex;
            fixed4 _Color;
            fixed4 _TextureSampleAdd;
            float4 _ClipRect;
            float4 _MainTex_ST;
            float _UIMaskSoftnessX;
            float _UIMaskSoftnessY;
            float _Slider;
            float _RangeMax;
            float _RangeMin;
            float _RotAng;
 
            v2f vert(appdata_t v)
            {
                v2f OUT;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
                float4 vPosition = UnityObjectToClipPos(v.vertex);
                OUT.worldPosition = v.vertex;
                OUT.vertex = vPosition;
 
                float2 pixelSize = vPosition.w;
                pixelSize /= float2(1, 1) * abs(mul((float2x2)UNITY_MATRIX_P, _ScreenParams.xy));
 
                float4 clampedRect = clamp(_ClipRect, -2e10, 2e10);
                float2 maskUV = (v.vertex.xy - clampedRect.xy) / (clampedRect.zw - clampedRect.xy);
                OUT.texcoord = TRANSFORM_TEX(v.texcoord.xy, _MainTex);
                OUT.texcoord2 = TRANSFORM_TEX(v.texcoord.xy, _MainTex2);
                OUT.mask = half4(v.vertex.xy * 2 - clampedRect.xy - clampedRect.zw, 0.25 / (0.25 * half2(_UIMaskSoftnessX, _UIMaskSoftnessY) + abs(pixelSize.xy)));
 
                OUT.color = v.color * _Color;
                return OUT;
            }

            float Remap(float x, float t1, float t2, float s1, float s2)
            {
                float val = (x - s1)/(s2-s1) * (t2- t1) + t1;;
                return val;
            }
 
            fixed4 frag(v2f IN) : SV_Target
            {
                half4 _mainTexColor = tex2D(_MainTex, IN.texcoord);
                half4 _mainTex2Color = tex2D(_MainTex2, IN.texcoord2);
                
                // float2 uv = IN.texcoord;
                float2 cUV = IN.texcoord - float2(0.5, 0.5);
                float rad = 6.283184 * _RotAng / 360 ;
                float2x2 rotMatrix = float2x2(cos(rad),-sin(rad),sin(rad),cos(rad));
                cUV = mul(rotMatrix,cUV);
                cUV += float2(0.5,0.5);
                float lp = Remap(_Slider,_RangeMin,_RangeMax,0,1);
                float4 c = cUV.x < lp ? _mainTex2Color : _mainTexColor;
                half4 color = IN.color * (c* c.a + c*(1.0- c.a) + _TextureSampleAdd);
                c= c*color;
                c.a = color.a;
                #ifdef UNITY_UI_CLIP_RECT
                half2 m = saturate((_ClipRect.zw - _ClipRect.xy - abs(IN.mask.xy)) * IN.mask.zw);
                color.a *= m.x * m.y;
                c.a = color.a;
                #endif
 
                #ifdef UNITY_UI_ALPHACLIP
                clip (color.a - 0.001);
                #endif
                return c;
            }
         ENDHLSL
        }
    }

}