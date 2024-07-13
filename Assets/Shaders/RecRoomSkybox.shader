Shader "Skybox/Rec Room Skybox"
{
	Properties
	{
		[HDR]_SkyTop("SkyTop", Color) = (1, 1, 1, 0)
		[HDR]_SkyBottom("SkyBottom", Color) = (1, 1, 1, 0)
		[Space]
		[HDR]_GroundTop("GroundTop", Color) = (1, 1, 1, 0)
		[HDR]_GroundBottom("GroundBottom", Color) = (1, 1, 1, 0)
		[Space]
		[HDR]_HorizonColor("HorizonColor", Color) = (0.67, 0.78, 0.99, 0)
		_HorizonSize("HorizonSize", Range(0, 1.5)) = 0.5
		_HorizonStrength("HorizonStrength", Range(0, 2)) = 0.5
		[Space]
		[HDR]_SunColor("SunColor", Color) = (0.67, 0.78, 0.1, 0)
		_DiscSize("DiscSize", Range(0, 0.5)) = 0.1
		[Space]
		[HDR]_GlowColor("GlowColor", Color) = (0.67, 0.78, 0.1, 0)
		_SunGlowSize("GlowSize", Range(0, 3)) = 0.5
		_GlowStrength("GlowStrength", Range(0, 2)) = 0.5
		_GlowHorizon("GlowHorizon", Range(0, 2)) = 0.8
		[Space]
		_SunClipOffset("SunClipOffset", Range(0.03, 2)) = 0.03
		[HideInInspector]_SunDir("SunDir", Vector) = (0.7071, 0.7071, 0.7071, 0.0)
	}

	SubShader
	{
		Tags { "Queue" = "Background" "RenderType" = "Background" "PreviewType" = "Skybox" }
		Cull Off ZWrite Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct VertIn
			{
				float4 vertex : POSITION;
			};

			float4 _SkyBottom;
			float4 _SkyTop;
			float4 _GroundTop;
			float4 _GroundBottom;
			float4 _HorizonColor;
			float _HorizonStrength;
			float4 _SunColor;
			float4 _GlowColor;
			float _SunStrength;
			float _SunGlowSize;
			float _GlowStrength;
			float _GlowHorizon;
			float _HorizonSize;
			float _SunClipOffset;
			float _DiscSize;
			float4 _SunDir;

			struct VertOut
			{
				float4 position : SV_POSITION;
				float3 worldDir : TEXCOORD0;
				float3 backGroundColor : TEXCOORD1;
				float3 backGroundColor2 : TEXCOORD2;
				float2 backgroundBlendAndGlow : TEXCOORD3;
			};

			VertOut vert(VertIn v)
			{
				VertOut o;

				o.position = UnityObjectToClipPos(v.vertex);
				o.worldDir = normalize(v.vertex.xyz);

				float horizonDist = abs(v.vertex.y);
				o.backgroundBlendAndGlow.x = (1.0f - horizonDist);

				if (v.vertex.y >= 0)
				{
					o.backGroundColor = _SkyTop.rgb;
					// Horizon color
					float horizon = 1.0f - saturate(horizonDist / _HorizonSize);
					o.backGroundColor2 = lerp(_SkyBottom.rgb, _HorizonColor.rgb, saturate(horizon * horizon * _HorizonStrength));
					o.backgroundBlendAndGlow.y = _GlowStrength;
				}
				else
				{
					o.backGroundColor = _GroundBottom.rgb;
					o.backGroundColor2 = _GroundTop.rgb;
					o.backgroundBlendAndGlow.y = saturate((_SunDir.y + _DiscSize + _SunClipOffset) / (_SunGlowSize)) * _GlowStrength;
				}

				return o;
			}

			float4 frag(VertOut i) : SV_Target
			{
				float aboveHorizon = saturate((i.worldDir.y + _SunClipOffset) * 30.0f);
				float sunEdgeDist = saturate(length(_SunDir.xyz - i.worldDir) - _DiscSize);

				// Background color
				float3 color = lerp(i.backGroundColor.rgb, i.backGroundColor2.rgb, i.backgroundBlendAndGlow.x * i.backgroundBlendAndGlow.x);

				// Sun glow
				float sunHorizonDist = 1.0f - saturate(abs(_SunDir.y) / (_SunGlowSize));
				float horizonDist = abs(i.worldDir.y);
				horizonDist = saturate(horizonDist / (_SunGlowSize));
				horizonDist = 1.0f - (horizonDist*horizonDist);
				float glowSize = _SunGlowSize * (1.0f + sunHorizonDist * horizonDist * _GlowHorizon);

				float sunGlow = 1.0f - saturate(sunEdgeDist / glowSize);
				float3 glowColor = lerp(color, _GlowColor.rgb, sunGlow * sunGlow * i.backgroundBlendAndGlow.y);

				// Sun disc
				if (_DiscSize > 0.0f)
				{
					float sunDiscVal = 1.0f - saturate(sunEdgeDist * 10.0f);
					sunDiscVal *= sunDiscVal * sunDiscVal;
					color = lerp(glowColor, _SunColor.rgb, sunDiscVal * aboveHorizon);
				}
				else
				{
					color = glowColor;
				}

				return float4(color*color, 1);
			}
			ENDCG
		}
	}

	CustomEditor "UnityEditor.Rendering.Universal.ShaderGUI.RecRoomSkyboxShader"
}