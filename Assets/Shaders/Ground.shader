Shader "Custom/Ground"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _GrassTex("Grass", 2D) = "white" {}
        _GroundTex("Ground", 2D) = "white" {}
        _HeightMap("Heightmap", 2D) = "white" {}
        _Transition("Transition", Range(0.01,100)) = 1
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _GrassTex;
        sampler2D _GroundTex;
        sampler2D _HeightMap;

        struct Input
        {
            float2 uv_GrassTex;
            float2 uv_GroundTex;
            float2 uv_HeightMap;
        };

        float _Transition;
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        float func(float t, float height)
        {
            return 1 / (1 + exp(t * height));
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float height = func(_Transition, tex2D(_HeightMap, IN.uv_HeightMap) - 0.5);
            float4 c =  lerp(tex2D(_GroundTex, IN.uv_GroundTex), tex2D(_GrassTex, IN.uv_GrassTex), height)* _Color;
            
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
