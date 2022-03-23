// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2827,x:33357,y:32550,varname:node_2827,prsc:2|emission-7899-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:6175,x:32131,y:32527,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_6175,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2314,x:32337,y:32527,varname:node_2314,prsc:2,ntxv:0,isnm:False|TEX-6175-TEX;n:type:ShaderForge.SFN_VertexColor,id:1591,x:32327,y:32689,varname:node_1591,prsc:2;n:type:ShaderForge.SFN_Fresnel,id:9549,x:32327,y:32906,varname:node_9549,prsc:2|EXP-8446-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8446,x:32140,y:32952,ptovrint:False,ptlb:FresnelValue,ptin:_FresnelValue,varname:node_8446,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Power,id:9709,x:32499,y:32968,varname:node_9709,prsc:2|VAL-9549-OUT,EXP-6711-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6711,x:32277,y:33105,ptovrint:False,ptlb:FresnelPower,ptin:_FresnelPower,varname:node_6711,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Add,id:7899,x:32903,y:32703,varname:node_7899,prsc:2|A-3677-RGB,B-6745-OUT;n:type:ShaderForge.SFN_Multiply,id:4898,x:32732,y:32958,varname:node_4898,prsc:2|A-1591-RGB,B-9709-OUT;n:type:ShaderForge.SFN_Color,id:3677,x:32635,y:32492,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_3677,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:6745,x:33048,y:32963,varname:node_6745,prsc:2|A-4898-OUT,B-8450-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8450,x:32732,y:33157,ptovrint:False,ptlb:FrenselIntensivity,ptin:_FrenselIntensivity,varname:node_8450,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.5;proporder:6175-8446-6711-3677-8450;pass:END;sub:END;*/

Shader "Custom/Opaque Fresnel" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _FresnelValue ("FresnelValue", Float ) = 1
        _FresnelPower ("FresnelPower", Float ) = 1
        _Color ("Color", Color) = (0,0,0,1)
        _FrenselIntensivity ("FrenselIntensivity", Float ) = 1.5
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma target 3.0
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _FresnelValue)
                UNITY_DEFINE_INSTANCED_PROP( float, _FresnelPower)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _FrenselIntensivity)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float _FresnelValue_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FresnelValue );
                float _FresnelPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FresnelPower );
                float _FrenselIntensivity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FrenselIntensivity );
                float3 emissive = (_Color_var.rgb+((i.vertexColor.rgb*pow(pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelValue_var),_FresnelPower_var))*_FrenselIntensivity_var));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
