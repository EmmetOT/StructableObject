# StructableObject
StructableObject is a wrapper for Unity's ScriptableObject system. It basically just lets you manipulate a data struct as if it were a ScriptableObject. This has been useful in my own development as it allows you to create systems which work well with both procedural data and designed data.

# Why

Let's say you have a simple struct which represents some simple data package. This could be damage information (how much HP, whether it's poison, the damage source...), an enemy AI profile, any small bit of data. 

You want to make it so your designers can easily modify this information, so you put it in a ScriptableObject. However, your programmers also want to be able to easily create instances of these data objects at runtime with any kind of modification. Maybe your player gets a damage buff so all your projectiles now take 2x HP. There are many solutions for this. You can create ScriptableObjects without saving them as Unity assets, but that has a lot of overhead. You can make interfaces, but that could require some refactoring and it's a pain when you want to add or remove variables to your data.

I often found myself just putting this information in a struct and serializing that struct in a ScriptableObject. Over time, I began writing custom editors for these ScriptableObjects to make it appear that the struct's contents *were* the ScriptableObject, to make the experience seamless for designers. Finally, I wrote this generic solution.

# How

All you have to do is write a serializable struct:

![image](https://user-images.githubusercontent.com/18707147/119384110-1bba4d80-bcbc-11eb-939f-fca8244a5556.png)

Inherit from StructableObject, giving this struct as a type parameter:

![image](https://user-images.githubusercontent.com/18707147/119384154-2e348700-bcbc-11eb-85e9-0f5c8464ff43.png)

And likewise, create a Custom Editor class:

![image](https://user-images.githubusercontent.com/18707147/119385001-6b4d4900-bcbd-11eb-83cb-45862862aa22.png)

The final ScriptableObject appears and works exactly as though you had put the fields right in a ScriptableObject, including supporting undo.

![image](https://user-images.githubusercontent.com/18707147/119384277-5c19cb80-bcbc-11eb-8b0e-6693f1a2cba3.png)

The struct can be accessed in code via the .Data property on the StructableObject, but sometimes I add passthrough properties to make it even more seamless.

![image](https://user-images.githubusercontent.com/18707147/119384440-a00cd080-bcbc-11eb-83b4-e090dfb85ff9.png)
