To run the program:
1. Open a command prompt (windows).
2. Navigate to “/{user specific address}/Program/” folder
3. The following command will run the file (* = space): 
Program.exe*{arg 1}*{arg2}*{arg3}*{arg4}*{arg5}
Arg1 : key    ** for best performance do not use a key that has adjacent letters of the same value e.g. “doomed” **
Arg2 : filename : the name (including extension) of the file you want to import plaintext from, the two given are “plaintext1.txt” “plaintext2.txt”
Arg3 :  encryptionMethod : “P” for permutation, “V” for vignere
Arg4 : removeSpaces : “true” or “false” if true, output file will have spaces removed, if true, spaces are kept in original positions
Arg5 : outputFileName  : any file name you want to output to, a new file will be created, error message posted in console if file already exists


Example: 
Program.exe “havoc” “plaintext.txt” “V” “true” “myoutput.txt”

**Source files can be found in Source director.**
