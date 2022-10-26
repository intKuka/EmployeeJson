Sense:
Program reads the argument line command (launchSettings.json or Settings) and performs actions with employee entries (addition, deletion, reading and updating).
All changes will write to Json. Also, it can take initial employees data from Json.

String format:
-[add/delete/update/get/getall] FirstName:[name] LastName:[name] Salary:[decimal number]

Known problem:
When changing the arguments via launchSettings.json, the program will accomplish the previous operation for some reason. But after a restart with the same arguments, operation worked as intended.
If arguments are changed from assembly properties, there's no issue.
