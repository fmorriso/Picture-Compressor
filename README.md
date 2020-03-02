# Picture-Compressor
 Picture Compressor written in C# using .Net Framework 4.8
## Usage
Change the following lines in `Program.cs` to choose the compression quality and base directory where the photos (*.jpg) are located:
```
private const int COMPRESSION_QUALITY = 50;
const string INPUT_PATH = @"C:\Users\fpmor\OneDrive\travel\2020-02 New Mexico\photos";
```
Then recompile and run.

Your output will be located in a subfolder named 
```
C:\Users\fpmor\OneDrive\travel\2020-02 New Mexico\photos\compressed-50\
``` 
(based on above values).
