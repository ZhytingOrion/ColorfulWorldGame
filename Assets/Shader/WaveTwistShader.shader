// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33394,y:32704,varname:node_9361,prsc:2|alpha-2386-OUT,refract-355-OUT;n:type:ShaderForge.SFN_Tex2d,id:8221,x:32181,y:32908,varname:_node_8221,prsc:2,ntxv:0,isnm:False|UVIN-126-OUT,TEX-3896-TEX;n:type:ShaderForge.SFN_Append,id:6548,x:32684,y:32831,varname:node_6548,prsc:2|A-1976-R,B-1976-G;n:type:ShaderForge.SFN_Multiply,id:1593,x:32938,y:32954,varname:node_1593,prsc:2|A-6548-OUT,B-370-OUT,C-3397-OUT,D-961-A;n:type:ShaderForge.SFN_Slider,id:3397,x:32345,y:33105,ptovrint:False,ptlb:node_3397,ptin:TwistRatio,varname:TwistRatio,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_VertexColor,id:961,x:32752,y:32600,varname:node_961,prsc:2;n:type:ShaderForge.SFN_Vector1,id:2386,x:32998,y:32868,varname:node_2386,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2dAsset,id:3896,x:31871,y:32855,ptovrint:False,ptlb:node_3896,ptin:_node_3896,varname:_node_3896,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:9663,x:30956,y:33037,varname:node_9663,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:6435,x:30986,y:33203,varname:time,prsc:2;n:type:ShaderForge.SFN_Slider,id:2798,x:30953,y:33561,ptovrint:False,ptlb:node_2798,ptin:_node_2798,varname:_node_2798,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:9405,x:32159,y:32716,varname:_node_9405,prsc:2,ntxv:0,isnm:False|UVIN-5018-OUT,TEX-3896-TEX;n:type:ShaderForge.SFN_ComponentMask,id:1976,x:32431,y:32739,varname:node_1976,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-4829-OUT;n:type:ShaderForge.SFN_Multiply,id:4829,x:32358,y:32581,varname:node_4829,prsc:2|A-9405-RGB,B-8221-RGB,C-3743-OUT;n:type:ShaderForge.SFN_Vector1,id:3743,x:32358,y:32849,varname:node_3743,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:370,x:32575,y:32999,varname:node_370,prsc:2|A-9405-A,B-8221-A;n:type:ShaderForge.SFN_Distance,id:8916,x:32187,y:33393,varname:node_8916,prsc:2|A-9663-UVOUT,B-2887-OUT;n:type:ShaderForge.SFN_Vector2,id:2887,x:32154,y:33525,varname:node_2887,prsc:2,v1:0.5,v2:0.5;n:type:ShaderForge.SFN_OneMinus,id:7243,x:32442,y:33453,varname:node_7243,prsc:2|IN-8916-OUT;n:type:ShaderForge.SFN_RemapRange,id:2286,x:32638,y:33349,varname:node_2286,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-7243-OUT;n:type:ShaderForge.SFN_Clamp01,id:1013,x:32830,y:33366,varname:node_1013,prsc:2|IN-2286-OUT;n:type:ShaderForge.SFN_Multiply,id:355,x:33123,y:33151,varname:node_355,prsc:2|A-1593-OUT,B-1013-OUT;n:type:ShaderForge.SFN_Append,id:8270,x:31547,y:33695,varname:node_8270,prsc:2|A-6106-OUT,B-8627-OUT;n:type:ShaderForge.SFN_Vector1,id:6106,x:31374,y:33679,varname:node_6106,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:8627,x:31374,y:33739,varname:node_8627,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:1343,x:31732,y:33593,varname:node_1343,prsc:2|A-6435-T,B-8270-OUT,C-2798-OUT;n:type:ShaderForge.SFN_Add,id:126,x:31961,y:33366,varname:node_126,prsc:2|A-9663-UVOUT,B-1343-OUT;n:type:ShaderForge.SFN_Append,id:3644,x:31317,y:32861,varname:node_3644,prsc:2|A-3916-OUT,B-1065-OUT;n:type:ShaderForge.SFN_Vector1,id:3916,x:31105,y:32829,varname:node_3916,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:1065,x:31111,y:32905,varname:node_1065,prsc:2,v1:-1;n:type:ShaderForge.SFN_Multiply,id:1193,x:31505,y:32815,varname:node_1193,prsc:2|A-6435-TSL,B-3644-OUT,C-2798-OUT;n:type:ShaderForge.SFN_Add,id:5018,x:31665,y:32758,varname:node_5018,prsc:2|A-9663-UVOUT,B-1193-OUT;proporder:3397-3896-2798;pass:END;sub:END;*/

Shader "UI/WaveTwist" {
	Properties{
		_MainTex("Main Texture", 2D) = "white"{}
		_TwistRatio("Helix Ratio",Float) = 1
		_Angle("Angle", Float) = 0
		[HideInInspector]_Cutoff("Alpha cutoff", Range(0,1)) = 0.5
	}
	
	SubShader{
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}
		GrabPass{ }
		Pass {
			Name "FORWARD"
			Tags {
				"LightMode" = "ForwardBase"
			}
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Off
			ZWrite Off
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			#pragma only_renderers d3d9 d3d11 glcore gles n3ds wiiu metal
			#pragma target 3.0
			uniform sampler2D _MainTexture;
			uniform sampler2D _GrabTexture;
			uniform float _TwistRatio;
			uniform float _Angle;
			struct VertexInput {
				float4 vertex : POSITION;
				float2 texcoord0 : TEXCOORD0;
				float4 vertexColor : COLOR;
			};
			struct VertexOutput {
				float4 pos : SV_POSITION;
				fixed2 uv0 : TEXCOORD0;
				fixed4 vertexColor : COLOR;
				float4 projPos : TEXCOORD1;
			};
			VertexOutput vert(VertexInput v) {
				VertexOutput o = (VertexOutput)0;
				o.vertexColor = v.vertexColor;
				o.uv0 = v.texcoord0;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.projPos = ComputeScreenPos(o.pos);
				return o;
			}
			fixed4 frag(VertexOutput i) : COLOR {
				fixed Ratio = _TwistRatio * _Angle;
				fixed distanceRatio = saturate(0.5 - distance(i.uv0, fixed2(0.5, 0.5)));
				fixed2 sceneUVs = (i.projPos.xy / i.projPos.w) + fixed2(Ratio * cos(_Angle), Ratio * sin(_Angle)) * (0.25 - abs(0.25 - distanceRatio)) * 4; //(1 - saturate(0.5 - distance(i.uv0, fixed2(0.5,0.5))) * 2);//saturate(((1.0 - distance(i.uv0, fixed2(0.5, 0.5)))*2.0 + -1.0));
				fixed4 sceneColor = tex2D(_GrabTexture, sceneUVs);
				sceneColor.a = 1;
				return sceneColor;
			}
			ENDCG
		}
	}
}
