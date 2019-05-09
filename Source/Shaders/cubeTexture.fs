#version 330 core

in vec3 coordTexture;
out vec4 color;

uniform samplerCube skybox; // de 2d a samplerCube

void main()
{
    color = texture(skybox, coordTexture);
}