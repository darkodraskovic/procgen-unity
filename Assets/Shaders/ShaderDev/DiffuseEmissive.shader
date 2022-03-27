Shader "Draskovic/DiffuseEmissive"
{
    Properties
    {
        _myDiffuse("Diffuse texture", 2D) = "white" {}
        _myEmissive("Emissive texture", 2D) = "black" {}
        _myEmissiveRange ("Emissive Range", Range(0,1)) = .5
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _myDiffuse;
        sampler2D _myEmissive;
        half _myEmissiveRange;

        struct Input
        {
            float2 uv_myDiffuse;
            float2 uv_myEmissive;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Albedo = (tex2D(_myDiffuse, IN.uv_myDiffuse)).rgb;
            o.Emission = (tex2D(_myEmissive, IN.uv_myEmissive) * _myEmissiveRange).rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
