
#version 330 core

in vec3 our_color;
//added
in vec3 our_normal;
in vec3 fragPos;

out vec4 color;

//added
struct PositionalLight{
    vec3 position;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

//added
uniform PositionalLight light;
uniform vec3 viewPos;

void main(){

//added
	vec3 ambient = light.ambient * our_color;

    //added
    vec3 normal = normalize(our_normal);
    vec3 lightDir = normalize(light.position - fragPos);
    float diff = max(dot(lightDir, normal), 0.0);
    vec3 diffuse = diff * light.diffuse * our_color;

    //Spec
    vec3 r = reflect(-lightDir, normal);
    vec3 viewDir = normalize(viewPos - fragPos);
    float spec = pow(max(dot(r, viewDir), 0.0), 128.0);
    vec3 specular = spec * light.specular * our_color;

//added
    vec3 result = ambient + diffuse + specular;

    
//added color -> result
	color = vec4(result, 1.0);

}