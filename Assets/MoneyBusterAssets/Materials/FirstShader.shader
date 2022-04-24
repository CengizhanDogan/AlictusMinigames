// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/FirstShader"
{

	Properties{
		_SplatTex("Splat Map", 2D) = "white" {}
		[NoScaleOffset]_Texture1("Texture 1", 2D) = "white" {}
		[NoScaleOffset]_Texture2("Texture 2", 2D) = "white" {}
	}
		SubShader{
			Pass{
				CGPROGRAM

				#pragma vertex MyVertexProgram
				#pragma fragment MyFragmentProgram

				#include "UnityCG.cginc"
		sampler2D _SplatTex;
		float4 _SplatTex_ST;
	    sampler2D _Texture1, _Texture2;

	            struct VertexData {
	            	float4 position : POSITION;
	            	float2 uv : TEXCOORD0;
	            };

				struct Interpolators {
					float4 position : SV_POSITION;
					float2 uv : TEXCOORD0;
					float2 uvSplat : TEXCOORD1;
				};

				Interpolators MyVertexProgram(VertexData v) {
					Interpolators i;
					i.position = UnityObjectToClipPos(v.position);
					i.uv = TRANSFORM_TEX(v.uv, _SplatTex);
					i.uvSplat = v.uv;
					return i;
				}

				float4 MyFragmentProgram(Interpolators i) : SV_TARGET{
				float4 splat = tex2D(_SplatTex, i.uvSplat);
				return
					tex2D(_Texture1, i.uv) * splat.r +
					tex2D(_Texture2, i.uv) * (1 - splat.r);
				}

				ENDCG
	}
	}
}
