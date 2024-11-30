# AsciiClock
A program that shows what hour it is on an ascii clock. This was more of a technical challenge for myself than an actual useful tool.

![image](https://github.com/user-attachments/assets/022e46ad-a5c5-4e56-b92d-ff61aa61f6de)


## How it works
1. Program gets console height and uses `height/2` as the clock's radius.
2. Clock is generated line by line (`x = lineNumber > height/2 ? height - lineNumber : lineNumber`):

![image](https://github.com/user-attachments/assets/56f8d657-9ee7-4369-aa7c-42eda4d966e4)

3. Clock hands are drawn
   
![image](https://github.com/user-attachments/assets/ceae8cff-e816-424f-9d62-b220a419a3ce)
