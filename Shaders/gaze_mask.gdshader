shader_type canvas_item;

uniform vec2 gaze_position; // in local pixel coords of this ColorRect
uniform vec2 rect_size;     // size of this ColorRect, passed from script
uniform float radius = 100.0;
uniform vec4 dark_color : source_color = vec4(0.06, 0.06, 0.06, 1.0);

void fragment() {
    vec2 pixel_pos = UV * rect_size;
    float dist = distance(pixel_pos, gaze_position);
    float mask = step(radius, dist);
    COLOR = vec4(dark_color.rgb, mask);
}