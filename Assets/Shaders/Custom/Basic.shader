Shader "Custom/Basic"
{
    Properties {
        _myColor ("MyColor", Color) = (0, 1, 1, 1)
        _myTex ("Example Texture", 2D) = "white" {}
        _myRange ("Example Range", Range(0,2)) = 1
        _myCube ("Example Cube", CUBE) = "" {}
    }

    SubShader {
        CGPROGRAM
            #pragma surface surf Lambert

            sampler2D _myTex;
            half _myRange;
            samplerCUBE _myCube;
            fixed4 _myColor;

            struct Input {
                float2 uv_myTex;
                float3 worldRefl;
            };
            
            void surf (Input IN, inout SurfaceOutput o) {
                o.Albedo = (tex2D(_myTex, IN.uv_myTex) * _myRange).rgb;
                o.Emission = texCUBE(_myCube, IN.worldRefl).rgb;                
            }
        ENDCG
    }

    Fallback "Diffuse"
}
