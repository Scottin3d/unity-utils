# Unity utility library
This is an extension of the generous library put together by [@adammyhre](https://github.com/adammyhre) aka git-amend.
His original library can be found here: https://github.com/adammyhre/Unity-Utils.  I have found myself adding to his existing class as well as adding my own as I work on projects.

## Features

- **Dependency injection:** 
  - https://youtu.be/PJcBJ60C970?si=dst__5Osv-knTVEm
- **Event bus:** Broadcast and react to events anywhere in your game.
  - https://www.youtube.com/watch?v=4_DTAnigmaQ
- **Event channels:** Decouple Game Objects and make your projects more modular and resilient.
- **Extension Methods:** Extend Unity and C# built-in types with additional functionalities.
  - https://youtu.be/Nk49EUf7yyU?si=jnmYNV_LNWu14Emc
- **Helpers:** Static helper methods such as NonAlloc WaitForSeconds.
- **Preconditions:** Static checks to ensure the data your scripts receive is valid
- **Serializables:**
- **Service locators:** 
  - https://www.youtube.com/watch?v=D4r5EyYQvwY
- **Singletons:** Generic Singletons for various use cases.
  - https://youtu.be/LFOXge7Ak3E?si=CYPQ_89z8U6sC67X
- **Statemachine:**

## How to Use

Simply download the library into your Unity project and access the utilities across your scripts or import it in Unity with package manager using this URL:

`https://github.com/Scottin3d/unity-utils.git`

### With Git URL

Add the following line to the dependencies section of your project's manifest.json file.

```
"com.in3d.Utilities": "https://github.com/Scottin3d/unity-utils.git"
```