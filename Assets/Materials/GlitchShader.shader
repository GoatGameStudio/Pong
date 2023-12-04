Shader"Custom/GlitchShader" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _GlitchStrength ("Glitch Strength", Range (0, 1)) = 0.1
        _GlitchFrequency ("Glitch Frequency", Range (0, 1)) = 0.1
    }

CGINCLUDE
#include "UnityCG.cginc"
    CGINCLUDE

struct appdata
{
    float4 vertex : POSITION;
    float3 normal : NORMAL;
};

struct v2f
{
    float4 pos : POSITION;
    float4 color : COLOR;
};

sampler2D _MainTex;
float _GlitchStrength;
float _GlitchFrequency;

v2f vert(appdata v)
{
    v2f o;
    o.pos = UnityObjectToClipPos(v.vertex);
    o.color = float4(1, 1, 1, 1);
    return o;
}

fixed4 frag(v2f i) : COLOR
{
    float2 uv = i.pos.xy / i.pos.w;
    fixed4 col = tex2D(_MainTex, uv);
    col.rgb = col.rgb * i.color.rgb;

        // Add glitch effect
    float glitch = sin(_Time.y * _GlitchFrequency) * _GlitchStrength;
    float2 offset = (fract(uv.y * 10) < glitch) ? float2(0, 0) : float2(0, 0);
    col.rgb = tex2D(_MainTex, uv + offset).rgb;

    return col;
}
}
