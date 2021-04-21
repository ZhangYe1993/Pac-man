Shader "Custom/Surface"
{
    //Properties block
    Properties
	{
	//start with underScore
		_Color("Color",Color) = (1,1,1,1)
	}
	SubShader
	{
		CGPROGRAM
		#pragma surface surf Lambert

		struct Input
		{
			//must have at lest one member
			float2 uv_MainTex;
		};

		//fixed4 ,half4 are called packed arrays;
		//还有float4 虽然不知道是什么意思；
		fixed4 _Color;

		void surf(Input IN, inout SurfaceOutput o)
		{
			o.Albedo = _Color.rgb;
		}
		ENDCG

	}

    FallBack "Diffuse"
}
