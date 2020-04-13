# Waze To SQL

What does this tool do? Captures Waze information and saves it to a SQL database so it can be later digested.

The tool is setup to run as a windows services.


# How to use
1) Download to a new project
2) Update the App.config config with your database information and your Waze information. (See items in caps.)
3) Compile and deploy the service (not covered here)

# Tools Used
A nice tool that was used to generates classes from JSON data can be found at https://app.quicktype.io. Some of the options we used were:
 - Name: WazeData  (this is in the top left)
 - Namespace: WazeDownloader  (this is under options in top right)
 - Type: Array  (this is under options in top right)
 - Make sure to turn off Detect enums  (this is under options->Other in the top right)

Since this was a quick small project we use "Code First" for database generation:
https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database


# License and Notice
Copyright 2019 

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

