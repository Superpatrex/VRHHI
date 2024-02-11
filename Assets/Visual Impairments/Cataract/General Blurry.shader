Shader "VR/BlurEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurSize ("Blur Size", Range(0, 5)) = 2
        _Opacity ("Opacity", Range(0, 1)) = 1
    }
    
    SubShader
    {
        Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
        LOD 100

        Pass
        {
            ZTest Always Cull Off ZWrite Off
            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };
            
            sampler2D _MainTex;
            float _BlurSize;
            float _Opacity;
            
            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            fixed4 frag(v2f i) : SV_Target
            {
                float2 uvOffset = _BlurSize * (1 - 4 * (i.uv - 0.5) * (i.uv - 0.5));
                fixed4 col = tex2D(_MainTex, i.uv);
                
                for (int j = 0; j < 10; ++j)
                {
                    float scale = j / 10.0;
                    col += tex2D(_MainTex, i.uv + scale * uvOffset);
                    col += tex2D(_MainTex, i.uv - scale * uvOffset);
                }
                
                col /= 21.0;
                
                col.a *= _Opacity;
                
                return col;
            }
            ENDCG
        }
    }
}
