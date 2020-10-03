Shader "Custom/X Ray" {
	Properties{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	_BumpMap("Normal", 2D) = "bump" {}
	_RimColor("RimColor", Color) = (1, 1, 0, 1)
		_RimPower("RimPower", Range(0, 8)) = 3.0
	}
		SubShader{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf Lambert alpha:blend

		// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0

		sampler2D _MainTex;
	sampler2D _BumpMap;
	float4 _RimColor;
	float _RimPower;

	struct Input {
		float2 uv_BumpMap;
		float3 viewDir;
	};

	half _Glossiness;
	half _Metallic;
	fixed4 _Color;

	// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
	// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
	// #pragma instancing_options assumeuniformscaling
	UNITY_INSTANCING_BUFFER_START(Props)
		// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf(Input IN, inout SurfaceOutput o) {
		o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
		half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
		float4 c = _RimColor * pow(rim, _RimPower);

		o.Alpha = c.a;
		o.Emission = c.rgb * 2;
	}
	ENDCG
	}
		FallBack "Diffuse"
}
