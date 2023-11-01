# APPT1
Type Guesser
The result of this task should be done in a form of console application. 

It is preferable to use .NET Core console application instead of .NET full framework.

Application should accept only 1 command line argument. If number of arguments is higher than 1 or equals zero - error has to be shown to the user in console and application should terminate after Enter key press. 

This one and only argument is a number which should be validated for fitting following types range:

* byte
* sbyte
* short (both signed and ushort)
* int (both signed and uint)
* long (both signed and ulong)
* float 
* double

For example, if I start "HomeWork1.exe 890" I expect to get following output:

1. byte - false (over limit = 634)
2. sbyte - false (over limit = 762)
3. int - true
4. uint - true
5. long - true
6. ulong - true
7. float - true
8. double - true

So you need to numerate the list with those types, provide true or false that indicates if the provided number can fit into the type value range and in brackets calculate over limit (or under limit if we speak about negative numbers, please also implement that check) and output everything to console.

Application should wait for Enter key press to terminate. 

In case input can not be parsed (is not a number at all) - show error text to the user in console and terminate after Enter key press.
