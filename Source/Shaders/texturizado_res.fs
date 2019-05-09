#version 330 core

in vec2 our_uv;
out vec4 color;
uniform sampler2D ourTexture;

void main(){
	
	color = texture(ourTexture, our_uv);
	//color = vec4(0.3, 0.5, 0.4, 1.0);
}