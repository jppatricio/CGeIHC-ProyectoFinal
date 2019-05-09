#version 330 core

in vec3 our_color;
in vec3 our_normal;
in vec3 fragPos;
out vec4 color;

struct PositionalLight{
    vec3 position;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};
//ADDED
struct Material{
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    float shininess;
};
//----

uniform vec3 viewPos; 
uniform PositionalLight light;
//ADDED
uniform Material material;

void main(){

    // Iluminacion ambiental //ADDED MATERIAL
    vec3 ambient = light.ambient * material.ambient;
    // Iluminacion difusa
    vec3 lightDir = normalize(fragPos - light.position);
    float diff = max(dot(our_normal, -lightDir), 0.0);
    // Iluminacion specular
    vec3 r = reflect(lightDir, our_normal);
    vec3 viewDir = normalize(viewPos - fragPos);
    float spec = pow( max(dot(r , viewDir), 0.0), material.shininess);

    vec3 result = ambient + diff * light.diffuse * material.diffuse + spec * light.specular * material.specular;

    color = vec4(result, 1.0);

}