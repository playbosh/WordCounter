*** Scenario ***

A small, simple utility is required for a customer.
The user interface program should read a specified text file, filter out the individual words and count the number of occurrences for each word.
The result should be output in the form of a simple table with two columns. The first column should contain the words found, the second column the number of occurrences.

The logic for parsing the file, which divides it into words, is to be developed in a modular manner so that it can be reused later for other projects. High performance is desirable.
The user interface should remain "responsive" during processing so that the customer does not get the feeling that the application is not working properly or is not doing anything.

*** More functional description ***

The program should read ANSI text files.
The file should be user-specifiable.
The separation into words should only be based on white spaces (Space, LF, CR ...). The treatment of punctuation marks does not need to be discussed.
The customer should be able to process larger files (~50 MB). Therefore, the UI should show a progress bar.
There should be an option to cancel.

An example of data to be read can be found in the "Example.txt" file.

The information:

1:1 Adam Seth Enos
1:2 Cainan Adam Seth Iared

Should output the following table as a result:

word count
1:1 1st
adam 2
Seth 2
Enos 1
1:2 1st
cainan 1
Jared 1
