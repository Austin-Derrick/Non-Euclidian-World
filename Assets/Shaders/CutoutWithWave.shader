// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/CutoutWithWave"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	_Frequency("Frequency", float) = 20
		_Speed("Speed", float) = 0.5
		_Amplitude("Amplitude", float) = 0.1
		_Axis("Axis", Vector) = (0.1, 1, 0.1)
		_Color("Axis", Color) = (0.23, 0.95, 0.33, 1)
	}
	SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		Lighting Off
		Cull Back
		ZWrite On
		ZTest Less
		
		Fog{ Mode Off }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				//float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 screenPos : TEXCOORD1;
				float2 uv : TEXCOORD0;

			};

			float _Frequency;
			float _Speed;
			float _Amplitude;
			float3 _Axis;

			float4 Unity_Combine_float(float R, float G, float B, float A)
			{
				return float4(R, G, B, A);
			}

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.screenPos = ComputeScreenPos(o.vertex);

				float time = _Speed * _Time * 200; // 200 = Magic number that aligns our speed with the shadergraph variant of this shader. :(

				// Wave
				float4 sineWave = sin(time + v.vertex * _Frequency) * _Amplitude;

				// Wave enabled per axis
				float3 waveX = sineWave * _Axis.r;
				float3 waveY = sineWave * _Axis.g;
				float3 waveZ = sineWave * _Axis.b;

				// Composition
				float4 modifiedVerts = Unity_Combine_float(v.vertex.x + waveX, v.vertex.y + waveY, v.vertex.z + waveZ, 1);

				o.vertex = UnityObjectToClipPos(modifiedVerts);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target
			{
				i.screenPos /= i.screenPos.w;
				fixed4 col = tex2D(_MainTex, float2(i.screenPos.x, i.screenPos.y));
				
				return col;
			}
			ENDCG
		}
	}
}
